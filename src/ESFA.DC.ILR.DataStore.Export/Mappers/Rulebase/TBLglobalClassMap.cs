using ESFA.DC.ILR2021.DataStore.EF;

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
