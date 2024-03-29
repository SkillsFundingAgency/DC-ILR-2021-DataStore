﻿using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidDPOutcomeClassMap : DefaultTableClassMap<DPOutcome>
    {
        public ValidDPOutcomeClassMap()
        {
            Map(m => m.LearnerDestinationandProgression).Ignore();
        }
    }
}
