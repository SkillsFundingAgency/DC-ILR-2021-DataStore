using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearningProviderClassMap : ClassMap<LearningProvider>
    {
        public InvalidLearningProviderClassMap()
        {
            Map(m => m.LearningProvider_Id);
            Map(m => m.UKPRN);
        }
    }
}
