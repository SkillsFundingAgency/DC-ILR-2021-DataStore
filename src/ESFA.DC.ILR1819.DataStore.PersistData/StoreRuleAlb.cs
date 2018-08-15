using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Interface.Attribute;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreRuleAlb : IStoreRuleAlb
    {
        private readonly SqlConnection _connection;

        private readonly SqlTransaction _transaction;

        public StoreRuleAlb(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task StoreAsync(int ukPrn, FundingOutputs fundingOutputs, CancellationToken cancellationToken)
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

            foreach (ILearnerAttribute learnerAttribute in fundingOutputs.Learners)
            {
                ILearnerPeriodisedAttribute attr = learnerAttribute.LearnerPeriodisedAttributes.Single(x => x.AttributeName == "ALBSeqNum");
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

                foreach (ILearningDeliveryAttribute learnerAttributeLearningDeliveryAttribute in learnerAttribute.LearningDeliveryAttributes)
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
                        WeightedRate = learnerAttributeLearningDeliveryAttribute.LearningDeliveryAttributeDatas.WeightedRate
                    });

                    ILearningDeliveryPeriodisedAttribute albCode = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.Single(x => x.AttributeName == "ALBCode");
                    ILearningDeliveryPeriodisedAttribute albSupportPayment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.Single(x => x.AttributeName == "ALBSupportPayment");
                    ILearningDeliveryPeriodisedAttribute albAreaUpliftBalPayment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.Single(x => x.AttributeName == "AreaUpliftBalPayment");
                    ILearningDeliveryPeriodisedAttribute albAreaUpliftOnProgPayment = learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes.Single(x => x.AttributeName == "AreaUpliftOnProgPayment");
                    for (int i = 0; i < 12; i++)
                    {
                        albLearningDeliveryPeriods.Add(new ALB_LearningDelivery_Period
                        {
                            LearnRefNumber = learnerAttribute.LearnRefNumber,
                            UKPRN = ukPrn,
                            AimSeqNumber = learnerAttributeLearningDeliveryAttribute.AimSeqNumber,
                            Period = i + 1,
                            ALBCode = (int)GetPeriodValue(albCode, i),
                            ALBSupportPayment = (int)GetPeriodValue(albSupportPayment, i),
                            AreaUpliftBalPayment = (int)GetPeriodValue(albAreaUpliftBalPayment, i),
                            AreaUpliftOnProgPayment = (int)GetPeriodValue(albAreaUpliftOnProgPayment, i),
                        });
                    }

                    foreach (ILearningDeliveryPeriodisedAttribute learningDeliveryPeriodisedAttribute in learnerAttributeLearningDeliveryAttribute.LearningDeliveryPeriodisedAttributes)
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

            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("Rulebase.ALB_global", new List<ALB_global> { albGlobal });
                await bulkInsert.Insert("Rulebase.ALB_Learner_Period", albLearnerPeriods);
                await bulkInsert.Insert("Rulebase.ALB_Learner_PeriodisedValues", albLearnerPeriodisedValues);
                await bulkInsert.Insert("Rulebase.ALB_LearningDelivery", albLearningDeliveries);
                await bulkInsert.Insert("Rulebase.ALB_LearningDelivery_Period", albLearningDeliveryPeriods);
                await bulkInsert.Insert("Rulebase.ALB_LearningDelivery_PeriodisedValues", albLearningDeliveryPeriodisedValues);
            }
        }

        private decimal GetPeriodValue(ILearnerPeriodisedAttribute attr, int period)
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

        private decimal GetPeriodValue(ILearningDeliveryPeriodisedAttribute attr, int period)
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
