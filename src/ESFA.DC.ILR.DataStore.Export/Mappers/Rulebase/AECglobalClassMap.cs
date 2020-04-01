using ESFA.DC.ILR1920.DataStore.EF;

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
