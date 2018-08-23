using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearnerHEBuilder
    {
        public static EF.Valid.LearnerHE BuildValidLearnerHE(
            IMessage ilr,
            ILearner learner)
        {
            return new EF.Valid.LearnerHE
            {
                LearnRefNumber = learner.LearnRefNumber,
                TTACCOM = learner.LearnerHEEntity.TTACCOMNullable,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                UCASPERID = learner.LearnerHEEntity.UCASPERID
            };
        }

        public static EF.Invalid.LearnerHE BuildInvalidLearnerHE(
            IMessage ilr,
            ILearner learner,
            int learnerId,
            int learnerHEId)
        {
            return new EF.Invalid.LearnerHE
            {
                LearnerHE_Id = learnerHEId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                TTACCOM = learner.LearnerHEEntity.TTACCOMNullable,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                UCASPERID = learner.LearnerHEEntity.UCASPERID
            };
        }
    }
}