using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class StoreFM70 : IStoreFM70
    {
        private const string PeriodPrefix = "Period";

        // private ESF_Global _fm70Global;
        private List<ESF_DPOutcome> _dpOutcomes;
        private List<ESF_LearningDelivery> _learningDeliveries;
        private List<ESF_LearningDeliveryDeliverable> _deliverableValues;
        private List<ESF_LearningDeliveryDeliverable_Period> _periods;
        private List<ESF_LearningDeliveryDeliverable_PeriodisedValues> _periodValues;

        public async Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, FM70Global fundingOutputs, CancellationToken cancellationToken)
        {
            //_fm70Global = new ESF_Global
            //{
            //    UKPRN = ukPrn,
            //    RulebaseVersion = fundingOutputs.RulebaseVersion,
            //};

            StoreGlobal(connection, transaction, cancellationToken);

            if (fundingOutputs.Learners == null || !fundingOutputs.Learners.Any())
            {
                return;
            }

            _dpOutcomes = new List<ESF_DPOutcome>();
            _learningDeliveries = new List<ESF_LearningDelivery>();
            _deliverableValues = new List<ESF_LearningDeliveryDeliverable>();
            _periods = new List<ESF_LearningDeliveryDeliverable_Period>();
            _periodValues = new List<ESF_LearningDeliveryDeliverable_PeriodisedValues>();

            foreach (var learner in fundingOutputs.Learners)
            {
                PopulateDPOutcomes(learner, ukPrn);
                PopulateLearningDeliveries(learner, ukPrn);
            }

            await SaveData(connection, transaction, cancellationToken);
        }

        private void PopulateDPOutcomes(FM70Learner learner, int ukPrn)
        {
            foreach (var dpOutcome in learner.LearnerDPOutcomes)
            {
                _dpOutcomes.Add(new ESF_DPOutcome
                {
                    UKPRN = ukPrn,
                    LearnRefNumber = learner.LearnRefNumber,
                    OutCode = dpOutcome.OutCode,
                    OutStartDate = dpOutcome.OutStartDate,
                    OutType = dpOutcome.OutType,
                    OutcomeDateForProgression = dpOutcome.OutcomeDateForProgression,
                    PotentialESFProgressionType = dpOutcome.PotentialESFProgressionType,
                    ProgressionType = dpOutcome.ProgressionType,
                    ReachedSixMonthPoint = dpOutcome.ReachedSixMonthPoint,
                    ReachedThreeMonthPoint = dpOutcome.ReachedThreeMonthPoint,
                    ReachedTwelveMonthPoint = dpOutcome.ReachedTwelveMonthPoint
                });
            }
        }

        private void PopulateLearningDeliveries(FM70Learner learner, int ukPrn)
        {
            foreach (var delivery in learner.LearningDeliveries)
            {
                _learningDeliveries.Add(FM70LearningDeliveryBuilder.BuildLearningDelivery(delivery, ukPrn, learner.LearnRefNumber));

                foreach (var value in delivery.LearningDeliveryDeliverableValues)
                {
                    _deliverableValues.Add(new ESF_LearningDeliveryDeliverable()
                    {
                        UKPRN = ukPrn,
                        AimSeqNumber = delivery.AimSeqNumber ?? 0,
                        LearnRefNumber = learner.LearnRefNumber,
                        DeliverableCode = value.DeliverableCode,
                        DeliverableUnitCost = value.DeliverableUnitCost
                    });

                    for (var i = 1; i < 13; i++)
                    {
                        _periods.Add(new ESF_LearningDeliveryDeliverable_Period
                        {
                            LearnRefNumber = learner.LearnRefNumber,
                            UKPRN = ukPrn,
                            Period = i,
                            AimSeqNumber = delivery.AimSeqNumber ?? 0,
                            DeliverableCode = value.DeliverableCode,
                            AchievementEarnings = GetPeriodValueForDelivery<decimal?>(value, "AchievementEarnings", i),
                            AdditionalProgCostEarnings = GetPeriodValueForDelivery<decimal?>(value, "AdditionalProgCostEarnings", i),
                            DeliverableVolume = GetPeriodValueForDelivery<long?>(value, "DeliverableVolume", i),
                            ProgressionEarnings = GetPeriodValueForDelivery<decimal?>(value, "ProgressionEarnings", i),
                            StartEarnings = GetPeriodValueForDelivery<decimal?>(value, "StartEarnings", i),
                            ReportingVolume = GetPeriodValueForDelivery<int?>(value, "ReportingVolume", i),
                        });
                    }

                    foreach (var periodisedValue in value.LearningDeliveryDeliverablePeriodisedValues)
                    {
                        _periodValues.Add(new ESF_LearningDeliveryDeliverable_PeriodisedValues
                        {
                            UKPRN = ukPrn,
                            AimSeqNumber = delivery.AimSeqNumber ?? 0,
                            LearnRefNumber = learner.LearnRefNumber,
                            AttributeName = periodisedValue.AttributeName,
                            DeliverableCode = value.DeliverableCode,
                            Period_1 = periodisedValue.Period1,
                            Period_2 = periodisedValue.Period2,
                            Period_3 = periodisedValue.Period3,
                            Period_4 = periodisedValue.Period4,
                            Period_5 = periodisedValue.Period5,
                            Period_6 = periodisedValue.Period6,
                            Period_7 = periodisedValue.Period7,
                            Period_8 = periodisedValue.Period8,
                            Period_9 = periodisedValue.Period9,
                            Period_10 = periodisedValue.Period10,
                            Period_11 = periodisedValue.Period11,
                            Period_12 = periodisedValue.Period12
                        });
                    }
                }
            }
        }

        private async void StoreGlobal(
            SqlConnection connection,
            SqlTransaction transaction,
            CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (var bulkInsert = new BulkInsert(connection, transaction, cancellationToken))
            {
                //await bulkInsert.Insert("Rulebase.ESF_global", new List<FM70Global> { _fm70Global });
            }
        }

        private async Task SaveData(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (var bulkInsert = new BulkInsert(connection, transaction, cancellationToken))
            {
                await bulkInsert.Insert("Rulebase.ESF_DPOutcome", _dpOutcomes);
                await bulkInsert.Insert("Rulebase.ESF_LearningDelivery", _learningDeliveries);
                await bulkInsert.Insert("Rulebase.ESF_LearningDeliveryDeliverable", _deliverableValues);
                await bulkInsert.Insert("Rulebase.ESF_LearningDeliveryDeliverable_Period", _periods);
                await bulkInsert.Insert("Rulebase.ESF_LearningDeliveryDeliverable_PeriodisedValues", _periodValues);
            }
        }

        private static TR GetPeriodValueForDelivery<TR>(LearningDeliveryDeliverableValues attribute, string name, int period)
        {
            var a = attribute.LearningDeliveryDeliverablePeriodisedValues.FirstOrDefault(attr => attr.AttributeName == name);

            var value = a?.GetType().GetProperty($"{PeriodPrefix}{period.ToString()}")?.GetValue(a);

            return TypeHelper.PeriodValueTypeHandler<TR>(value);
        }
    }
}
