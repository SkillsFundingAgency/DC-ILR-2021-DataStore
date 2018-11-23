using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class LearnerHEBuilder
    {
        public static LearnerHE BuildValidLearnerHE(
            IMessage ilr,
            ILearner learner)
        {
            return new LearnerHE
            {
                LearnRefNumber = learner.LearnRefNumber,
                TTACCOM = learner.LearnerHEEntity.TTACCOMNullable,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                UCASPERID = learner.LearnerHEEntity.UCASPERID
            };
        }
    }
}