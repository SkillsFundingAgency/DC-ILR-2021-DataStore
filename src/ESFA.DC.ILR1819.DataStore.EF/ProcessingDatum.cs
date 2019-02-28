using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ProcessingDatum
    {
        public long Id { get; set; }
        public int Ukprn { get; set; }
        public long FileDetailsId { get; set; }
        public string ProcessingStep { get; set; }
        public string ExecutionTime { get; set; }
    }
}
