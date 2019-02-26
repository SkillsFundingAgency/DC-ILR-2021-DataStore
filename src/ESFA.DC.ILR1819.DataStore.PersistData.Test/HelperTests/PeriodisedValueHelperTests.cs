using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
