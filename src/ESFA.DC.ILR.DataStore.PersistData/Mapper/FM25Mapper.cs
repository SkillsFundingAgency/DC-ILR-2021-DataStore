using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class FM25Mapper : IFM25Mapper
    {
        public FM25Data MapData(FM25Global fm25Global)
        {
            var data = new FM25Data();

            if (fm25Global.Learners != null)
            {
                data.Globals = MapFM25Global(fm25Global).ToList();
                data.Learners = MapFM25Learners(fm25Global).ToList();
                data.Fm25Fm35Globals = MapFM25_35_Global(fm25Global).ToList();
                data.Fm25Fm35LearnerPeriods = MapFM25_35_LearnerPeriod(fm25Global).ToList();
                data.Fm25Fm35LearnerPeriodisedValues = MapFM25_35_LearnerPeriodisedValues(fm25Global).ToList();
            }

            return data;
        }

        public IEnumerable<FM25_global> MapFM25Global(FM25Global fm25Global)
        {
            return new List<FM25_global>()
            {
                new FM25_global
                {
                    UKPRN = fm25Global.UKPRN.Value,
                    LARSVersion = fm25Global.LARSVersion,
                    OrgVersion = fm25Global.OrgVersion,
                    PostcodeDisadvantageVersion = fm25Global.PostcodeDisadvantageVersion,
                    RulebaseVersion = fm25Global.RulebaseVersion
                }
            };
        }

        public IEnumerable<FM25_Learner> MapFM25Learners(FM25Global fm25Global)
        {
            return fm25Global.Learners.Select(l => new FM25_Learner
            {
                UKPRN = fm25Global.UKPRN.Value,
                LearnRefNumber = l.LearnRefNumber,
                AcadMonthPayment = l.AcadMonthPayment,
                OnProgPayment = l.OnProgPayment,
                AcadProg = l.AcadProg,
                ActualDaysILCurrYear = l.ActualDaysILCurrYear,
                AreaCostFact1618Hist = l.AreaCostFact1618Hist,
                Block1DisadvUpliftNew = l.Block1DisadvUpliftNew,
                Block2DisadvElementsNew = l.Block2DisadvElementsNew,
                ConditionOfFundingEnglish = l.ConditionOfFundingEnglish,
                ConditionOfFundingMaths = l.ConditionOfFundingMaths,
                CoreAimSeqNumber = l.CoreAimSeqNumber,
                FullTimeEquiv = l.FullTimeEquiv,
                FundLine = l.FundLine,
                LearnerActEndDate = l.LearnerActEndDate,
                LearnerPlanEndDate = l.LearnerPlanEndDate,
                LearnerStartDate = l.LearnerStartDate,
                NatRate = l.NatRate,
                PlannedDaysILCurrYear = l.PlannedDaysILCurrYear,
                ProgWeightHist = l.ProgWeightHist,
                ProgWeightNew = l.ProgWeightNew,
                PrvDisadvPropnHist = l.PrvDisadvPropnHist,
                PrvHistLrgProgPropn = l.PrvHistLrgProgPropn,
                PrvRetentFactHist = l.PrvRetentFactHist,
                RateBand = l.RateBand,
                RetentNew = l.RetentNew,
                StartFund = l.StartFund,
                ThresholdDays = l.ThresholdDays
            });
        }

        public IEnumerable<FM25_FM35_global> MapFM25_35_Global(FM25Global fm25Global)
        {
            return new List<FM25_FM35_global>()
            {
                new FM25_FM35_global
                {
                    UKPRN = fm25Global.UKPRN.Value,
                    RulebaseVersion = fm25Global.RulebaseVersion
                }
            };
        }

        public IEnumerable<FM25_FM35_Learner_Period> MapFM25_35_LearnerPeriod(FM25Global fm25Global)
        {
            return fm25Global.Learners.SelectMany(l => l.LearnerPeriods.Select(lp => new FM25_FM35_Learner_Period
            {
                UKPRN = fm25Global.UKPRN.Value,
                LearnRefNumber = l.LearnRefNumber,
                Period = lp.Period.Value,
                LnrOnProgPay = lp.LnrOnProgPay
            }));
        }

        public IEnumerable<FM25_FM35_Learner_PeriodisedValue> MapFM25_35_LearnerPeriodisedValues(FM25Global fm25Global)
        {
            return
                  fm25Global.Learners.SelectMany(l => l.LearnerPeriodisedValues.Select(lpv =>
                  new FM25_FM35_Learner_PeriodisedValue
                  {
                      UKPRN = fm25Global.UKPRN.Value,
                      LearnRefNumber = l.LearnRefNumber,
                      AttributeName = lpv.AttributeName,
                      Period_1 = lpv.Period1,
                      Period_2 = lpv.Period2,
                      Period_3 = lpv.Period3,
                      Period_4 = lpv.Period4,
                      Period_5 = lpv.Period5,
                      Period_6 = lpv.Period6,
                      Period_7 = lpv.Period7,
                      Period_8 = lpv.Period8,
                      Period_9 = lpv.Period9,
                      Period_10 = lpv.Period10,
                      Period_11 = lpv.Period11,
                      Period_12 = lpv.Period12
                  }));
        }
    }
}