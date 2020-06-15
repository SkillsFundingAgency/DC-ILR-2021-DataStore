﻿using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryWorkPlacementClassMap : DefaultTableClassMap<LearningDeliveryWorkPlacement>
    {
        public ValidLearningDeliveryWorkPlacementClassMap()
        {
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
