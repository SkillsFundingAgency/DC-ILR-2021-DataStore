using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM25FM35LearnerPeriodClassMap : ClassMap<FM25_FM35_Learner_Period>
    {
        public FM25FM35LearnerPeriodClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.Period);
            Map(m => m.LnrOnProgPay);
        }
    }
}
