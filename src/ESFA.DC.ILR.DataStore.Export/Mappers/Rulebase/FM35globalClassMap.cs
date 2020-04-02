using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35globalClassMap : DefaultTableClassMap<FM35_global>
    {
        public FM35globalClassMap()
        {
            Map(m => m.FM35_Learners).Ignore();
        }
    }
}
