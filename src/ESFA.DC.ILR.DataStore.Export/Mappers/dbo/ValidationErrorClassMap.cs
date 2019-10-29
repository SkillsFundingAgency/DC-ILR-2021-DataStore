using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.dbo
{
    public class ValidationErrorClassMap : ClassMap<ValidationError>
    {
        public ValidationErrorClassMap()
        {
            Map(m => m.Id);
            Map(m => m.UKPRN);
            Map(m => m.Source);
            Map(m => m.LearnAimRef);
            Map(m => m.AimSeqNum);
            Map(m => m.SWSupAimID);
            Map(m => m.ErrorMessage);
            Map(m => m.FieldValues);
            Map(m => m.LearnRefNumber);
            Map(m => m.RuleName);
            Map(m => m.Severity);
            Map(m => m.FileLevelError);
        }
    }
}
