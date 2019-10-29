using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBglobalClassMap : ClassMap<ALB_global>
    {
        public ALBglobalClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LARSVersion);
            Map(m => m.PostcodeAreaCostVersion);
            Map(m => m.RulebaseVersion);
        }
    }
}
