using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class DVLearnerClassMap : DefaultTableClassMap<DV_Learner>
    {
        public DVLearnerClassMap()
        {
            Map(m => m.DV_LearningDeliveries).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
        }
    }
}
