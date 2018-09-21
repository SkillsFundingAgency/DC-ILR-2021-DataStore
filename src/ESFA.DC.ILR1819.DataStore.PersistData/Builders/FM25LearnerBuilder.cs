using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class FM25LearnerBuilder
    {
        public static FM25_Learner BuildFm25Learner(int ukPrn, Learner learner)
        {
            return new FM25_Learner
            {
                UKPRN = ukPrn,
                AcadMonthPayment = learner.AcadMonthPayment,
                LearnRefNumber = learner.LearnRefNumber,
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
    }
}
