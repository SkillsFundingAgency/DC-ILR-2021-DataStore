using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerHEClassMap : ClassMap<LearnerHE>
    {
        public ValidLearnerHEClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.UCASPERID);
            Map(m => m.TTACCOM);
        }
    }
}
