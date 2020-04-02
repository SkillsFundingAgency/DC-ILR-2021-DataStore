using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearnerClassMap : DefaultTableClassMap<ALB_Learner>
    {
        public ALBLearnerClassMap()
        {
            Map(m => m.ALB_Learner_PeriodisedValues).Ignore();
            Map(m => m.ALB_Learner_Periods).Ignore();
            Map(m => m.ALB_LearningDeliveries).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
        }
    }
}
