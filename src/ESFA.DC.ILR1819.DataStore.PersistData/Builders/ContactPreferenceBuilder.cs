using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class ContactPreferenceBuilder
    {
        public static EF.Valid.ContactPreference BuildValidContactPreference(
            IMessage ilr,
            ILearner ilrLearner,
            IContactPreference contactPreference)
        {
            return new EF.Valid.ContactPreference
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = ilrLearner.LearnRefNumber,
                ContPrefCode = contactPreference.ContPrefCode,
                ContPrefType = contactPreference.ContPrefType
            };
        }

        public static EF.Invalid.ContactPreference BuildInvalidContactPreference(
            IMessage ilr,
            ILearner ilrLearner,
            IContactPreference contactPreference,
            int learnerId,
            int contactPreferenceId)
        {
            return new EF.Invalid.ContactPreference
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