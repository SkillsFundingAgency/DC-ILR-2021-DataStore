using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class LearnerHEBuilder
    {
        public static LearnerHE BuildInvalidLearnerHE(
            int ukprn,
            ILearner learner,
            int learnerId,
            int learnerHEId)
        {
            return new LearnerHE
            {
                LearnerHE_Id = learnerHEId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                TTACCOM = learner.LearnerHEEntity.TTACCOMNullable,
                UKPRN = ukprn,
                UCASPERID = learner.LearnerHEEntity.UCASPERID
            };
        }
    }
}