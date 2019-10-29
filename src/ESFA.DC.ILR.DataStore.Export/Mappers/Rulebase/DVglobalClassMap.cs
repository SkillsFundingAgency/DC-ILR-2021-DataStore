using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class DVglobalClassMap : ClassMap<DV_global>
    {
        public DVglobalClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.RulebaseVersion);
        }
    }
}
