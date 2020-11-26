using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25LearnerClassMap : DefaultTableClassMap<FM25_Learner>
    {
        public FM25LearnerClassMap()
        {
            Map(m => m.FM25_FM35_Learner_PeriodisedValues).Ignore();
            Map(m => m.FM25_FM35_Learner_Periods).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
            Map(m => m.Learner).Ignore();
        }
    }
}
