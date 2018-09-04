using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearningDeliveryWorkPlacementBuilder
    {
        public static EF.Valid.LearningDeliveryWorkPlacement BuildValidWorkPlacementRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryWorkPlacement learningDeliveryWorkPlacement)
        {
            return new EF.Valid.LearningDeliveryWorkPlacement
            {
                AimSeqNumber = learningDelivery.AimSeqNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = learner.LearnRefNumber,
                WorkPlaceEmpId = learningDeliveryWorkPlacement.WorkPlaceEmpIdNullable.GetValueOrDefault(-1),
                WorkPlaceEndDate = learningDeliveryWorkPlacement.WorkPlaceEndDateNullable,
                WorkPlaceHours = learningDeliveryWorkPlacement.WorkPlaceHours,
                WorkPlaceMode = learningDeliveryWorkPlacement.WorkPlaceMode,
                WorkPlaceStartDate = learningDeliveryWorkPlacement.WorkPlaceStartDate
            };
        }

        public static EF.Invalid.LearningDeliveryWorkPlacement BuildInvalidWorkPlacementRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryWorkPlacement learningDeliveryWorkPlacement,
            int learnerDeliveryId,
            int learningDeliveryWorkPlacementId)
        {
            return new EF.Invalid.LearningDeliveryWorkPlacement
            {
                LearningDeliveryWorkPlacement_Id = learningDeliveryWorkPlacementId,
                LearningDelivery_Id = learnerDeliveryId,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = learner.LearnRefNumber,
                WorkPlaceEmpId = learningDeliveryWorkPlacement.WorkPlaceEmpIdNullable.GetValueOrDefault(-1),
                WorkPlaceEndDate = learningDeliveryWorkPlacement.WorkPlaceEndDateNullable,
                WorkPlaceHours = learningDeliveryWorkPlacement.WorkPlaceHours,
                WorkPlaceMode = learningDeliveryWorkPlacement.WorkPlaceMode,
                WorkPlaceStartDate = learningDeliveryWorkPlacement.WorkPlaceStartDate
            };
        }
    }
}