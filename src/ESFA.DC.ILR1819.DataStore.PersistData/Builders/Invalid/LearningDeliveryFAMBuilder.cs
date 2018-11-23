using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid
{
    public class LearningDeliveryFAMBuilder
    {
        public static LearningDeliveryFAM BuildInvalidFamRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryFAM learningDeliveryFam,
            int learnerDeliveryId,
            int learnerDeliveryFamId)
        {
            return new LearningDeliveryFAM
            {
                LearningDeliveryFAM_Id = learnerDeliveryFamId,
                LearningDelivery_Id = learnerDeliveryId,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = learner.LearnRefNumber,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnDelFAMCode = learningDeliveryFam.LearnDelFAMCode,
                LearnDelFAMDateFrom = learningDeliveryFam.LearnDelFAMDateFromNullable,
                LearnDelFAMDateTo = learningDeliveryFam.LearnDelFAMDateToNullable,
                LearnDelFAMType = learningDeliveryFam.LearnDelFAMType
            };
        }
    }
}
