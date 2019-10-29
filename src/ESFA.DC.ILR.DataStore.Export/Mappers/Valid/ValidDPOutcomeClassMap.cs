using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidDPOutcomeClassMap : ClassMap<DPOutcome>
    {
        public ValidDPOutcomeClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.OutType);
            Map(m => m.OutCode);
            Map(m => m.OutStartDate);
            Map(m => m.OutCollDate);
            Map(m => m.OutEndDate);
        }
    }
}
