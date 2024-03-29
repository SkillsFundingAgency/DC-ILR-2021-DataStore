﻿using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearningDeliveryDeliverablePeriodisedValuesClassMap : DefaultTableClassMap<ESF_LearningDeliveryDeliverable_PeriodisedValue>
    {
        public ESFLearningDeliveryDeliverablePeriodisedValuesClassMap()
        {
            Map(m => m.ESF_LearningDeliveryDeliverable).Ignore();
        }
    }
}
