﻿using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECLearnerClassMap : DefaultTableClassMap<AEC_Learner>
    {
        public AECLearnerClassMap()
        {
            Map(m => m.AEC_ApprenticeshipPriceEpisodes).Ignore();
            Map(m => m.AEC_LearningDeliveries).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
            Map(m => m.Learner).Ignore();
        }
    }
}
