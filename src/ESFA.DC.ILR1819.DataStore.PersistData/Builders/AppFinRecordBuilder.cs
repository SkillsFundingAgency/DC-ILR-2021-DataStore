using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class AppFinRecordBuilder
    {
        public static EF.Valid.AppFinRecord BuildValidAppFinRecord(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, IAppFinRecord appFinRecord)
        {
            return new EF.Valid.AppFinRecord
            {
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                AFinAmount = appFinRecord.AFinAmount,
                AFinCode = appFinRecord.AFinCode,
                AFinDate = appFinRecord.AFinDate,
                AFinType = appFinRecord.AFinType,
                AimSeqNumber = learningDelivery.AimSeqNumber
            };
        }

        public static EF.Invalid.AppFinRecord BuildInvalidAppFinRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            IAppFinRecord appFinRecord,
            int learnerDeliveryId,
            int appFinRecordId)
        {
            return new EF.Invalid.AppFinRecord
            {
                AppFinRecord_Id = appFinRecordId,
                LearningDelivery_Id = learnerDeliveryId,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                AFinAmount = appFinRecord.AFinAmount,
                AFinCode = appFinRecord.AFinCode,
                AFinDate = appFinRecord.AFinDate,
                AFinType = appFinRecord.AFinType,
                AimSeqNumber = learningDelivery.AimSeqNumber
            };
        }
    }
}