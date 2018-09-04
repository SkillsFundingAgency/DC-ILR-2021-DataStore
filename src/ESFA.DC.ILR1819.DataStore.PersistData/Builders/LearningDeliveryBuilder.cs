using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearningDeliveryBuilder
    {
        public static EF.Valid.LearningDelivery BuildValidLearningDelivery(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery)
        {
            return new EF.Valid.LearningDelivery
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
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

        public static EF.Invalid.LearningDelivery BuildInvalidLearningDelivery(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            int learnerId,
            int learnerDeliveryId)
        {
            return new EF.Invalid.LearningDelivery
            {
                Learner_Id = learnerId,
                LearningDelivery_Id = learnerDeliveryId,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
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