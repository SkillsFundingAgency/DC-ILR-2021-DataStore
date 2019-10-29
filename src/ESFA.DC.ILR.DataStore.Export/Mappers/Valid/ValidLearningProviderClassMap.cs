using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningProviderClassMap : ClassMap<LearningProvider>
    {
        public ValidLearningProviderClassMap()
        {
            Map(m => m.UKPRN);
        }
    }
}
