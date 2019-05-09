using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Valid
{
    public class ContactPreferenceBuilder
    {
        public static ContactPreference BuildValidContactPreference(
            int ukprn,
            ILearner ilrLearner,
            IContactPreference contactPreference)
        {
            return new ContactPreference
            {
                UKPRN = ukprn,
                LearnRefNumber = ilrLearner.LearnRefNumber,
                ContPrefCode = contactPreference.ContPrefCode,
                ContPrefType = contactPreference.ContPrefType
            };
        }
    }
}