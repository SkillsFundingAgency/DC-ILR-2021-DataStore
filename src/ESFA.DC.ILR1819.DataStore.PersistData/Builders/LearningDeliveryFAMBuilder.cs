using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearningDeliveryFAMBuilder
    {
        public static EF.Valid.LearningDeliveryFAM BuildValidFamRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryFAM learningDeliveryFam,
            int learnerDeliveryFamId)
        {
            return new EF.Valid.LearningDeliveryFAM
            {
                LearningDeliveryFAM_Id = learnerDeliveryFamId,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = learner.LearnRefNumber,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnDelFAMCode = learningDeliveryFam.LearnDelFAMCode,
                LearnDelFAMDateFrom = learningDeliveryFam.LearnDelFAMDateFromNullable,
                LearnDelFAMDateTo = learningDeliveryFam.LearnDelFAMDateToNullable,
                LearnDelFAMType = learningDeliveryFam.LearnDelFAMType
            };
        }

        public static EF.Invalid.LearningDeliveryFAM BuildInvalidFamRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryFAM learningDeliveryFam,
            int learnerDeliveryId,
            int learnerDeliveryFamId)
        {
            return new EF.Invalid.LearningDeliveryFAM
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
