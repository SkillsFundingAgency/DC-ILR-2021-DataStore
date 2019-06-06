using System;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class SourceFile
    {
        public int SourceFile_Id { get; set; }
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
