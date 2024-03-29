﻿using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class TBLLearnerClassMap : DefaultTableClassMap<TBL_Learner>
    {
        public TBLLearnerClassMap()
        {
            Map(m => m.TBL_LearningDeliveries).Ignore();
            Map(m => m.UKPRNNavigation).Ignore();
            Map(m => m.Learner).Ignore();
        }
    }
}
