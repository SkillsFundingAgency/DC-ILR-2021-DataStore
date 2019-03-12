using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class LearningDeliveryHE
    {
        public int LearningDeliveryHE_Id { get; set; }
        public int UKPRN { get; set; }
        public int? LearningDelivery_Id { get; set; }
        public string LearnRefNumber { get; set; }
        public long? AimSeqNumber { get; set; }
        public string NUMHUS { get; set; }
        public string SSN { get; set; }
        public string QUALENT3 { get; set; }
        public long? SOC2000 { get; set; }
        public long? SEC { get; set; }
        public string UCASAPPID { get; set; }
        public long? TYPEYR { get; set; }
        public long? MODESTUD { get; set; }
        public long? FUNDLEV { get; set; }
        public long? FUNDCOMP { get; set; }
        public double? STULOAD { get; set; }
        public long? YEARSTU { get; set; }
        public long? MSTUFEE { get; set; }
        public double? PCOLAB { get; set; }
        public double? PCFLDCS { get; set; }
        public double? PCSLDCS { get; set; }
        public double? PCTLDCS { get; set; }
        public long? SPECFEE { get; set; }
        public long? NETFEE { get; set; }
        public long? GROSSFEE { get; set; }
        public string DOMICILE { get; set; }
        public long? ELQ { get; set; }
        public string HEPostCode { get; set; }
    }
}
