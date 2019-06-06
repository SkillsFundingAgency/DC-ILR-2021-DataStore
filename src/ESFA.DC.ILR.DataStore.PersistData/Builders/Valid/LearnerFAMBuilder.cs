using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Valid
{
    public class LearnerFAMBuilder
    {
        public static LearnerFAM BuildValidLearnerFAM(
            int ukprn,
            ILearner learner,
            ILearnerFAM learnerFaM)
        {
            return new LearnerFAM
            {
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                LearnFAMCode = learnerFaM.LearnFAMCode,
                LearnFAMType = learnerFaM.LearnFAMType
            };
        }
    }
}