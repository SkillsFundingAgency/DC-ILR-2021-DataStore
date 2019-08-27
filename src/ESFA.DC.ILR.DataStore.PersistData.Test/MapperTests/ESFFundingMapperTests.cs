using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test.MapperTests
{
    public class ESFFundingMapperTests
    {
        [Fact]
        public void BuildFundingData()
        {
            var dataStoreContextMock = new Mock<IDataStoreContext>();
            dataStoreContextMock.Setup(ds => ds.CollectionYear).Returns("1920");
            dataStoreContextMock.Setup(ds => ds.ReturnPeriod).Returns("01");

            var learningDeliveryDeliverablePeriodisedValue = new LearningDeliveryDeliverablePeriodisedValue()
            {
                AttributeName = "AttributeName",
                Period1 = 1,
                Period2 = 2,
                Period3 = 3,
                Period4 = 4,
                Period5 = 5,
                Period6 = 6,
                Period7 = 7,
                Period8 = 8,
                Period9 = 9,
                Period10 = 10,
                Period11 = 11,
                Period12 = 12,
            };

            var ukprn = 1234;
            var aimSeqNumber = 5678;
            var learnRefNumber = "LearnRefNumber";
            var deliverableCode = "DeliverableCode";
            var conRefNumber = "ConRefNumber";
            var academicYear = "2019/20";
            var collectionReturnCode = "R01";
            var collectionType = "ILR1920";

            var conRefNumberDictionary = new Dictionary<string, Dictionary<int, string>>();

            var conRefNumberInnerDictionary = new Dictionary<int, string>
            {
                {
                    aimSeqNumber, conRefNumber
                },
            };

            conRefNumberDictionary.Add(learnRefNumber, conRefNumberInnerDictionary);

            var esfFundingData = Mapper().BuildFundingData(dataStoreContextMock.Object, learningDeliveryDeliverablePeriodisedValue, conRefNumberDictionary, ukprn, aimSeqNumber, learnRefNumber, deliverableCode, academicYear, collectionReturnCode, collectionType);

            esfFundingData.UKPRN.Should().Be(ukprn);
            esfFundingData.LearnRefNumber.Should().Be(learnRefNumber);
            esfFundingData.AimSeqNumber.Should().Be(aimSeqNumber);
            esfFundingData.ConRefNumber.Should().Be(conRefNumber);
            esfFundingData.DeliverableCode.Should().Be(deliverableCode);
            esfFundingData.AttributeName.Should().Be("AttributeName");
            esfFundingData.Period_1.Should().Be(1);
            esfFundingData.Period_2.Should().Be(2);
            esfFundingData.Period_3.Should().Be(3);
            esfFundingData.Period_4.Should().Be(4);
            esfFundingData.Period_5.Should().Be(5);
            esfFundingData.Period_6.Should().Be(6);
            esfFundingData.Period_7.Should().Be(7);
            esfFundingData.Period_8.Should().Be(8);
            esfFundingData.Period_9.Should().Be(9);
            esfFundingData.Period_10.Should().Be(10);
            esfFundingData.Period_11.Should().Be(11);
            esfFundingData.Period_12.Should().Be(12);
            esfFundingData.AcademicYear.Should().Be("2019/20");
            esfFundingData.CollectionReturnCode.Should().Be("R01");
            esfFundingData.CollectionType.Should().Be("ILR1920");
        }

        private ESFFundingMapper Mapper() => new ESFFundingMapper();
    }
}
