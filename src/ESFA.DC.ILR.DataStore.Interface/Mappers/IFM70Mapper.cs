using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IFM70Mapper
    {
        FM70Data MapData(FM70Global fm70Global);

        IEnumerable<ESF_global> MapGlobals(FM70Global fm70Global);

        IEnumerable<ESF_Learner> MapLearners(FM70Global fm70Global);

        IEnumerable<ESF_DPOutcome> MapDPOutcomes(FM70Global fm70Global);

        IEnumerable<ESF_LearningDelivery> MapLearningDeliveries(FM70Global fm70Global);

        IEnumerable<ESF_LearningDeliveryDeliverable> MapLearningDeliveryDeliverables(FM70Global fm70Global);

        IEnumerable<ESF_LearningDeliveryDeliverable_Period> MapLearningDeliveryDeliverablePeriods(FM70Global fm70Global);

        IEnumerable<ESF_LearningDeliveryDeliverable_PeriodisedValue> MapLearningDeliveryDeliverablePeriodisedValues(FM70Global fm70Global);
    }
}
