using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IFM81Mapper
    {
        FM81Data MapData(FM81Global fm81Global);

        IEnumerable<TBL_global> MapGlobals(FM81Global fm81Global);

        IEnumerable<TBL_Learner> MapLearners(FM81Global fm81Global);

        IEnumerable<TBL_LearningDelivery> MapLearningDeliveries(FM81Global fm81Global);

        IEnumerable<TBL_LearningDelivery_Period> MapLearningDeliveryPeriods(FM81Global fm81Global);

        IEnumerable<TBL_LearningDelivery_PeriodisedValues> MapLearningDeliveryPeriodisedValues(FM81Global fm81Global);
    }
}
