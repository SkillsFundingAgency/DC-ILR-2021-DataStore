using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class LearnerFAMBuilder
    {
        public static LearnerFAM BuildInvalidLearnerFAM(
            int ukprn,
            ILearner learner,
            ILearnerFAM learnerFaM,
            int learnerId,
            int learnerFAMId)
        {
            return new LearnerFAM
            {
                LearnerFAM_Id = learnerFAMId,
                Learner_Id = learnerId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                LearnFAMCode = learnerFaM.LearnFAMCode,
                LearnFAMType = learnerFaM.LearnFAMType
            };
        }
    }
}