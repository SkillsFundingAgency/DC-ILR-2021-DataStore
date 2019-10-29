using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25globalClassMap : ClassMap<FM25_global>
    {
        public FM25globalClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LARSVersion);
            Map(m => m.OrgVersion);
            Map(m => m.PostcodeDisadvantageVersion);
            Map(m => m.RulebaseVersion);
        }
    }
}
