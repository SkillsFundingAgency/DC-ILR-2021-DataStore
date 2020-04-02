﻿using ESFA.DC.ILR2021.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerDestinationandProgressionClassMap : DefaultTableClassMap<LearnerDestinationandProgression>
    {
        public ValidLearnerDestinationandProgressionClassMap()
        {
            Map(m => m.DPOutcomes).Ignore();
        }
    }
}
