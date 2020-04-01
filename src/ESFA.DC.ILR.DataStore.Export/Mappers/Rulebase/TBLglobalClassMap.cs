using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class TBLglobalClassMap : DefaultTableClassMap<TBL_global>
    {
        public TBLglobalClassMap()
        {
            Map(m => m.TBL_Learners).Ignore();
        }
    }
}
