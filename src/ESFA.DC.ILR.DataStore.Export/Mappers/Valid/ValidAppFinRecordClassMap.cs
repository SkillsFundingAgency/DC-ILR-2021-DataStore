using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidAppFinRecordClassMap : ClassMap<AppFinRecord>
    {
        public ValidAppFinRecordClassMap()
        {
            Map(m => m.AppFinRecord_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.AFinType);
            Map(m => m.AFinCode);
            Map(m => m.AFinDate);
            Map(m => m.AFinAmount);
        }
    }
}
