using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;

namespace ESFA.DC.ILR.DataStore.PersistData.Model
{
    public struct FundModel36LearningDeliveryPeriodisedValue
    {
        public FundModel36LearningDeliveryPeriodisedValue(int ukprn, string learnRefNumber, int aimSeqNumber, IEnumerable<LearningDeliveryPeriodisedValues> learningDeliveryPeriodisedValue, IEnumerable<LearningDeliveryPeriodisedTextValues> learningDeliveryPeriodisedTextValue)
        {
            Ukprn = ukprn;
            LearnRefNumber = learnRefNumber;
            AimSeqNumber = aimSeqNumber;
            LearningDeliveryPeriodisedValue = learningDeliveryPeriodisedValue;
            LearningDeliveryPeriodisedTextValue = learningDeliveryPeriodisedTextValue;
        }

        public int Ukprn { get; }

        public string LearnRefNumber { get; }

        public int AimSeqNumber { get; }

        public IEnumerable<LearningDeliveryPeriodisedValues> LearningDeliveryPeriodisedValue { get; }

        public IEnumerable<LearningDeliveryPeriodisedTextValues> LearningDeliveryPeriodisedTextValue { get; }
    }
}
