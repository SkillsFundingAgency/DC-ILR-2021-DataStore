using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class LearnerHEFinancialSupportBuilder
    {
        public static LearnerHEFinancialSupport BuildValidLearnerHEFinancialSupport(
            IMessage ilr,
            ILearner learner,
            ILearnerHEFinancialSupport heFinancialSupport)
        {
            return new LearnerHEFinancialSupport
            {
                FINAMOUNT = heFinancialSupport.FINAMOUNT,
                FINTYPE = heFinancialSupport.FINTYPE,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ilr.LearningProviderEntity.UKPRN
            };
        }
    }
}