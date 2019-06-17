using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF.Valid
{
    public partial class LearningDeliveryHE
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public string NUMHUS { get; set; }
        public string SSN { get; set; }
        public string QUALENT3 { get; set; }
        public int? SOC2000 { get; set; }
        public int? SEC { get; set; }
        public string UCASAPPID { get; set; }
        public int TYPEYR { get; set; }
        public int MODESTUD { get; set; }
        public int FUNDLEV { get; set; }
        public int FUNDCOMP { get; set; }
        public decimal? STULOAD { get; set; }
        public int YEARSTU { get; set; }
        public int MSTUFEE { get; set; }
        public decimal? PCOLAB { get; set; }
        public decimal? PCFLDCS { get; set; }
        public decimal? PCSLDCS { get; set; }
        public decimal? PCTLDCS { get; set; }
        public int SPECFEE { get; set; }
        public int? NETFEE { get; set; }
        public int? GROSSFEE { get; set; }
        public string DOMICILE { get; set; }
        public int? ELQ { get; set; }
        public string HEPostCode { get; set; }

        public virtual LearningDelivery LearningDelivery { get; set; }
    }
}
