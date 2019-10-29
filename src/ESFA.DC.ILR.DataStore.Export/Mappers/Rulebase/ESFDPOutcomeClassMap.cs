using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFDPOutcomeClassMap : ClassMap<ESF_DPOutcome>
    {
        public ESFDPOutcomeClassMap()
        {
                Map(m => m.UKPRN);
                Map(m => m.LearnRefNumber);
                Map(m => m.OutCode);
                Map(m => m.OutType);
                Map(m => m.OutStartDate);
                Map(m => m.OutcomeDateForProgression);
                Map(m => m.PotentialESFProgressionType);
                Map(m => m.ProgressionType);
                Map(m => m.ReachedSixMonthPoint);
                Map(m => m.ReachedThreeMonthPoint);
                Map(m => m.ReachedTwelveMonthPoint);
        }
    }
}
