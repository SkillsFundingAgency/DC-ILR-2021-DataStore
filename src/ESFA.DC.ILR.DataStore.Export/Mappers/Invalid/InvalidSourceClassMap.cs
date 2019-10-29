using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidSourceClassMap : ClassMap<Source>
    {
        public InvalidSourceClassMap()
        {
            Map(m => m.Source_Id);
            Map(m => m.UKPRN);
            Map(m => m.ProtectiveMarking);
            Map(m => m.SoftwareSupplier);
            Map(m => m.SoftwarePackage);
            Map(m => m.Release);
            Map(m => m.SerialNo);
            Map(m => m.DateTime);
            Map(m => m.ReferenceData);
            Map(m => m.ComponentSetVersion);
        }
    }
}
