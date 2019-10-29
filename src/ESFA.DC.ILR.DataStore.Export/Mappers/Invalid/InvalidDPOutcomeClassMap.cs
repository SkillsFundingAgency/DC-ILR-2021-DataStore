using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidDPOutcomeClassMap : ClassMap<DPOutcome>
    {
        public InvalidDPOutcomeClassMap()
        {
            Map(m => m.DPOutcome_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearnerDestinationandProgression_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.OutType);
            Map(m => m.OutCode);
            Map(m => m.OutStartDate);
            Map(m => m.OutCollDate);
            Map(m => m.OutEndDate);
        }
    }
}
