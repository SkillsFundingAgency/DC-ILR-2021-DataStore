using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidContactPreferenceClassMap : ClassMap<ContactPreference>
    {
        public ValidContactPreferenceClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.ContPrefType);
            Map(m => m.ContPrefCode);
        }
    }
}
