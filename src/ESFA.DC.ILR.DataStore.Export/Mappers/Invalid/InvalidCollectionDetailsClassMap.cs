using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidCollectionDetailsClassMap : ClassMap<CollectionDetail>
    {
        public InvalidCollectionDetailsClassMap()
        {
            Map(m => m.CollectionDetails_Id);
            Map(m => m.UKPRN);
            Map(m => m.Collection);
            Map(m => m.FilePreparationDate);
            Map(m => m.Year);
        }
    }
}
