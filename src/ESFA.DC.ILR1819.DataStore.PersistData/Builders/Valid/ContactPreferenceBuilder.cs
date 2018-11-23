using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class ContactPreferenceBuilder
    {
        public static ContactPreference BuildValidContactPreference(
            IMessage ilr,
            ILearner ilrLearner,
            IContactPreference contactPreference)
        {
            return new ContactPreference
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = ilrLearner.LearnRefNumber,
                ContPrefCode = contactPreference.ContPrefCode,
                ContPrefType = contactPreference.ContPrefType
            };
        }
    }
}