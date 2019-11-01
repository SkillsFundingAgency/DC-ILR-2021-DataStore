using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidAppFinRecordClassMap : DefaultTableClassMap<AppFinRecord>
    {
        public ValidAppFinRecordClassMap()
        {
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
