using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.HelperTests
{
    public class PeriodisedValueHelperTests
    {
        [Fact]
        public void LearningDeliveryPeriodisedValue()
        {
            var learningDeliveryPeriodisedValue = new LearningDeliveryPeriodisedValue();

            learningDeliveryPeriodisedValue.Period1 = 1.1m;

            PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(learningDeliveryPeriodisedValue, 1).Should().Be(1.1m);
        }

        [Fact]
        public void LearningDeliveryPeriodisedValue_PerformanceTest()
        {
            var learningDeliveryPeriodisedValue = new LearningDeliveryPeriodisedValue();

            learningDeliveryPeriodisedValue.Period1 = 1.1m;

            for (int i = 0; i < 10000000; i++)
            {
                PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(learningDeliveryPeriodisedValue, 1);
            }
        }
    }
}
