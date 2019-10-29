using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidContactPreferenceClassMap : ClassMap<ContactPreference>
    {
        public InvalidContactPreferenceClassMap()
        {
            Map(m => m.ContactPreference_Id);
            Map(m => m.UKPRN);
            Map(m => m.Learner_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.ContPrefType);
            Map(m => m.ContPrefCode);
        }
    }
}
