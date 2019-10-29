using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLLDDandHealthProblemClassMap : ClassMap<LLDDandHealthProblem>
    {
        public InvalidLLDDandHealthProblemClassMap()
        {
            Map(m => m.LLDDandHealthProblem_Id);
            Map(m => m.UKPRN);
            Map(m => m.Learner_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.LLDDCat);
            Map(m => m.PrimaryLLDD);
        }
    }
}
