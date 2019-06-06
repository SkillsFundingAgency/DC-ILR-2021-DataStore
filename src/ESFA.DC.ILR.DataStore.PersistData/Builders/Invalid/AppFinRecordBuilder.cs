using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class AppFinRecordBuilder
    {
        public static AppFinRecord BuildInvalidAppFinRecord(
            int ukprn,
            ILearner learner,
            ILearningDelivery learningDelivery,
            IAppFinRecord appFinRecord,
            int learnerDeliveryId,
            int appFinRecordId)
        {
            return new AppFinRecord
            {
                AppFinRecord_Id = appFinRecordId,
                LearningDelivery_Id = learnerDeliveryId,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn,
                AFinAmount = appFinRecord.AFinAmount,
                AFinCode = appFinRecord.AFinCode,
                AFinDate = appFinRecord.AFinDate,
                AFinType = appFinRecord.AFinType,
                AimSeqNumber = learningDelivery.AimSeqNumber
            };
        }
    }
}