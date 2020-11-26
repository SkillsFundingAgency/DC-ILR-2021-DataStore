using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Valid
{
    public partial class CollectionDetail
    {
        public int UKPRN { get; set; }
        public string Collection { get; set; }
        public string Year { get; set; }
        public DateTime? FilePreparationDate { get; set; }
    }
}
