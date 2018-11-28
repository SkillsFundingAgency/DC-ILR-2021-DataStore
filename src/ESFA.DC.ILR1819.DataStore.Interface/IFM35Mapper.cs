using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IFM35Mapper
    {
        FM35_global MapGlobal(FM35Global fm35Global);

        IEnumerable<FM35_Learner> MapLearners(FM35Global fm35Global);

        IEnumerable<FM35_LearningDelivery> MapLearningDeliveries(FM35Global fm35Global);

        IEnumerable<FM35_LearningDelivery_Period> MapLearningDeliveryPeriods(FM35Global fm35Global);

        IEnumerable<FM35_LearningDelivery_PeriodisedValues> MapLearningDeliveryPeriodisedValues(FM35Global fm35Global);
    }
}
