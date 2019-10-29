using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearningDeliveryHEClassMap : ClassMap<LearningDeliveryHE>
    {
        public InvalidLearningDeliveryHEClassMap()
        {
            Map(m => m.LearningDeliveryHE_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearningDelivery_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.NUMHUS);
            Map(m => m.SSN);
            Map(m => m.QUALENT3);
            Map(m => m.SOC2000);
            Map(m => m.SEC);
            Map(m => m.UCASAPPID);
            Map(m => m.TYPEYR);
            Map(m => m.MODESTUD);
            Map(m => m.FUNDLEV);
            Map(m => m.FUNDCOMP);
            Map(m => m.STULOAD);
            Map(m => m.YEARSTU);
            Map(m => m.MSTUFEE);
            Map(m => m.PCOLAB);
            Map(m => m.PCFLDCS);
            Map(m => m.PCSLDCS);
            Map(m => m.PCTLDCS);
            Map(m => m.SPECFEE);
            Map(m => m.NETFEE);
            Map(m => m.GROSSFEE);
            Map(m => m.DOMICILE);
            Map(m => m.ELQ);
            Map(m => m.HEPostCode);
        }
    }
}
