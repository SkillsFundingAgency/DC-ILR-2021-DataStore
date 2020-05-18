using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ESF.FundingData.Database.EF;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class ESFFundingMapper : IESFFundingMapper
    {
        public void MapData(IDataStoreCache cache, IDataStoreContext dataStoreContext, IMessage message, FM70Global fm70Global)
        {
            var learners = fm70Global?.Learners;

            var ukprn = fm70Global.UKPRN;

            PopulateDataStoreCache(cache, dataStoreContext, message, learners, ukprn);
        }

        private void PopulateDataStoreCache(IDataStoreCache cache, IDataStoreContext dataStoreContext, IMessage message, IEnumerable<FM70Learner> learners, int ukprn)
        {
            var academicYear = $"20{dataStoreContext.CollectionYear.Substring(0, 2)}/{dataStoreContext.CollectionYear.Substring(2, 2)}";
            var collectionReturnCode = dataStoreContext.CollectionPeriod;
            var collectionType = $"ILR{dataStoreContext.CollectionYear}";

            cache.Add(BuildLatestProviderSubmission(ukprn, collectionReturnCode, collectionType));

            if (learners == null)
            {
                return;
            }

            var conRefNumberDictionary = BuildConRefNumberDictionary(message);

            var learningDeliveryPeriodisedValues = 
                learners
                    .SelectMany(l => l.LearningDeliveries
                        .SelectMany(ld => ld.LearningDeliveryDeliverableValues
                            .Select(ldd => new FundModelESFLearningDeliveryPeriodisedValue<List<LearningDeliveryDeliverablePeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ldd.DeliverableCode, ldd.LearningDeliveryDeliverablePeriodisedValues))));

            learningDeliveryPeriodisedValues
                .NullSafeForEach(ldpv => ldpv.LearningDeliveryPeriodisedValue
                    .NullSafeForEach(learningDeliveryPeriodisedValue => cache.Add(BuildFundingData( dataStoreContext, learningDeliveryPeriodisedValue, conRefNumberDictionary, ukprn, ldpv.AimSeqNumber, ldpv.LearnRefNumber, ldpv.EsfDeliverableCode, academicYear, collectionReturnCode, collectionType))));
        }

        public ESFFundingData BuildFundingData(IDataStoreContext dataStoreContext, LearningDeliveryDeliverablePeriodisedValue lddpv, Dictionary<string, Dictionary<int, string>> conRefNumberDictionary, int ukprn, int aimSeqNumber, string learnRefNumber, string deliverableCode, string academicYear, string collectionReturnCode, string collectionType)
        {
            var conRefNumber = GetConRefNumber(conRefNumberDictionary, aimSeqNumber, learnRefNumber);

            return new ESFFundingData()
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                AimSeqNumber = aimSeqNumber,
                ConRefNumber = conRefNumber,
                DeliverableCode = deliverableCode,
                AttributeName = lddpv.AttributeName,                
                Period_1 = lddpv.Period1,
                Period_2 = lddpv.Period2,
                Period_3 = lddpv.Period3,
                Period_4 = lddpv.Period4,
                Period_5 = lddpv.Period5,
                Period_6 = lddpv.Period6,
                Period_7 = lddpv.Period7,
                Period_8 = lddpv.Period8,
                Period_9 = lddpv.Period9,
                Period_10 = lddpv.Period10,
                Period_11 = lddpv.Period11,
                Period_12 = lddpv.Period12,
                AcademicYear = academicYear,
                CollectionReturnCode = collectionReturnCode,
                CollectionType = collectionType
            };
        }

        public LatestProviderSubmission BuildLatestProviderSubmission(int ukprn, string collectionReturnCode, string collectionType)
        {
            return new LatestProviderSubmission()
            {
                UKPRN = ukprn,
                CollectionReturnCode = collectionReturnCode,
                CollectionType = collectionType
            };
        }

        private static Dictionary<string, Dictionary<int, string>> BuildConRefNumberDictionary(IMessage message)
        {
            var conRefNumberDictionary = 
                message?
                    .Learners?
                    .ToDictionary(
                        k => k.LearnRefNumber,
                        l => l.LearningDeliveries
                            .ToDictionary(
                                k => k.AimSeqNumber,
                                ld => ld.ConRefNumber), 
                        StringComparer.OrdinalIgnoreCase)
                ?? new Dictionary<string, Dictionary<int, string>>();

            return conRefNumberDictionary;
        }

        private static string GetConRefNumber(Dictionary<string, Dictionary<int, string>> conRefNumberDictionary, int aimSeqNumber, string learnRefNumber)
        {
            string conRefNumber = null;

            if (conRefNumberDictionary.TryGetValue(learnRefNumber, out var value))
            {
                if (value.TryGetValue(aimSeqNumber, out var value1))
                {
                    conRefNumber = value1;
                }
            }

            return conRefNumber;
        }
    }
}
