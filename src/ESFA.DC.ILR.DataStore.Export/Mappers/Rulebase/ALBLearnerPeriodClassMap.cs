﻿using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearnerPeriodClassMap : DefaultTableClassMap<ALB_Learner_Period>
    {
        public ALBLearnerPeriodClassMap()
        {
            Map(m => m.ALB_Learner).Ignore();
        }
    }
}
