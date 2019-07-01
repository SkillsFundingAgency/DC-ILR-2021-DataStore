using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class FM25Mapper : IFM25Mapper
    {
        public IDataStoreCache MapData(FM25Global fm25Global)
        {
            var cache = new DataStoreCache();
            var learners = fm25Global.Learners;

            if (learners == null)
            {
                return cache;
            }

            var ukprn = fm25Global.UKPRN.Value;

            return PopulateDataStoreCache(cache, learners, fm25Global, ukprn);
        }

        private IDataStoreCache PopulateDataStoreCache(DataStoreCache dataCache, IEnumerable<FM25Learner> learners, FM25Global fm25Global, int ukprn)
        {
            dataCache.AddRange(BuildFM25Global(fm25Global, ukprn));
            dataCache.AddRange(BuildFM25_35_Global(fm25Global, ukprn));

            learners.NullSafeForEach(learner =>
            {
                var learnRefNumber = learner.LearnRefNumber;

                dataCache.Add(BuildFM25Learner(ukprn, learner));
                learner.LearnerPeriods.NullSafeForEach(learnerPeriod => dataCache.Add(BuildFM25_35_LearnerPeriod(learnerPeriod, ukprn, learnRefNumber)));
                learner.LearnerPeriodisedValues.NullSafeForEach(learnerPV => dataCache.Add(BuildFM25_35_LearnerPeriodisedValues(learnerPV, ukprn, learnRefNumber)));
            });

            return dataCache;
        }

        public List<FM25_global> BuildFM25Global(FM25Global fm25Global, int ukprn)
        {
            return new List<FM25_global>()
            {
                new FM25_global
                {
                    UKPRN = ukprn,
                    LARSVersion = fm25Global.LARSVersion,
                    OrgVersion = fm25Global.OrgVersion,
                    PostcodeDisadvantageVersion = fm25Global.PostcodeDisadvantageVersion,
                    RulebaseVersion = fm25Global.RulebaseVersion
                }
            };
        }

        public FM25_Learner BuildFM25Learner(int ukprn, FM25Learner learner)
        {
            return new FM25_Learner
            {
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                AcadMonthPayment = learner.AcadMonthPayment,
                OnProgPayment = learner.OnProgPayment,
                AcadProg = learner.AcadProg,
                ActualDaysILCurrYear = learner.ActualDaysILCurrYear,
                AreaCostFact1618Hist = learner.AreaCostFact1618Hist,
                Block1DisadvUpliftNew = learner.Block1DisadvUpliftNew,
                Block2DisadvElementsNew = learner.Block2DisadvElementsNew,
                ConditionOfFundingEnglish = learner.ConditionOfFundingEnglish,
                ConditionOfFundingMaths = learner.ConditionOfFundingMaths,
                CoreAimSeqNumber = learner.CoreAimSeqNumber,
                FullTimeEquiv = learner.FullTimeEquiv,
                FundLine = learner.FundLine,
                LearnerActEndDate = learner.LearnerActEndDate,
                LearnerPlanEndDate = learner.LearnerPlanEndDate,
                LearnerStartDate = learner.LearnerStartDate,
                NatRate = learner.NatRate,
                PlannedDaysILCurrYear = learner.PlannedDaysILCurrYear,
                ProgWeightHist = learner.ProgWeightHist,
                ProgWeightNew = learner.ProgWeightNew,
                PrvDisadvPropnHist = learner.PrvDisadvPropnHist,
                PrvHistLrgProgPropn = learner.PrvHistLrgProgPropn,
                PrvRetentFactHist = learner.PrvRetentFactHist,
                RateBand = learner.RateBand,
                RetentNew = learner.RetentNew,
                StartFund = learner.StartFund,
                ThresholdDays = learner.ThresholdDays
            };
        }

        public List<FM25_FM35_global> BuildFM25_35_Global(FM25Global fm25Global, int ukprn)
        {
            return new List<FM25_FM35_global>()
            {
                new FM25_FM35_global
                {
                    UKPRN = ukprn,
                    RulebaseVersion = fm25Global.RulebaseVersion
                }
            };
        }

        public FM25_FM35_Learner_Period BuildFM25_35_LearnerPeriod(LearnerPeriod learnerPeriod, int ukprn, string learnRefNumber)
        {
            return new FM25_FM35_Learner_Period()
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                Period = learnerPeriod.Period.Value,
                LnrOnProgPay = learnerPeriod.LnrOnProgPay
            };
        }

        public FM25_FM35_Learner_PeriodisedValue BuildFM25_35_LearnerPeriodisedValues(LearnerPeriodisedValues learnerPeriodisedValues, int ukprn, string learnRefNumber)
        {
            return new FM25_FM35_Learner_PeriodisedValue()
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                AttributeName = learnerPeriodisedValues.AttributeName,
                Period_1 = learnerPeriodisedValues.Period1,
                Period_2 = learnerPeriodisedValues.Period2,
                Period_3 = learnerPeriodisedValues.Period3,
                Period_4 = learnerPeriodisedValues.Period4,
                Period_5 = learnerPeriodisedValues.Period5,
                Period_6 = learnerPeriodisedValues.Period6,
                Period_7 = learnerPeriodisedValues.Period7,
                Period_8 = learnerPeriodisedValues.Period8,
                Period_9 = learnerPeriodisedValues.Period9,
                Period_10 = learnerPeriodisedValues.Period10,
                Period_11 = learnerPeriodisedValues.Period11,
                Period_12 = learnerPeriodisedValues.Period12
            };
        }
    }
}