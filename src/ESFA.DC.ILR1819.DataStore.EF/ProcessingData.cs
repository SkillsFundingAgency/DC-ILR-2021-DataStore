using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ProcessingData
    {
        public long Id { get; set; }
        public int UKPRN { get; set; }
        public long FileDetailsID { get; set; }
        public string ProcessingStep { get; set; }
        public string ExecutionTime { get; set; }
    }
}
