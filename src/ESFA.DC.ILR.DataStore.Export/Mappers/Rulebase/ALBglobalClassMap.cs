using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBglobalClassMap : DefaultTableClassMap<ALB_global>
    {
        public ALBglobalClassMap()
        {
            Map(m => m.ALB_Learners).Ignore();
        }
    }
}
