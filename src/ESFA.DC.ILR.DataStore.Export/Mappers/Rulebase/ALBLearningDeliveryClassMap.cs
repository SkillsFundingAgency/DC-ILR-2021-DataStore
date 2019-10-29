using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearningDeliveryClassMap : ClassMap<ALB_LearningDelivery>
    {
        public ALBLearningDeliveryClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.AreaCostFactAdj);
            Map(m => m.WeightedRate);
            Map(m => m.PlannedNumOnProgInstalm);
            Map(m => m.FundStart);
            Map(m => m.Achieved);
            Map(m => m.ActualNumInstalm);
            Map(m => m.OutstndNumOnProgInstalm);
            Map(m => m.AreaCostInstalment);
            Map(m => m.AdvLoan);
            Map(m => m.LoanBursAreaUplift);
            Map(m => m.LoanBursSupp);
            Map(m => m.FundLine);
            Map(m => m.LiabilityDate);
            Map(m => m.ApplicProgWeightFact);
            Map(m => m.ApplicFactDate);
        }
    }
}
