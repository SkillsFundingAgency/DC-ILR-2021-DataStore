using ESFA.DC.ILR2021.DataStore.EF;

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
