using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class LearnerHEFinancialSupportBuilder
    {
        public static LearnerHEFinancialSupport BuildInvalidLearnerHEFinancialSupport(
            int ukprn,
            ILearner learner,
            ILearnerHEFinancialSupport heFinancialSupport,
            int learnerHEFinancialSupportId)
        {
            return new LearnerHEFinancialSupport
            {
                LearnerHEFinancialSupport_Id = learnerHEFinancialSupportId,
                FINAMOUNT = heFinancialSupport.FINAMOUNT,
                FINTYPE = heFinancialSupport.FINTYPE,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn
            };
        }
    }
}