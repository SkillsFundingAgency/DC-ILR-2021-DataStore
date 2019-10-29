using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearnerHEFinancialSupportClassMap : ClassMap<LearnerHEFinancialSupport>
    {
        public InvalidLearnerHEFinancialSupportClassMap()
        {
            Map(m => m.LearnerHEFinancialSupport_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearnerHE_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.FINTYPE);
            Map(m => m.FINAMOUNT);
        }
    }
}
