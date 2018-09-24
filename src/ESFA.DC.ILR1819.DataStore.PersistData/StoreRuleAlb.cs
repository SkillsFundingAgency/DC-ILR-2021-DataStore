﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Attribute;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreRuleAlb : IStoreRuleAlb
    {
        public async Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, ALBFundingOutputs fundingOutputs, CancellationToken cancellationToken)
        {
            List<ALB_Learner_Period> albLearnerPeriods = new List<ALB_Learner_Period>(fundingOutputs.Learners.Length * 12);
            List<ALB_Learner_PeriodisedValues> albLearnerPeriodisedValues = new List<ALB_Learner_PeriodisedValues>(fundingOutputs.Learners.Length);
            List<ALB_LearningDelivery> albLearningDeliveries = new List<ALB_LearningDelivery>(fundingOutputs.Learners.Length);
            List<ALB_LearningDelivery_Period> albLearningDeliveryPeriods = new List<ALB_LearningDelivery_Period>(fundingOutputs.Learners.Length * 12);
            List<ALB_LearningDelivery_PeriodisedValues> albLearningDeliveryPeriodisedValues = new List<ALB_LearningDelivery_PeriodisedValues>(fundingOutputs.Learners.Length);

            ALB_global albGlobal = new ALB_global
            {
                UKPRN = ukPrn,
                LARSVersion = fundingOutputs.Global.LARSVersion,
                PostcodeAreaCostVersion = fundingOutputs.Global.PostcodeAreaCostVersion,
                RulebaseVersion = fundingOutputs.Global.RulebaseVersion
            };

            foreach (var learnerAttribute in fundingOutputs.Learners)
            {
                var attr = learnerAttribute.LearnerPeriodisedAttributes.Single(x => x.AttributeName == "ALBSeqNum");

                for (int i = 0; i < 12; i++)
                {
                    albLearnerPeriods.Add(new ALB_Learner_Period
                    {
                        LearnRefNumber = learnerAttribute.LearnRefNumber,
                        UKPRN = ukPrn,
                        ALBSeqNum = (int)GetPeriodValue(attr, i),
                        Period = i + 1
                    });
                }

                albLearnerPeriodisedValues.Add(new ALB_Learner_PeriodisedValues
                {
                    LearnRefNumber = learnerAttribute.LearnRefNumber,
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

                foreach (var learnerAttributeLearningDeliveryAttribute in learnerAttribute.LearningDeliveryAttributes)
                {
                    albLearningDeliveries.Add(new ALB_LearningDelivery
                    {
                        LearnRefNumber = learnerAttribute.LearnRefNumber,
                        UKPRN = ukPrn,
                        AimSeqNumber = learnerAttributeLearningDeliveryAttribute.AimSeqNumber,
                        Achieved = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.Achieved,
                        ActualNumInstalm = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.ActualNumInstalm,
                        AdvLoan = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.AdvLoan,
                        ApplicFactDate = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.ApplicFactDate,
                        ApplicProgWeightFact = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.ApplicProgWeightFact,
                        AreaCostFactAdj = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.AreaCostFactAdj,
                        AreaCostInstalment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.AreaCostInstalment,
                        FundLine = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.FundLine,
                        FundStart = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.FundStart,
                        LiabilityDate = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.LiabilityDate,
                        LoanBursAreaUplift = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.LoanBursAreaUplift,
                        LoanBursSupp = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.LoanBursSupp,
                        OutstndNumOnProgInstalm = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.OutstndNumOnProgInstalm,
                        PlannedNumOnProgInstalm = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.PlannedNumOnProgInstalm,
                        WeightedRate = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.WeightedRate,
                        LearnDelApplicSubsidyPilotAreaCode = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.LearnDelApplicSubsidyPilotAreaCode,
                        LearnDelEligCareerLearnPilot = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.LearnDelEligCareerLearnPilot,
                        LearnDelApplicLARSCarPilFundSubRate = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.LearnDelApplicLARSCarPilFundSubRate,
                        LearnDelCarLearnPilotAimValue = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.LearnDelCarLearnPilotAimValue,
                        LearnDelCarLearnPilotInstalAmount = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.LearnDelCarLearnPilotInstalAmount
                    });

                    var albCode = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.SingleOrDefault(x => x.AttributeName == "ALBCode");
                    var albSupportPayment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.SingleOrDefault(x => x.AttributeName == "ALBSupportPayment");
                    var albAreaUpliftBalPayment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.SingleOrDefault(x => x.AttributeName == "AreaUpliftBalPayment");
                    var albAreaUpliftOnProgPayment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.SingleOrDefault(x => x.AttributeName == "AreaUpliftOnProgPayment");
                    var albLearnDelCarLearnPilotBalPayment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.SingleOrDefault(x => x.AttributeName == "LearnDelCarLearnPilotBalPayment");
                    var albLearnDelCarLearnPilotOnProgPayment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.SingleOrDefault(x => x.AttributeName == "LearnDelCarLearnPilotOnProgPayment");

                    for (int i = 0; i < 12; i++)
                    {
                        albLearningDeliveryPeriods.Add(new ALB_LearningDelivery_Period
                        {
                            LearnRefNumber = learnerAttribute.LearnRefNumber,
                            UKPRN = ukPrn,
                            AimSeqNumber = learnerAttributeLearningDeliveryAttribute.AimSeqNumber,
                            Period = i + 1,
                            ALBCode = albCode == null ? 0 : (int)GetPeriodValue(albCode, i),
                            ALBSupportPayment = albSupportPayment == null ? 0 : (int)GetPeriodValue(albSupportPayment, i),
                            AreaUpliftBalPayment = albAreaUpliftBalPayment == null ? 0 : (int)GetPeriodValue(albAreaUpliftBalPayment, i),
                            AreaUpliftOnProgPayment = albAreaUpliftOnProgPayment == null ? 0 : (int)GetPeriodValue(albAreaUpliftOnProgPayment, i),
                            LearnDelCarLearnPilotBalPayment = albLearnDelCarLearnPilotBalPayment == null ? 0 : (int)GetPeriodValue(albLearnDelCarLearnPilotBalPayment, i),
                            LearnDelCarLearnPilotOnProgPayment = albLearnDelCarLearnPilotOnProgPayment == null ? 0 : (int)GetPeriodValue(albLearnDelCarLearnPilotOnProgPayment, i)
                        });
                    }

                    foreach (var learningDeliveryPeriodisedAttribute in learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes)
                    {
                        albLearningDeliveryPeriodisedValues.Add(new ALB_LearningDelivery_PeriodisedValues
                        {
                            LearnRefNumber = learnerAttribute.LearnRefNumber,
                            UKPRN = ukPrn,
                            AimSeqNumber = learnerAttributeLearningDeliveryAttribute.AimSeqNumber,
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

            using (var bulkInsert = new BulkInsert(connection, transaction, cancellationToken))
            {
                await bulkInsert.Insert("Rulebase.ALB_global", new List<ALB_global> { albGlobal });
                await bulkInsert.Insert("Rulebase.ALB_Learner_Period", albLearnerPeriods);
                await bulkInsert.Insert("Rulebase.ALB_Learner_PeriodisedValues", albLearnerPeriodisedValues);
                await bulkInsert.Insert("Rulebase.ALB_LearningDelivery", albLearningDeliveries);
                await bulkInsert.Insert("Rulebase.ALB_LearningDelivery_Period", albLearningDeliveryPeriods);
                await bulkInsert.Insert("Rulebase.ALB_LearningDelivery_PeriodisedValues", albLearningDeliveryPeriodisedValues);
            }
        }

        private decimal GetPeriodValue(LearnerPeriodisedAttribute attr, int period)
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

        private decimal GetPeriodValue(LearningDeliveryPeriodisedAttribute attr, int period)
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
