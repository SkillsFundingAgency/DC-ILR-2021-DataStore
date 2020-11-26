using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearnerClassMap : DefaultTableClassMap<ESF_Learner>
    {
        public ESFLearnerClassMap()
        {
            Map(m => m.ESF_LearningDeliveries).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
            Map(m => m.Learner).Ignore();
        }
    }
}
