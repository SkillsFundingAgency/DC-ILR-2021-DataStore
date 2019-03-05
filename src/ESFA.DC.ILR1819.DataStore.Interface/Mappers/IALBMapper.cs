using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Model.Funding;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IALBMapper
    {
        ALBData MapALBData(ALBGlobal albGlobal);

        IEnumerable<ALB_global> MapGlobals(ALBGlobal albGlobal);

        IEnumerable<ALB_Learner> MapLearners(ALBGlobal albGlobal);

        IEnumerable<ALB_Learner_Period> MapLearnerPeriods(ALBGlobal albGlobal);

        IEnumerable<ALB_Learner_PeriodisedValues> MapLearnerPeriodisedValues(ALBGlobal albGlobal);

        IEnumerable<ALB_LearningDelivery> MapLearningDeliveries(ALBGlobal albGlobal);

        IEnumerable<ALB_LearningDelivery_Period> MapLearningDeliveryPeriods(ALBGlobal albGlobal);

        IEnumerable<ALB_LearningDelivery_PeriodisedValues> MapLearningDeliveryPeriodisedValues(ALBGlobal albGlobal);
    }
}
