using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ESFA.DC.ILR1920.DataStore.EF.StoredProc
{
    public class ACTCountsEntity
    {
        [Key]
        public long Id { get; set; }

        public int UkPrn { get; set; }

        public int LearnersAct1 { get; set; }

        public int LearnersAct2 { get; set; }
    }
}
