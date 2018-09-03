using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearnerFAMBuilder
    {
        public static EF.Valid.LearnerFAM BuildValidLearnerFAM(
            IMessage ilr,
            ILearner learner,
            ILearnerFAM learnerFaM)
        {
            return new EF.Valid.LearnerFAM
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = learner.LearnRefNumber,
                LearnFAMCode = learnerFaM.LearnFAMCode,
                LearnFAMType = learnerFaM.LearnFAMType
            };
        }

        public static EF.Invalid.LearnerFAM BuildInvalidLearnerFAM(
            IMessage ilr,
            ILearner learner,
            ILearnerFAM learnerFaM,
            int learnerId,
            int learnerFAMId)
        {
            return new EF.Invalid.LearnerFAM
            {
                LearnerFAM_Id = learnerFAMId,
                Learner_Id = learnerId,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = learner.LearnRefNumber,
                LearnFAMCode = learnerFaM.LearnFAMCode,
                LearnFAMType = learnerFaM.LearnFAMType
            };
        }
    }
}