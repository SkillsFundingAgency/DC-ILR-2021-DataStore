using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25FM35globalClassMap : ClassMap<FM25_FM35_global>
    {
        public FM25FM35globalClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.RulebaseVersion);
        }
    }
}
