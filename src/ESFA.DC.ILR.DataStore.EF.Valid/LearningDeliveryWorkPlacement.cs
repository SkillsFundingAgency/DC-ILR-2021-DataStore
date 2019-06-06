﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    public partial class LearningDeliveryWorkPlacement
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public DateTime WorkPlaceStartDate { get; set; }
        public DateTime? WorkPlaceEndDate { get; set; }
        public int? WorkPlaceHours { get; set; }
        public int WorkPlaceMode { get; set; }
        public int? WorkPlaceEmpId { get; set; }

        public virtual LearningDelivery LearningDelivery { get; set; }
    }
}
