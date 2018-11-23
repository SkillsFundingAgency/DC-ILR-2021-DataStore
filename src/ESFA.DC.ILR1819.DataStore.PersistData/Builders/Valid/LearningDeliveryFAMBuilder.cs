using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class LearningDeliveryFAMBuilder
    {
        public static LearningDeliveryFAM BuildValidFamRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryFAM learningDeliveryFam,
            int learnerDeliveryFamId)
        {
            return new LearningDeliveryFAM
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
    }
}
