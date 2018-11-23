using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid
{
    public class ContactPreferenceBuilder
    {
        public static ContactPreference BuildInvalidContactPreference(
            IMessage ilr,
            ILearner ilrLearner,
            IContactPreference contactPreference,
            int learnerId,
            int contactPreferenceId)
        {
            return new ContactPreference
            {
                ContactPreference_Id = contactPreferenceId,
                Learner_Id = learnerId,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = ilrLearner.LearnRefNumber,
                ContPrefCode = contactPreference.ContPrefCode,
                ContPrefType = contactPreference.ContPrefType
            };
        }
    }
}