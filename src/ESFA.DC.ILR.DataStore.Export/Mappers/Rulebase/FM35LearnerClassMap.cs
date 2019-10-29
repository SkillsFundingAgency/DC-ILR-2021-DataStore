using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35LearnerClassMap : ClassMap<FM35_Learner>
    {
        public FM35LearnerClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
        }
    }
}
