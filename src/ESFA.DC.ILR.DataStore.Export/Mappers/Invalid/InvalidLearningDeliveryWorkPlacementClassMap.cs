using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearningDeliveryWorkPlacementClassMap : ClassMap<LearningDeliveryWorkPlacement>
    {
        public InvalidLearningDeliveryWorkPlacementClassMap()
        {
            Map(m => m.LearningDeliveryWorkPlacement_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearningDelivery_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.WorkPlaceStartDate);
            Map(m => m.WorkPlaceEndDate);
            Map(m => m.WorkPlaceHours);
            Map(m => m.WorkPlaceMode);
            Map(m => m.WorkPlaceEmpId);
        }
    }
}
