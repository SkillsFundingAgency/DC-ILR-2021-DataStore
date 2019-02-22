﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class Fm35Learner
    {
        public Fm35Learner()
        {
            Fm35LearningDeliveries = new HashSet<Fm35LearningDelivery>();
        }

        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual Fm35Global UkprnNavigation { get; set; }
        public virtual ICollection<Fm35LearningDelivery> Fm35LearningDeliveries { get; set; }
    }
}
