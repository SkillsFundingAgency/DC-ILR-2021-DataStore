using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IALBMapper
    {
        ALBData MapALBData(ALBGlobal albGlobal);

        IEnumerable<ALB_global> MapGlobals(ALBGlobal albGlobal);

        IEnumerable<ALB_Learner> MapLearners(ALBGlobal albGlobal);

        IEnumerable<ALB_Learner_Period> MapLearnerPeriods(ALBGlobal albGlobal);

        IEnumerable<ALB_Learner_PeriodisedValue> MapLearnerPeriodisedValues(ALBGlobal albGlobal);

        IEnumerable<ALB_LearningDelivery> MapLearningDeliveries(ALBGlobal albGlobal);

        IEnumerable<ALB_LearningDelivery_Period> MapLearningDeliveryPeriods(ALBGlobal albGlobal);

        IEnumerable<ALB_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(ALBGlobal albGlobal);
    }
}
