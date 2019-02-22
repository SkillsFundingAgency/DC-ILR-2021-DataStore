﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    public partial class ProviderSpecLearnerMonitoring
    {
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public string ProvSpecLearnMonOccur { get; set; }
        public string ProvSpecLearnMon { get; set; }

        public virtual Learner Learner { get; set; }
    }
}
