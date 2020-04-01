using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25FM35LearnerPeriodClassMap : DefaultTableClassMap<FM25_FM35_Learner_Period>
    {
        public FM25FM35LearnerPeriodClassMap()
        {
            Map(m => m.FM25_Learner).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
        }
    }
}
