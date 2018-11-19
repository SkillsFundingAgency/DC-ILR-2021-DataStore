using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class StoreFM81 : AbstractStore, IStoreService<FM81Global>
    {
        private const string PeriodPrefix = "Period";

        private TBL_global _FM81Global;
        private List<TBL_LearningDelivery> _learningDeliveries;
        private List<TBL_LearningDelivery_Period> _periods;
        private List<TBL_LearningDelivery_PeriodisedValues> _periodValues;

        public async Task StoreAsync(SqlTransaction sqlTransaction, int ukPrn, FM81Global fundingOutputs, CancellationToken cancellationToken)
        {
            _FM81Global = new TBL_global
            {
                CurFundYr = fundingOutputs.CurFundYr,
                LARSVersion = fundingOutputs.LARSVersion,
                UKPRN = ukPrn,
                RulebaseVersion = fundingOutputs.RulebaseVersion,
            };

            StoreGlobal(sqlTransaction, cancellationToken);

            if (fundingOutputs.Learners == null || !fundingOutputs.Learners.Any())
            {
                return;
            }

            _learningDeliveries = new List<TBL_LearningDelivery>();
            _periods = new List<TBL_LearningDelivery_Period>();
            _periodValues = new List<TBL_LearningDelivery_PeriodisedValues>();

            foreach (var learner in fundingOutputs.Learners)
            {
                foreach (var deliveryAttribute in learner.LearningDeliveries)
                {
                    _learningDeliveries.Add(FM81LearningDeliveryBuilder.BuildLearningDelivery(ukPrn, learner.LearnRefNumber, deliveryAttribute));

                    for (var i = 1; i < 13; i++)
                    {
                        _periods.Add(new TBL_LearningDelivery_Period
                        {
                            LearnRefNumber = learner.LearnRefNumber,
                            UKPRN = ukPrn,
                            Period = i,
                            AimSeqNumber = deliveryAttribute.AimSeqNumber ?? 0,
                            AchPayment = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "AchPayment", i),
                            CoreGovContPayment = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "CoreGovContPayment", i),
                            CoreGovContUncapped = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "CoreGovContUncapped", i),
                            InstPerPeriod = GetPeriodValueForDelivery<int?>(deliveryAttribute, "InstPerPeriod", i),
                            LearnSuppFund = GetPeriodValueForDelivery<bool?>(deliveryAttribute, "LearnSuppFund", i),
                            LearnSuppFundCash = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "LearnSuppFundCash", i),
                            MathEngBalPayment = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "MathEngBalPayment", i),
                            MathEngBalPct = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "MathEngBalPct", i),
                            MathEngOnProgPayment = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "MathEngOnProgPayment", i),
                            MathEngOnProgPct = GetPeriodValueForDelivery<int?>(deliveryAttribute, "MathEngOnProgPct", i),
                            SmallBusPayment = GetPeriodValueForDelivery<int?>(deliveryAttribute, "SmallBusPayment", i),
                            YoungAppFirstPayment = GetPeriodValueForDelivery<int?>(deliveryAttribute, "YoungAppFirstPayment", i),
                            YoungAppPayment = GetPeriodValueForDelivery<int?>(deliveryAttribute, "YoungAppPayment", i),
                            YoungAppSecondPayment = GetPeriodValueForDelivery<int?>(deliveryAttribute, "YoungAppSecondPayment", i)
                        });
                    }

                    foreach (var value in deliveryAttribute.LearningDeliveryPeriodisedValues)
                    {
                        _periodValues.Add(new TBL_LearningDelivery_PeriodisedValues
                        {
                            UKPRN = ukPrn,
                            AimSeqNumber = deliveryAttribute.AimSeqNumber ?? 0,
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
                    }
                }
            }

            await SaveData(sqlTransaction, cancellationToken);
        }

        private async void StoreGlobal(SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

             await _bulkInsert.Insert("Rulebase.TBL_global", new List<TBL_global> { _FM81Global }, sqlTransaction, cancellationToken);
        }

        private async Task SaveData(SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert("Rulebase.TBL_LearningDelivery", _learningDeliveries, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.TBL_LearningDelivery_Period", _periods, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.TBL_LearningDelivery_PeriodisedValues", _periodValues, sqlTransaction, cancellationToken);
        }

        private static TR GetPeriodValueForDelivery<TR>(LearningDelivery attribute, string name, int period)
        {
            var a = attribute.LearningDeliveryPeriodisedValues.FirstOrDefault(attr => attr.AttributeName == name);

            var value = a?.GetType().GetProperty($"{PeriodPrefix}{period.ToString()}")?.GetValue(a);

            return TypeHelper.PeriodValueTypeHandler<TR>(value);
        }
    }
}
