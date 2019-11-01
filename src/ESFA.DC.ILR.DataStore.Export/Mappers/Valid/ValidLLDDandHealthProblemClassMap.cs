using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLLDDandHealthProblemClassMap : DefaultTableClassMap<LLDDandHealthProblem>
    {
        public ValidLLDDandHealthProblemClassMap()
        {
            Map(m => m.Learner).Ignore();

            //Map(m => m.UKPRN);
            //Map(m => m.LearnRefNumber);
            //Map(m => m.LLDDCat);
            //Map(m => m.LLDDandHealthProblem_ID);
            //Map(m => m.PrimaryLLDD);
        }
    }
}
