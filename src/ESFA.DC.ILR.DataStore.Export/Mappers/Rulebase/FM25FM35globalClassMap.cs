using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25FM35globalClassMap : DefaultTableClassMap<FM25_FM35_global>
    {
        public FM25FM35globalClassMap()
        {
            Map(m => m.FM25_FM35_Learner_PeriodisedValues).Ignore();
            Map(m => m.FM25_FM35_Learner_Periods).Ignore();
        }
    }
}
