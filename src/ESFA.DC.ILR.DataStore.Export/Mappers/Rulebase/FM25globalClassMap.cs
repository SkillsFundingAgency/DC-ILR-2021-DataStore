using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25globalClassMap : DefaultTableClassMap<FM25_global>
    {
        public FM25globalClassMap()
        {
            Map(m => m.FM25_Learners).Ignore();
        }
    }
}
