using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidAppFinRecordClassMap : ClassMap<AppFinRecord>
    {
        public InvalidAppFinRecordClassMap()
        {
            Map(m => m.AppFinRecord_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearningDelivery_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.AFinType);
            Map(m => m.AFinCode);
            Map(m => m.AFinDate);
            Map(m => m.AFinAmount);
        }
    }
}
