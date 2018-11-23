using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid
{
    public class LLDDAndHealthProblemBuilder
    {
        public static LLDDandHealthProblem BuildInvalidLLDDandHealthProblem(
            IMessage ilr,
            ILearner learner,
            ILLDDAndHealthProblem llddAndHealthProblem,
            int learnerId,
            int lLDDandHealthProblemId)
        {
            return new LLDDandHealthProblem
            {
                LLDDandHealthProblem_Id = lLDDandHealthProblemId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                LLDDCat = llddAndHealthProblem.LLDDCat,
                PrimaryLLDD = llddAndHealthProblem.PrimaryLLDDNullable,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };
        }
    }
}
