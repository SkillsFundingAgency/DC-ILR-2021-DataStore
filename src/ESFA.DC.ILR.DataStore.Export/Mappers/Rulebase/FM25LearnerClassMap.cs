using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25LearnerClassMap : ClassMap<FM25_Learner>
    {
        public FM25LearnerClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AcadMonthPayment);
            Map(m => m.AcadProg);
            Map(m => m.ActualDaysILCurrYear);
            Map(m => m.AreaCostFact1618Hist);
            Map(m => m.Block1DisadvUpliftNew);
            Map(m => m.Block2DisadvElementsNew);
            Map(m => m.ConditionOfFundingEnglish);
            Map(m => m.ConditionOfFundingMaths);
            Map(m => m.CoreAimSeqNumber);
            Map(m => m.FullTimeEquiv);
            Map(m => m.FundLine);
            Map(m => m.LearnerActEndDate);
            Map(m => m.LearnerPlanEndDate);
            Map(m => m.LearnerStartDate);
            Map(m => m.NatRate);
            Map(m => m.OnProgPayment);
            Map(m => m.PlannedDaysILCurrYear);
            Map(m => m.ProgWeightHist);
            Map(m => m.ProgWeightNew);
            Map(m => m.PrvDisadvPropnHist);
            Map(m => m.PrvHistLrgProgPropn);
            Map(m => m.PrvRetentFactHist);
            Map(m => m.RateBand);
            Map(m => m.RetentNew);
            Map(m => m.StartFund);
            Map(m => m.ThresholdDays);
        }
    }
}
