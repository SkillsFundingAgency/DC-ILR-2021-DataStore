﻿using ESFA.DC.ILR2021.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryFAMClassMap : DefaultTableClassMap<LearningDeliveryFAM>
    {
        public ValidLearningDeliveryFAMClassMap()
        {
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
