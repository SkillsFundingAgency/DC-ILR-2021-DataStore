using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class LearningDeliveryWorkPlacementBuilder
    {
        public static LearningDeliveryWorkPlacement BuildInvalidWorkPlacementRecord(
            int ukprn,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryWorkPlacement learningDeliveryWorkPlacement,
            int learnerDeliveryId,
            int learningDeliveryWorkPlacementId)
        {
            return new LearningDeliveryWorkPlacement
            {
                LearningDeliveryWorkPlacement_Id = learningDeliveryWorkPlacementId,
                LearningDelivery_Id = learnerDeliveryId,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                UKPRN = ukprn,
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