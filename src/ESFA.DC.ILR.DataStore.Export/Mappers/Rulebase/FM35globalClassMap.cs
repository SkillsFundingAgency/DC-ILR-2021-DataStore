using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35globalClassMap : ClassMap<FM35_global>
    {
        public FM35globalClassMap()
        {
                Map(m => m.UKPRN);
                Map(m => m.CurFundYr);
                Map(m => m.LARSVersion);
                Map(m => m.OrgVersion);
                Map(m => m.PostcodeDisadvantageVersion);
                Map(m => m.RulebaseVersion);
        }
    }
}
