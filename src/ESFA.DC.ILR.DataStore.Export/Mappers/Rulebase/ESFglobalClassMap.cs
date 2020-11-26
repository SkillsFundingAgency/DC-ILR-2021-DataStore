using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFglobalClassMap : DefaultTableClassMap<ESF_global>
    {
        public ESFglobalClassMap()
        {
            Map(m => m.ESF_Learners).Ignore();
        }
    }
}
