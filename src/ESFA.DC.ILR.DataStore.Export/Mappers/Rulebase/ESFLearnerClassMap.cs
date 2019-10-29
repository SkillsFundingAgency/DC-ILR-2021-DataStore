using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearnerClassMap : ClassMap<ESF_Learner>
    {
        public ESFLearnerClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
        }
    }
}
