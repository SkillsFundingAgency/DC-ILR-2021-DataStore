using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class ContactPreferenceBuilder
    {
        public static ContactPreference BuildInvalidContactPreference(
            int ukprn,
            ILearner ilrLearner,
            IContactPreference contactPreference,
            int learnerId,
            int contactPreferenceId)
        {
            return new ContactPreference
            {
                ContactPreference_Id = contactPreferenceId,
                Learner_Id = learnerId,
                UKPRN = ukprn,
                LearnRefNumber = ilrLearner.LearnRefNumber,
                ContPrefCode = contactPreference.ContPrefCode,
                ContPrefType = contactPreference.ContPrefType
            };
        }
    }
}