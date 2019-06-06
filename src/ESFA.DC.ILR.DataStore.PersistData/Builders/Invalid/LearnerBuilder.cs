using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class LearnerBuilder
    {
        public static Learner BuildInvalidLearner(int ukprn, ILearner ilrLearner, int id)
        {
            return new Learner
            {
                Learner_Id = id,
                LearnRefNumber = ilrLearner.LearnRefNumber,
                UKPRN = ukprn,
                Accom = ilrLearner.AccomNullable,
                AddLine1 = ilrLearner.AddLine1,
                AddLine2 = ilrLearner.AddLine2,
                AddLine3 = ilrLearner.AddLine3,
                AddLine4 = ilrLearner.AddLine4,
                ALSCost = ilrLearner.ALSCostNullable,
                CampId = ilrLearner.CampId,
                DateOfBirth = ilrLearner.DateOfBirthNullable,
                Email = ilrLearner.Email,
                EngGrade = ilrLearner.EngGrade,
                Ethnicity = ilrLearner.Ethnicity,
                FamilyName = ilrLearner.FamilyName,
                GivenNames = ilrLearner.GivenNames,
                LLDDHealthProb = ilrLearner.LLDDHealthProb,
                MathGrade = ilrLearner.MathGrade,
                NINumber = ilrLearner.NINumber,
                PlanEEPHours = ilrLearner.PlanEEPHoursNullable,
                PlanLearnHours = ilrLearner.PlanLearnHoursNullable,
                PMUKPRN = ilrLearner.PMUKPRNNullable,
                Postcode = ilrLearner.Postcode,
                PostcodePrior = ilrLearner.PostcodePrior,
                PrevLearnRefNumber = ilrLearner.PrevLearnRefNumber,
                PrevUKPRN = ilrLearner.PrevUKPRNNullable,
                PriorAttain = ilrLearner.PriorAttainNullable,
                Sex = ilrLearner.Sex,
                TelNo = ilrLearner.TelNo,
                ULN = ilrLearner.ULN
            };
        }
    }
}
