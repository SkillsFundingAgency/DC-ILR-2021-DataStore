using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearnerPeriodClassMap : DefaultTableClassMap<ALB_Learner_Period>
    {
        public ALBLearnerPeriodClassMap()
        {
            Map(m => m.ALB_Learner).Ignore();
        }
    }
}
