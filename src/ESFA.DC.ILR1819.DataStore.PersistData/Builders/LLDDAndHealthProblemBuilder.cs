using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LLDDAndHealthProblemBuilder
    {
        public static EF.Valid.LLDDandHealthProblem BuildValidLLDDandHealthProblem(
            IMessage ilr,
            ILearner learner,
            ILLDDAndHealthProblem llddAndHealthProblem,
            int id)
        {
            return new EF.Valid.LLDDandHealthProblem
            {
                LLDDandHealthProblem_ID = id,
                LearnRefNumber = learner.LearnRefNumber,
                LLDDCat = llddAndHealthProblem.LLDDCat,
                PrimaryLLDD = llddAndHealthProblem.PrimaryLLDDNullable,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };
        }

        public static EF.Invalid.LLDDandHealthProblem BuildInvalidLLDDandHealthProblem(
            IMessage ilr,
            ILearner learner,
            ILLDDAndHealthProblem llddAndHealthProblem,
            int id)
        {
            return new EF.Invalid.LLDDandHealthProblem
            {
                LLDDandHealthProblem_Id = id,
                LearnRefNumber = learner.LearnRefNumber,
                LLDDCat = llddAndHealthProblem.LLDDCat,
                PrimaryLLDD = llddAndHealthProblem.PrimaryLLDDNullable,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };
        }
    }
}
