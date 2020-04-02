using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Valid
{
    public partial class SourceFile
    {
        public int UKPRN { get; set; }
        public string SourceFileName { get; set; }
        public DateTime? FilePreparationDate { get; set; }
        public string SoftwareSupplier { get; set; }
        public string SoftwarePackage { get; set; }
        public string Release { get; set; }
        public string SerialNo { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
