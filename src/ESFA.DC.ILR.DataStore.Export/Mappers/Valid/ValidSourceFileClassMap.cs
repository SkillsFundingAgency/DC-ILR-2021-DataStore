using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidSourceFileClassMap : ClassMap<SourceFile>
    {
        public ValidSourceFileClassMap()
        {
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
