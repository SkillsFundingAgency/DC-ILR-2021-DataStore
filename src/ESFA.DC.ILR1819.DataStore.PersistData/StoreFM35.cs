using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class StoreFM35 : AbstractStore, IStoreService<FM35Global>
    {
        private FM35_global _fm35Global;
        private List<FM35_LearningDelivery> _learningDeliveries;
        private List<FM35_LearningDelivery_Period> _periods;
        private List<FM35_LearningDelivery_PeriodisedValues> _periodValues;

        public async Task StoreAsync(SqlTransaction sqlTransaction, int ukPrn, FM35Global fundingOutputs, CancellationToken cancellationToken)
        {
            _fm35Global = new FM35_global
            {
                CurFundYr = fundingOutputs.CurFundYr,
                LARSVersion = fundingOutputs.LARSVersion,
                UKPRN = ukPrn,
                RulebaseVersion = fundingOutputs.RulebaseVersion,
                OrgVersion = fundingOutputs.OrgVersion,
                PostcodeDisadvantageVersion = fundingOutputs.PostcodeDisadvantageVersion
            };

            StoreGlobal(sqlTransaction, cancellationToken);

            StoreLearners(sqlTransaction, cancellationToken, fundingOutputs.Learners
               .Select(l => new FM35_Learner
               {
                   UKPRN = ukPrn,
                   LearnRefNumber = l.LearnRefNumber
               }).ToList());

            if (fundingOutputs.Learners == null || !fundingOutputs.Learners.Any())
            {
                return;
            }

            _learningDeliveries = new List<FM35_LearningDelivery>();
            _periods = new List<FM35_LearningDelivery_Period>();
            _periodValues = new List<FM35_LearningDelivery_PeriodisedValues>();

            foreach (var learner in fundingOutputs.Learners)
            {
                foreach (var deliveryAttribute in learner.LearningDeliveries)
                {
                    _learningDeliveries.Add(FM35LearningDeliveryBuilder.BuildLearningDelivery(ukPrn, learner.LearnRefNumber, deliveryAttribute));

                    for (var i = 1; i < 13; i++)
                    {
                        _periods.Add(new FM35_LearningDelivery_Period
                        {
                            LearnRefNumber = learner.LearnRefNumber,
                            UKPRN = ukPrn,
                            Period = i,
                            AimSeqNumber = deliveryAttribute.AimSeqNumber ?? 0,
                            OnProgPayment = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "OnProgPayment", i),
                            AchievePayPct = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "AchievePayPct", i),
                            AchievePayPctTrans = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "AchievePayPctTrans", i),
                            AchievePayment = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "AchievePayment", i),
                            BalancePayment = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "BalancePayment", i),
                            BalancePaymentUncapped = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "BalancePaymentUncapped", i),
                            BalancePct = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "BalancePct", i),
                            BalancePctTrans = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "BalancePctTrans", i),
                            EmpOutcomePay = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "EmpOutcomePay", i),
                            EmpOutcomePct = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "EmpOutcomePct", i),
                            EmpOutcomePctTrans = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "EmpOutcomePctTrans", i),
                            InstPerPeriod = GetPeriodValueForDelivery<int?>(deliveryAttribute, "InstPerPeriod", i),
                            LearnSuppFund = GetPeriodValueForDelivery<bool?>(deliveryAttribute, "LearnSuppFund", i),
                            LearnSuppFundCash = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "LearnSuppFundCash", i),
                            OnProgPayPct = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "OnProgPayPct", i),
                            OnProgPayPctTrans = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "OnProgPayPctTrans", i),
                            OnProgPaymentUncapped = GetPeriodValueForDelivery<decimal?>(deliveryAttribute, "OnProgPaymentUncapped", i),
                            TransInstPerPeriod = GetPeriodValueForDelivery<int?>(deliveryAttribute, "TransInstPerPeriod", i)
                        });
                    }

                    foreach (var value in deliveryAttribute.LearningDeliveryPeriodisedValues)
                    {
                        _periodValues.Add(new FM35_LearningDelivery_PeriodisedValues
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

            await _bulkInsert.Insert("Rulebase.FM35_global", new List<FM35_global> { _fm35Global }, sqlTransaction, cancellationToken);
        }

        private async void StoreLearners(SqlTransaction sqlTransaction, CancellationToken cancellationToken, List<FM35_Learner> fm35Learners)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert("Rulebase.FM35_Learner", fm35Learners, sqlTransaction, cancellationToken);
        }

        private async Task SaveData(SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert("Rulebase.FM35_LearningDelivery", _learningDeliveries, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.FM35_LearningDelivery_Period", _periods, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.FM35_LearningDelivery_PeriodisedValues", _periodValues, sqlTransaction, cancellationToken);
        }

        private static TR GetPeriodValueForDelivery<TR>(LearningDelivery attribute, string name, int period)
        {
            var a = attribute.LearningDeliveryPeriodisedValues.FirstOrDefault(attr => attr.AttributeName == name);

            var value = a?.GetType().GetProperty($"{PersistDataConstants.PeriodPrefix}{period.ToString()}")?.GetValue(a);

            return TypeHelper.PeriodValueTypeHandler<TR>(value);
        }
    }
}
