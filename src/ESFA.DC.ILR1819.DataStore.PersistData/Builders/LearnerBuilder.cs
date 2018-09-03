using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearnerBuilder
    {
        public static EF.Valid.Learner BuildValidLearner(IMessage ilr, ILearner ilrLearner)
        {
            return new EF.Valid.Learner
            {
                LearnRefNumber = ilrLearner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
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
                OTJHours = ilrLearner.OTJHoursNullable,
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

        public static EF.Invalid.Learner BuildInvalidLearner(IMessage ilr, ILearner ilrLearner, int id)
        {
            return new EF.Invalid.Learner
            {
                Learner_Id = id,
                LearnRefNumber = ilrLearner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
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
                OTJHours = ilrLearner.OTJHoursNullable,
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
