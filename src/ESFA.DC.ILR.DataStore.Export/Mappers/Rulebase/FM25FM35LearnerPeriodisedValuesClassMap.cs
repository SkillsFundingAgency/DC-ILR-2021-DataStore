using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25FM35LearnerPeriodisedValuesClassMap : DefaultTableClassMap<FM25_FM35_Learner_PeriodisedValue>
    {
        public FM25FM35LearnerPeriodisedValuesClassMap()
        {
            Map(m => m.FM25_Learner).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
        }
    }
}
