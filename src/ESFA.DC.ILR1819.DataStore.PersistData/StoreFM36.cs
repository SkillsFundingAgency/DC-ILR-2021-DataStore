using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class StoreFM36 : IStoreFM36
    {
        private const string PeriodPrefix = "Period";

        private AEC_global _fm36Global;
        private List<AEC_LearningDelivery> _learningDeliveries;
        private List<AEC_LearningDelivery_Period> _periods;
        private List<AEC_LearningDelivery_PeriodisedValues> _periodValues;
        private List<AEC_LearningDelivery_PeriodisedTextValues> _periodTextValues;

        private List<AEC_ApprenticeshipPriceEpisode> _priceEpisodes;
        private List<AEC_ApprenticeshipPriceEpisode_Period> _priceEpisodePeriods;
        private List<AEC_ApprenticeshipPriceEpisode_PeriodisedValues> _priceEpisodePeriodValues;

        public async Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, FM36Global fundingOutputs, CancellationToken cancellationToken)
        {
            _fm36Global = new AEC_global
            {
                LARSVersion = fundingOutputs.LARSVersion,
                UKPRN = ukPrn,
                RulebaseVersion = fundingOutputs.RulebaseVersion,
                Year = fundingOutputs.Year
            };

            StoreGlobal(connection, transaction, cancellationToken);

            if (fundingOutputs.Learners == null || !fundingOutputs.Learners.Any())
            {
                return;
            }

            _learningDeliveries = new List<AEC_LearningDelivery>();
            _periods = new List<AEC_LearningDelivery_Period>();
            _periodValues = new List<AEC_LearningDelivery_PeriodisedValues>();
            _periodTextValues = new List<AEC_LearningDelivery_PeriodisedTextValues>();

            _priceEpisodes = new List<AEC_ApprenticeshipPriceEpisode>();
            _priceEpisodePeriods = new List<AEC_ApprenticeshipPriceEpisode_Period>();
            _priceEpisodePeriodValues = new List<AEC_ApprenticeshipPriceEpisode_PeriodisedValues>();

            foreach (var learner in fundingOutputs.Learners)
            {
                PopulateLearningDeliveries(learner, ukPrn);
                PopulatePriceEpisodes(learner, ukPrn);
            }

            await SaveData(connection, transaction, cancellationToken);
        }

        private void PopulateLearningDeliveries(FM36Learner learner, int ukPrn)
        {
            foreach (var delivery in learner.LearningDeliveries)
            {
                _learningDeliveries.Add(FM36LearningDeliveryBuilder.BuildLearningDelivery(delivery, ukPrn, learner.LearnRefNumber));

                for (var i = 1; i < 13; i++)
                {
                    _periods.Add(new AEC_LearningDelivery_Period
                    {
                        LearnRefNumber = learner.LearnRefNumber,
                        UKPRN = ukPrn,
                        Period = i,
                        AimSeqNumber = delivery.AimSeqNumber,
                        LearnSuppFund = GetPeriodValueForDelivery<bool?>(delivery, "LearnSuppFund", i),
                        LearnSuppFundCash = GetPeriodValueForDelivery<decimal?>(delivery, "LearnSuppFundCash", i),
                        InstPerPeriod = GetPeriodValueForDelivery<int?>(delivery, "InstPerPeriod", i),
                        DisadvFirstPayment = GetPeriodValueForDelivery<decimal?>(delivery, "DisadvFirstPayment", i),
                        DisadvSecondPayment = GetPeriodValueForDelivery<decimal?>(delivery, "DisadvSecondPayment", i),
                        FundLineType = GetPeriodValueForDelivery<string>(delivery, "FundLineType", i),
                        LDApplic1618FrameworkUpliftBalancingPayment = GetPeriodValueForDelivery<decimal?>(delivery, "LDApplic1618FrameworkUpliftBalancingPayment", i),
                        LDApplic1618FrameworkUpliftCompletionPayment = GetPeriodValueForDelivery<decimal?>(delivery, "LDApplic1618FrameworkUpliftCompletionPayment", i),
                        LDApplic1618FrameworkUpliftOnProgPayment = GetPeriodValueForDelivery<decimal?>(delivery, "LDApplic1618FrameworkUpliftOnProgPayment", i),
                        LearnDelContType = GetPeriodValueForDelivery<string>(delivery, "LearnDelContType", i),
                        LearnDelFirstEmp1618Pay = GetPeriodValueForDelivery<decimal?>(delivery, "LearnDelFirstEmp1618Pay", i),
                        LearnDelFirstProv1618Pay = GetPeriodValueForDelivery<decimal?>(delivery, "LearnDelFirstProv1618Pay", i),
                        LearnDelLevyNonPayInd = GetPeriodValueForDelivery<int?>(delivery, "LearnDelLevyNonPayInd", i),
                        LearnDelSEMContWaiver = GetPeriodValueForDelivery<bool?>(delivery, "LearnDelSEMContWaiver", i),
                        LearnDelSFAContribPct = GetPeriodValueForDelivery<decimal?>(delivery, "LearnDelSFAContribPct", i),
                        LearnDelSecondEmp1618Pay = GetPeriodValueForDelivery<decimal?>(delivery, "LearnDelSecondEmp1618Pay", i),
                        LearnDelSecondProv1618Pay = GetPeriodValueForDelivery<decimal?>(delivery, "LearnDelSecondProv1618Pay", i),
                        MathEngBalPayment = GetPeriodValueForDelivery<decimal?>(delivery, "MathEngBalPayment", i),
                        MathEngBalPct = GetPeriodValueForDelivery<decimal?>(delivery, "MathEngBalPct", i),
                        MathEngOnProgPayment = GetPeriodValueForDelivery<decimal?>(delivery, "MathEngOnProgPayment", i),
                        MathEngOnProgPct = GetPeriodValueForDelivery<decimal?>(delivery, "MathEngOnProgPct", i),
                        ProgrammeAimBalPayment = GetPeriodValueForDelivery<decimal?>(delivery, "ProgrammeAimBalPayment", i),
                        ProgrammeAimCompletionPayment = GetPeriodValueForDelivery<decimal?>(delivery, "ProgrammeAimCompletionPayment", i),
                        ProgrammeAimOnProgPayment = GetPeriodValueForDelivery<decimal?>(delivery, "ProgrammeAimOnProgPayment", i),
                        ProgrammeAimProgFundIndMaxEmpCont = GetPeriodValueForDelivery<decimal?>(delivery, "ProgrammeAimProgFundIndMaxEmpCont", i),
                        ProgrammeAimProgFundIndMinCoInvest = GetPeriodValueForDelivery<decimal?>(delivery, "ProgrammeAimProgFundIndMinCoInvest", i),
                        ProgrammeAimTotProgFund = GetPeriodValueForDelivery<decimal?>(delivery, "ProgrammeAimTotProgFund", i)
                    });
                }

                foreach (var value in delivery.LearningDeliveryPeriodisedValues)
                {
                    _periodValues.Add(new AEC_LearningDelivery_PeriodisedValues
                    {
                        UKPRN = ukPrn,
                        AimSeqNumber = delivery.AimSeqNumber,
                        LearnRefNumber = learner.LearnRefNumber,
                        AttributeName = value.AttributeName,
                        Period_1 = value.Period1,
                        Period_2 = value.Period2,
                        Period_3 = value.Period3,
                        Period_4 = value.Period4,
                        Period_5 = value.Period5,
                        Period_6 = value.Period6,
                        Period_7 = value.Period7,
                        Period_8 = value.Period8,
                        Period_9 = value.Period9,
                        Period_10 = value.Period10,
                        Period_11 = value.Period11,
                        Period_12 = value.Period12
                    });

                    _periodTextValues.Add(new AEC_LearningDelivery_PeriodisedTextValues
                    {
                        UKPRN = ukPrn,
                        AimSeqNumber = delivery.AimSeqNumber,
                        LearnRefNumber = learner.LearnRefNumber,
                        AttributeName = value.AttributeName,
                        Period_1 = value.Period1.ToString(),
                        Period_2 = value.Period2.ToString(),
                        Period_3 = value.Period3.ToString(),
                        Period_4 = value.Period4.ToString(),
                        Period_5 = value.Period5.ToString(),
                        Period_6 = value.Period6.ToString(),
                        Period_7 = value.Period7.ToString(),
                        Period_8 = value.Period8.ToString(),
                        Period_9 = value.Period9.ToString(),
                        Period_10 = value.Period10.ToString(),
                        Period_11 = value.Period11.ToString(),
                        Period_12 = value.Period12.ToString()
                    });
                }
            }
        }

        private void PopulatePriceEpisodes(FM36Learner learner, int ukPrn)
        {
            foreach (var priceEpisode in learner.PriceEpisodes)
            {
                _priceEpisodes.Add(FM36PriceEpisodeBuilder.BuildPriceEpisode(priceEpisode, ukPrn, learner.LearnRefNumber));

                for (var i = 1; i < 13; i++)
                {
                    _priceEpisodePeriods.Add(new AEC_ApprenticeshipPriceEpisode_Period
                    {
                        UKPRN = ukPrn,
                        LearnRefNumber = learner.LearnRefNumber,
                        Period = i,
                        PriceEpisodeIdentifier = priceEpisode.PriceEpisodeIdentifier,
                        PriceEpisodeApplic1618FrameworkUpliftBalancing = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeApplic1618FrameworkUpliftBalancing", i),
                        PriceEpisodeApplic1618FrameworkUpliftCompletionPayment = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeApplic1618FrameworkUpliftCompletionPayment", i),
                        PriceEpisodeApplic1618FrameworkUpliftOnProgPayment = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeApplic1618FrameworkUpliftOnProgPayment", i),
                        PriceEpisodeBalancePayment = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeBalancePayment", i),
                        PriceEpisodeBalanceValue = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeBalanceValue", i),
                        PriceEpisodeCompletionPayment = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeCompletionPayment", i),
                        PriceEpisodeFirstDisadvantagePayment = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeFirstDisadvantagePayment", i),
                        PriceEpisodeFirstEmp1618Pay = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeFirstEmp1618Pay", i),
                        PriceEpisodeFirstProv1618Pay = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeFirstProv1618Pay", i),
                        PriceEpisodeInstalmentsThisPeriod = GetPeriodValueForEpisode<int?>(priceEpisode, "PriceEpisodeInstalmentsThisPeriod", i),
                        PriceEpisodeLSFCash = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeLSFCash", i),
                        PriceEpisodeLearnerAdditionalPayment = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeLearnerAdditionalPayment", i),
                        PriceEpisodeLevyNonPayInd = GetPeriodValueForEpisode<int?>(priceEpisode, "PriceEpisodeLevyNonPayInd", i),
                        PriceEpisodeOnProgPayment = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeOnProgPayment", i),
                        PriceEpisodeProgFundIndMaxEmpCont = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeProgFundIndMaxEmpCont", i),
                        PriceEpisodeProgFundIndMinCoInvest = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeProgFundIndMinCoInvest", i),
                        PriceEpisodeSFAContribPct = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeSFAContribPct", i),
                        PriceEpisodeSecondDisadvantagePayment = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeSecondDisadvantagePayment", i),
                        PriceEpisodeSecondEmp1618Pay = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeSecondEmp1618Pay", i),
                        PriceEpisodeSecondProv1618Pay = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeSecondProv1618Pay", i),
                        PriceEpisodeTotProgFunding = GetPeriodValueForEpisode<decimal?>(priceEpisode, "PriceEpisodeTotProgFunding", i)
                    });
                }

                foreach (var periodisedValue in priceEpisode.PriceEpisodePeriodisedValues)
                {
                    _priceEpisodePeriodValues.Add(new AEC_ApprenticeshipPriceEpisode_PeriodisedValues
                    {
                        UKPRN = ukPrn,
                        LearnRefNumber = learner.LearnRefNumber,
                        AttributeName = periodisedValue.AttributeName,
                        PriceEpisodeIdentifier = priceEpisode.PriceEpisodeIdentifier,
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
                await bulkInsert.Insert("Rulebase.AEC_global", new List<AEC_global> { _fm36Global });
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
                await bulkInsert.Insert("Rulebase.AEC_LearningDelivery", _learningDeliveries);
                await bulkInsert.Insert("Rulebase.AEC_LearningDelivery_Period", _periods);
                await bulkInsert.Insert("Rulebase.AEC_LearningDelivery_PeriodisedValues", _periodValues);
                await bulkInsert.Insert("Rulebase.AEC_LearningDelivery_PeriodisedTextValues", _periodTextValues);
                await bulkInsert.Insert("Rulebase.AEC_ApprenticeshipPriceEpisode", _priceEpisodes);
                await bulkInsert.Insert("Rulebase.AEC_ApprenticeshipPriceEpisode_Period", _priceEpisodePeriods);
                await bulkInsert.Insert("Rulebase.AEC_ApprenticeshipPriceEpisode_PeriodisedValues", _priceEpisodePeriodValues);
            }
        }

        private static TR GetPeriodValueForDelivery<TR>(LearningDelivery attribute, string name, int period)
        {
            var a = attribute.LearningDeliveryPeriodisedValues.FirstOrDefault(attr => attr.AttributeName == name);

            var value = a?.GetType().GetProperty($"{PeriodPrefix}{period.ToString()}")?.GetValue(a);

            return TypeHelper.PeriodValueTypeHandler<TR>(value);
        }

        private static TR GetPeriodValueForEpisode<TR>(PriceEpisode episode, string name, int period)
        {
            var a = episode.PriceEpisodePeriodisedValues.FirstOrDefault(attr => attr.AttributeName == name);

            var value = a?.GetType().GetProperty($"{PeriodPrefix}{period.ToString()}")?.GetValue(a);

            return TypeHelper.PeriodValueTypeHandler<TR>(value);
        }
    }
}
