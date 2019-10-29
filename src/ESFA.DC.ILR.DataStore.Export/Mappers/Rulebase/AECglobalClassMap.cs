using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECglobalClassMap : ClassMap<AEC_global>
    {
        public AECglobalClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LARSVersion);
            Map(m => m.RulebaseVersion);
            Map(m => m.Year);
        }
    }
}
