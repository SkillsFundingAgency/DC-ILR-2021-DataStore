using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearnerPeriodClassMap : ClassMap<ALB_Learner_Period>
    {
        public ALBLearnerPeriodClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.Period);
            Map(m => m.ALBSeqNum);
        }
    }
}
