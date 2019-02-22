﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class AlbGlobal
    {
        public AlbGlobal()
        {
            AlbLearners = new HashSet<AlbLearner>();
        }

        public int Ukprn { get; set; }
        public string Larsversion { get; set; }
        public string PostcodeAreaCostVersion { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<AlbLearner> AlbLearners { get; set; }
    }
}
