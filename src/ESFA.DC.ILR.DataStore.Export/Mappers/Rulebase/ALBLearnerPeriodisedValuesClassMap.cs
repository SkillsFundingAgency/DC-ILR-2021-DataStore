using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearnerPeriodisedValuesClassMap : DefaultTableClassMap<ALB_Learner_PeriodisedValue>
    {
        public ALBLearnerPeriodisedValuesClassMap()
        {
            Map(m => m.ALB_Learner).Ignore();
        }
    }
}
