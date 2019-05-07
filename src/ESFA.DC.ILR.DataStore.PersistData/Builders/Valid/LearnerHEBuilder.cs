using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Valid
{
    public class LearnerHEBuilder
    {
        public static LearnerHE BuildValidLearnerHE(
            int ukprn,
            ILearner learner)
        {
            return new LearnerHE
            {
                LearnRefNumber = learner.LearnRefNumber,
                TTACCOM = learner.LearnerHEEntity.TTACCOMNullable,
                UKPRN = ukprn,
                UCASPERID = learner.LearnerHEEntity.UCASPERID
            };
        }
    }
}