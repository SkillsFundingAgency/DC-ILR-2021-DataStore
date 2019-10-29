using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearnerHEClassMap : ClassMap<LearnerHE>
    {
        public InvalidLearnerHEClassMap()
        {
            Map(m => m.LearnerHE_Id);
            Map(m => m.UKPRN);
            Map(m => m.Learner_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.UCASPERID);
            Map(m => m.TTACCOM);
        }
    }
}
