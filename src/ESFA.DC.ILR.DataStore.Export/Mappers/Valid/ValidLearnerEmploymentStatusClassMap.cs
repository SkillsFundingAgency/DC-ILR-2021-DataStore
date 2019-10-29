using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerEmploymentStatusClassMap : ClassMap<LearnerEmploymentStatus>
    {
        public ValidLearnerEmploymentStatusClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.DateEmpStatApp);
            Map(m => m.EmpStat);
            Map(m => m.EmpId);
            Map(m => m.AgreeId);
        }
    }
}
