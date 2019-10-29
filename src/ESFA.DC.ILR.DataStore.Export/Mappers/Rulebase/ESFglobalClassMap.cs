using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFglobalClassMap : ClassMap<ESF_global>
    {
        public ESFglobalClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.RulebaseVersion);
        }
    }
}
