﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
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
        public string OrgName { get; set; }
        public string OrgVersion { get; set; }
        public string LarsVersion { get; set; }
        public string EmployersVersion { get; set; }
        public string PostcodesVersion { get; set; }
        public string CampusIdentifierVersion { get; set; }
        public DateTime? EasUploadDateTime { get; set; }
    }
}
