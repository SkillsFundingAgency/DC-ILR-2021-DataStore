using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class Source
    {
        public string ProtectiveMarking { get; set; }
        public int UKPRN { get; set; }
        public string SoftwareSupplier { get; set; }
        public string SoftwarePackage { get; set; }
        public string Release { get; set; }
        public string SerialNo { get; set; }
        public DateTime? DateTime { get; set; }
        public string ReferenceData { get; set; }
        public string ComponentSetVersion { get; set; }
    }
}
