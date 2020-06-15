using CsvHelper.Configuration;
using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLLDDandHealthProblemClassMap : DefaultTableClassMap<LLDDandHealthProblem>
    {
        public ValidLLDDandHealthProblemClassMap()
        {
            Map(m => m.Learner).Ignore();
        }
    }
}
