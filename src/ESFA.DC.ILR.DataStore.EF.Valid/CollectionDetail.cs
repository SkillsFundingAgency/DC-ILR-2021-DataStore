﻿using System;

namespace ESFA.DC.ILR1920.DataStore.EF.Valid
{
    public partial class CollectionDetail
    {
        public int UKPRN { get; set; }
        public string Collection { get; set; }
        public string Year { get; set; }
        public DateTime? FilePreparationDate { get; set; }
    }
}
