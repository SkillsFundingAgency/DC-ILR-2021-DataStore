﻿using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerFAMClassMap : DefaultTableClassMap<LearnerFAM>
    {
        public ValidLearnerFAMClassMap()
        {
            Map(m => m.Learner).Ignore();
        }
    }
}
