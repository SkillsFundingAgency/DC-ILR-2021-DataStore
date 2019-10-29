using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerHEFinancialSupportClassMap : ClassMap<LearnerHEFinancialSupport>
    {
        public ValidLearnerHEFinancialSupportClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.FINTYPE);
            Map(m => m.FINAMOUNT);
        }
    }
}
