using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidSourceFileClassMap : ClassMap<SourceFile>
    {
        public InvalidSourceFileClassMap()
        {
            Map(m => m.SourceFile_Id);
            Map(m => m.UKPRN);
            Map(m => m.SourceFileName);
            Map(m => m.FilePreparationDate);
            Map(m => m.FilePreparationDate);
            Map(m => m.SoftwareSupplier);
            Map(m => m.SoftwarePackage);
            Map(m => m.Release);
            Map(m => m.SerialNo);
            Map(m => m.DateTime);
        }
    }
}
