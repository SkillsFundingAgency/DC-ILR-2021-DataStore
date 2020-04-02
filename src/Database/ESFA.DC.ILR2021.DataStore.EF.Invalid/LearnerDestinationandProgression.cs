using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Invalid
{
    public partial class LearnerDestinationandProgression
    {
        public int LearnerDestinationandProgression_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long? ULN { get; set; }
    }
}
