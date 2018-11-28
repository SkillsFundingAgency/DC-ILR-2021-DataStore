using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Model
{
    public struct FundModelPeriodisedValue<T>
    {
        public FundModelPeriodisedValue(int ukprn, string learnRefNumber, int aimSeqNumber, T learningDeliveryPeriodisedValue)
        {
            Ukprn = ukprn;
            LearnRefNumber = learnRefNumber;
            AimSeqNumber = aimSeqNumber;
            LearningDeliveryPeriodisedValue = learningDeliveryPeriodisedValue;
        }

        public int Ukprn { get; }

        public string LearnRefNumber { get; }

        public int AimSeqNumber { get; }

        public T LearningDeliveryPeriodisedValue { get; }
    }
}
