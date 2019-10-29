using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidCollectionDetailsClassMap : ClassMap<CollectionDetail>
    {
        public ValidCollectionDetailsClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.Collection);
            Map(m => m.FilePreparationDate);
            Map(m => m.Year);
        }
    }
}
