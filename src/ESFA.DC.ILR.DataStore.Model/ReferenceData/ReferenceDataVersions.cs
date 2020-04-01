using System;

namespace ESFA.DC.ILR.DataStore.Model.ReferenceData
{
    public class ReferenceDataVersions
    {
        public string OrgName { get; set; }

        public string OrgVersion { get; set; }

        public string LarsVersion { get; set; }

        public string EmployersVersion { get; set; }

        public string PostcodesVersion { get; set; }

        public string CampusIdentifierVersion { get; set; }

        public DateTime? EasUploadDateTime { get; set; }
    }
}
