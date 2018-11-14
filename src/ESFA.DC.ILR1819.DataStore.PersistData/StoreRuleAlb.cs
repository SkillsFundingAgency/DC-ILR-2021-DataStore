using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreRuleAlb : AbstractStore, IStoreRuleAlb
    {
        public async Task StoreAsync(SqlConnection connection, SqlTransaction sqlTransaction, int ukPrn, ALBGlobal fundingOutputs, CancellationToken cancellationToken)
        {
            ALB_global albGlobal = new ALB_global
            {
                UKPRN = ukPrn,
                LARSVersion = fundingOutputs.LARSVersion,
                PostcodeAreaCostVersion = fundingOutputs.PostcodeAreaCostVersion,
                RulebaseVersion = fundingOutputs.RulebaseVersion
            };

            StoreGlobal(connection, sqlTransaction, cancellationToken, albGlobal);

            if (fundingOutputs.Learners == null || !fundingOutputs.Learners.Any())
            {
                return;
            }

            List<ALB_Learner_Period> albLearnerPeriods = new List<ALB_Learner_Period>(fundingOutputs.Learners.Count * 12);
            List<ALB_Learner_PeriodisedValues> albLearnerPeriodisedValues = new List<ALB_Learner_PeriodisedValues>(fundingOutputs.Learners.Count);
            List<ALB_LearningDelivery> albLearningDeliveries = new List<ALB_LearningDelivery>(fundingOutputs.Learners.Count);
            List<ALB_LearningDelivery_Period> albLearningDeliveryPeriods = new List<ALB_LearningDelivery_Period>(fundingOutputs.Learners.Count * 12);
            List<ALB_LearningDelivery_PeriodisedValues> albLearningDeliveryPeriodisedValues = new List<ALB_LearningDelivery_PeriodisedValues>(fundingOutputs.Learners.Count);

            foreach (var learner in fundingOutputs.Learners)
            {
                var attr = learner.LearnerPeriodisedValues?.SingleOrDefault(x => x.AttributeName == "ALBSeqNum");

                if (attr != null)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        albLearnerPeriods.Add(new ALB_Learner_Period
                        {
                            LearnRefNumber = learner.LearnRefNumber,
                            UKPRN = ukPrn,
                            ALBSeqNum = (int?)GetPeriodValue(attr, i),
                            Period = i + 1
                        });
                    }

                    albLearnerPeriodisedValues.Add(new ALB_Learner_PeriodisedValues
                    {
                        LearnRefNumber = learner.LearnRefNumber,
                        UKPRN = ukPrn,
                        AttributeName = attr.AttributeName,
                        Period_1 = attr.Period1,
                        Period_2 = attr.Period2,
                        Period_3 = attr.Period3,
                        Period_4 = attr.Period4,
                        Period_5 = attr.Period5,
                        Period_6 = attr.Period6,
                        Period_7 = attr.Period7,
                        Period_8 = attr.Period8,
                        Period_9 = attr.Period9,
                        Period_10 = attr.Period10,
                        Period_11 = attr.Period11,
                        Period_12 = attr.Period12,
                    });
                }

                if (learner.LearningDeliveries == null)
                {
                    continue;
                }

                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    albLearningDeliveries.Add(new ALB_LearningDelivery
                    {
                        LearnRefNumber = learner.LearnRefNumber,
                        UKPRN = ukPrn,
                        AimSeqNumber = learningDelivery.AimSeqNumber,
                        Achieved = learningDelivery.LearningDeliveryValue?.Achieved,
                        ActualNumInstalm = learningDelivery.LearningDeliveryValue?.ActualNumInstalm,
                        AdvLoan = learningDelivery.LearningDeliveryValue?.AdvLoan,
                        ApplicFactDate = learningDelivery.LearningDeliveryValue?.ApplicFactDate,
                        ApplicProgWeightFact = learningDelivery.LearningDeliveryValue?.ApplicProgWeightFact,
                        AreaCostFactAdj = learningDelivery.LearningDeliveryValue?.AreaCostFactAdj,
                        AreaCostInstalment = learningDelivery.LearningDeliveryValue?.AreaCostInstalment,
                        FundLine = learningDelivery.LearningDeliveryValue?.FundLine,
                        FundStart = learningDelivery.LearningDeliveryValue?.FundStart,
                        LiabilityDate = learningDelivery.LearningDeliveryValue?.LiabilityDate,
                        LoanBursAreaUplift = learningDelivery.LearningDeliveryValue?.LoanBursAreaUplift,
                        LoanBursSupp = learningDelivery.LearningDeliveryValue?.LoanBursSupp,
                        OutstndNumOnProgInstalm = learningDelivery.LearningDeliveryValue?.OutstndNumOnProgInstalm,
                        PlannedNumOnProgInstalm = learningDelivery.LearningDeliveryValue?.PlannedNumOnProgInstalm,
                        WeightedRate = learningDelivery.LearningDeliveryValue?.WeightedRate,
                        LearnDelApplicSubsidyPilotAreaCode = learningDelivery.LearningDeliveryValue
                            ?.LearnDelApplicSubsidyPilotAreaCode,
                        LearnDelEligCareerLearnPilot =
                            learningDelivery.LearningDeliveryValue?.LearnDelEligCareerLearnPilot,
                        LearnDelApplicLARSCarPilFundSubRate = learningDelivery.LearningDeliveryValue
                            ?.LearnDelApplicLARSCarPilFundSubRate,
                        LearnDelCarLearnPilotAimValue =
                            learningDelivery.LearningDeliveryValue?.LearnDelCarLearnPilotAimValue,
                        LearnDelCarLearnPilotInstalAmount = learningDelivery.LearningDeliveryValue
                            ?.LearnDelCarLearnPilotInstalAmount
                    });

                    var albCode =
                        learningDelivery.LearningDeliveryPeriodisedValues?.SingleOrDefault(x =>
                            x.AttributeName == "ALBCode");
                    var albSupportPayment =
                        learningDelivery.LearningDeliveryPeriodisedValues?.SingleOrDefault(x =>
                            x.AttributeName == "ALBSupportPayment");
                    var albAreaUpliftBalPayment =
                        learningDelivery.LearningDeliveryPeriodisedValues?.SingleOrDefault(x =>
                            x.AttributeName == "AreaUpliftBalPayment");
                    var albAreaUpliftOnProgPayment =
                        learningDelivery.LearningDeliveryPeriodisedValues?.SingleOrDefault(x =>
                            x.AttributeName == "AreaUpliftOnProgPayment");
                    var albLearnDelCarLearnPilotBalPayment =
                        learningDelivery.LearningDeliveryPeriodisedValues?.SingleOrDefault(x =>
                            x.AttributeName == "LearnDelCarLearnPilotBalPayment");
                    var albLearnDelCarLearnPilotOnProgPayment =
                        learningDelivery.LearningDeliveryPeriodisedValues?.SingleOrDefault(x =>
                            x.AttributeName == "LearnDelCarLearnPilotOnProgPayment");

                    for (var i = 0; i < 12; i++)
                    {
                        albLearningDeliveryPeriods.Add(new ALB_LearningDelivery_Period
                        {
                            LearnRefNumber = learner.LearnRefNumber,
                            UKPRN = ukPrn,
                            AimSeqNumber = learningDelivery.AimSeqNumber,
                            Period = i + 1,
                            ALBCode = albCode == null ? 0 : (int?)GetPeriodValue(albCode, i),
                            ALBSupportPayment = albSupportPayment == null
                                ? 0
                                : GetPeriodValue(albSupportPayment, i),
                            AreaUpliftBalPayment = albAreaUpliftBalPayment == null
                                ? 0
                                : GetPeriodValue(albAreaUpliftBalPayment, i),
                            AreaUpliftOnProgPayment = albAreaUpliftOnProgPayment == null
                                ? 0
                                : GetPeriodValue(albAreaUpliftOnProgPayment, i),
                            LearnDelCarLearnPilotBalPayment = albLearnDelCarLearnPilotBalPayment == null
                                ? 0
                                : GetPeriodValue(albLearnDelCarLearnPilotBalPayment, i),
                            LearnDelCarLearnPilotOnProgPayment = albLearnDelCarLearnPilotOnProgPayment == null
                                ? 0
                                : GetPeriodValue(albLearnDelCarLearnPilotOnProgPayment, i)
                        });
                    }

                    if (learningDelivery.LearningDeliveryPeriodisedValues == null)
                    {
                        continue;
                    }

                    foreach (var learningDeliveryPeriodisedAttribute in learningDelivery
                        .LearningDeliveryPeriodisedValues)
                    {
                        albLearningDeliveryPeriodisedValues.Add(new ALB_LearningDelivery_PeriodisedValues
                        {
                            LearnRefNumber = learner.LearnRefNumber,
                            UKPRN = ukPrn,
                            AimSeqNumber = learningDelivery.AimSeqNumber,
                            AttributeName = learningDeliveryPeriodisedAttribute.AttributeName,
                            Period_1 = learningDeliveryPeriodisedAttribute.Period1,
                            Period_2 = learningDeliveryPeriodisedAttribute.Period2,
                            Period_3 = learningDeliveryPeriodisedAttribute.Period3,
                            Period_4 = learningDeliveryPeriodisedAttribute.Period4,
                            Period_5 = learningDeliveryPeriodisedAttribute.Period5,
                            Period_6 = learningDeliveryPeriodisedAttribute.Period6,
                            Period_7 = learningDeliveryPeriodisedAttribute.Period7,
                            Period_8 = learningDeliveryPeriodisedAttribute.Period8,
                            Period_9 = learningDeliveryPeriodisedAttribute.Period9,
                            Period_10 = learningDeliveryPeriodisedAttribute.Period10,
                            Period_11 = learningDeliveryPeriodisedAttribute.Period11,
                            Period_12 = learningDeliveryPeriodisedAttribute.Period12
                        });
                    }
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert("Rulebase.ALB_Learner_Period", albLearnerPeriods, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.ALB_Learner_PeriodisedValues", albLearnerPeriodisedValues, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.ALB_LearningDelivery", albLearningDeliveries, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.ALB_LearningDelivery_Period", albLearningDeliveryPeriods, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.ALB_LearningDelivery_PeriodisedValues", albLearningDeliveryPeriodisedValues, sqlTransaction, cancellationToken);
        }

        private async void StoreGlobal(SqlConnection connection, SqlTransaction sqlTransaction, CancellationToken cancellationToken, ALB_global albGlobal)
        {
            await _bulkInsert.Insert("Rulebase.ALB_global", new List<ALB_global> { albGlobal }, sqlTransaction, cancellationToken);
        }

        private decimal? GetPeriodValue(LearnerPeriodisedValue attr, int period)
        {
            switch (period)
            {
                case 0:
                    return attr.Period1;
                case 1:
                    return attr.Period2;
                case 2:
                    return attr.Period3;
                case 3:
                    return attr.Period4;
                case 4:
                    return attr.Period5;
                case 5:
                    return attr.Period6;
                case 6:
                    return attr.Period7;
                case 7:
                    return attr.Period8;
                case 8:
                    return attr.Period9;
                case 9:
                    return attr.Period10;
                case 10:
                    return attr.Period11;
                default:
                    return attr.Period12;
            }
        }

        private decimal? GetPeriodValue(LearningDeliveryPeriodisedValue attr, int period)
        {
            switch (period)
            {
                case 0:
                    return attr.Period1;
                case 1:
                    return attr.Period2;
                case 2:
                    return attr.Period3;
                case 3:
                    return attr.Period4;
                case 4:
                    return attr.Period5;
                case 5:
                    return attr.Period6;
                case 6:
                    return attr.Period7;
                case 7:
                    return attr.Period8;
                case 8:
                    return attr.Period9;
                case 9:
                    return attr.Period10;
                case 10:
                    return attr.Period11;
                default:
                    return attr.Period12;
            }
        }
    }
}
