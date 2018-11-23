using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid
{
    public class LearnerHEBuilder
    {
        public static LearnerHE BuildInvalidLearnerHE(
            IMessage ilr,
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
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                UCASPERID = learner.LearnerHEEntity.UCASPERID
            };
        }
    }
}