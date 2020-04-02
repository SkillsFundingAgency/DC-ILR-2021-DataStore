using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECglobalClassMap : DefaultTableClassMap<AEC_global>
    {
        public AECglobalClassMap()
        {
            Map(m => m.AEC_Learners).Ignore();
        }
    }
}
