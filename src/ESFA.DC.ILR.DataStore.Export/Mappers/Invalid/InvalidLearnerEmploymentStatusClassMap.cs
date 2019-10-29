using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearnerEmploymentStatusClassMap : ClassMap<LearnerEmploymentStatus>
    {
        public InvalidLearnerEmploymentStatusClassMap()
        {
            Map(m => m.LearnerEmploymentStatus_Id);
            Map(m => m.UKPRN);
            Map(m => m.Learner_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.DateEmpStatApp);
            Map(m => m.EmpStat);
            Map(m => m.EmpId);
            Map(m => m.AgreeId);
        }
    }
}
