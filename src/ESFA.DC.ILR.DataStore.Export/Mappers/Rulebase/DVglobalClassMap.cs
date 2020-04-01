using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class DVglobalClassMap : DefaultTableClassMap<DV_global>
    {
        public DVglobalClassMap()
        {
            Map(m => m.DV_Learners).Ignore();
        }
    }
}
