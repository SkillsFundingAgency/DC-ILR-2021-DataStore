using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearnerHEFinancialSupportBuilder
    {
        public static EF.Valid.LearnerHEFinancialSupport BuildValidLearnerHEFinancialSupport(
            IMessage ilr,
            ILearner learner,
            ILearnerHEFinancialSupport heFinancialSupport)
        {
            return new EF.Valid.LearnerHEFinancialSupport
            {
                FINAMOUNT = heFinancialSupport.FINAMOUNT,
                FINTYPE = heFinancialSupport.FINTYPE,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };
        }

        public static EF.Invalid.LearnerHEFinancialSupport BuildInvalidLearnerHEFinancialSupport(
            IMessage ilr,
            ILearner learner,
            ILearnerHEFinancialSupport heFinancialSupport,
            int learnerHEFinancialSupportId)
        {
            return new EF.Invalid.LearnerHEFinancialSupport
            {
                LearnerHEFinancialSupport_Id = learnerHEFinancialSupportId,
                FINAMOUNT = heFinancialSupport.FINAMOUNT,
                FINTYPE = heFinancialSupport.FINTYPE,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };
        }
    }
}