using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidSourceClassMap : ClassMap<Source>
    {
        public ValidSourceClassMap()
        {
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
