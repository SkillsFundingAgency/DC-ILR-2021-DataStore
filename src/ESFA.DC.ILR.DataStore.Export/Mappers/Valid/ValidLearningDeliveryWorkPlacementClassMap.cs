using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryWorkPlacementClassMap : ClassMap<LearningDeliveryWorkPlacement>
    {
        public ValidLearningDeliveryWorkPlacementClassMap()
        {
            Map(m => m.UKPRN);
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
