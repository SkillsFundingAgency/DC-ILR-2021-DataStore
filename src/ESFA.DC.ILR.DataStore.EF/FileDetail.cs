using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class FileDetail
    {
        public long ID { get; set; }
        public int UKPRN { get; set; }
        public string Filename { get; set; }
        public long? FileSizeKb { get; set; }
        public int? TotalLearnersSubmitted { get; set; }
        public int? TotalValidLearnersSubmitted { get; set; }
        public int? TotalInvalidLearnersSubmitted { get; set; }
        public int? TotalErrorCount { get; set; }
        public int? TotalWarningCount { get; set; }
        public DateTime? SubmittedTime { get; set; }
        public bool? Success { get; set; }
    }
}
