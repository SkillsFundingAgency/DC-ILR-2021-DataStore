using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class LearningDeliveryWorkPlacementBuilder
    {
        public static LearningDeliveryWorkPlacement BuildValidWorkPlacementRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryWorkPlacement learningDeliveryWorkPlacement)
        {
            return new LearningDeliveryWorkPlacement
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
    }
}