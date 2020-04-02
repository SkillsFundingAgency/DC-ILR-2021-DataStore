using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35LearnerClassMap : DefaultTableClassMap<FM35_Learner>
    {
        public FM35LearnerClassMap()
        {
            Map(m => m.FM35_LearningDeliveries).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
        }
    }
}
