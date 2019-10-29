using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class TBLglobalClassMap : ClassMap<TBL_global>
    {
        public TBLglobalClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.CurFundYr);
            Map(m => m.LARSVersion);
            Map(m => m.RulebaseVersion);
        }
    }
}
