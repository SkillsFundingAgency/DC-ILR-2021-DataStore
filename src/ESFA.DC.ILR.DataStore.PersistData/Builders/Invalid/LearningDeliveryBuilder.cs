using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class LearningDeliveryBuilder
    {
        public static LearningDelivery BuildInvalidLearningDelivery(
            int ukprn,
            ILearner learner,
            ILearningDelivery learningDelivery,
            int learnerId,
            int learnerDeliveryId)
        {
            return new LearningDelivery
            {
                Learner_Id = learnerId,
                LearningDelivery_Id = learnerDeliveryId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                LearnAimRef = learningDelivery.LearnAimRef,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                AchDate = learningDelivery.AchDateNullable,
                AddHours = learningDelivery.AddHoursNullable,
                AimType = learningDelivery.AimType,
                CompStatus = learningDelivery.CompStatus,
                ConRefNumber = learningDelivery.ConRefNumber,
                DelLocPostCode = learningDelivery.DelLocPostCode,
                EmpOutcome = learningDelivery.EmpOutcomeNullable,
                EPAOrgID = learningDelivery.EPAOrgID,
                FundModel = learningDelivery.FundModel,
                FworkCode = learningDelivery.FworkCodeNullable,
                LearnActEndDate = learningDelivery.LearnActEndDateNullable,
                LearnPlanEndDate = learningDelivery.LearnPlanEndDate,
                LearnStartDate = learningDelivery.LearnStartDate,
                OrigLearnStartDate = learningDelivery.OrigLearnStartDateNullable,
                OtherFundAdj = learningDelivery.OtherFundAdjNullable,
                OutGrade = learningDelivery.OutGrade,
                Outcome = learningDelivery.OutcomeNullable,
                PartnerUKPRN = learningDelivery.PartnerUKPRNNullable,
                PriorLearnFundAdj = learningDelivery.PriorLearnFundAdjNullable,
                ProgType = learningDelivery.ProgTypeNullable,
                PwayCode = learningDelivery.PwayCodeNullable,
                StdCode = learningDelivery.StdCodeNullable,
                SWSupAimId = learningDelivery.SWSupAimId,
                WithdrawReason = learningDelivery.WithdrawReasonNullable
            };
        }
    }
}