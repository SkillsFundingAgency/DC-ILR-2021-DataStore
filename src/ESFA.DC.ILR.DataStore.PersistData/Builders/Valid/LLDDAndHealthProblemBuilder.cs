using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Valid
{
    public class LLDDAndHealthProblemBuilder
    {
        public static LLDDandHealthProblem BuildValidLLDDandHealthProblem(
            int ukprn,
            ILearner learner,
            ILLDDAndHealthProblem llddAndHealthProblem,
            int id)
        {
            return new LLDDandHealthProblem
            {
                LLDDandHealthProblem_ID = id,
                LearnRefNumber = learner.LearnRefNumber,
                LLDDCat = llddAndHealthProblem.LLDDCat,
                PrimaryLLDD = llddAndHealthProblem.PrimaryLLDDNullable,
                UKPRN = ukprn
            };
        }
    }
}
