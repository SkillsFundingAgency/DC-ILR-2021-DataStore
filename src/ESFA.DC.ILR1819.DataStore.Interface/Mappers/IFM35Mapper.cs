using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IFM35Mapper
    {
        FM35Data MapData(FM35Global fm35Global);

        IEnumerable<FM35_global> MapGlobals(FM35Global fm35Global);

        IEnumerable<FM35_Learner> MapLearners(FM35Global fm35Global);

        IEnumerable<FM35_LearningDelivery> MapLearningDeliveries(FM35Global fm35Global);

        IEnumerable<FM35_LearningDelivery_Period> MapLearningDeliveryPeriods(FM35Global fm35Global);

        IEnumerable<FM35_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(FM35Global fm35Global);
    }
}
