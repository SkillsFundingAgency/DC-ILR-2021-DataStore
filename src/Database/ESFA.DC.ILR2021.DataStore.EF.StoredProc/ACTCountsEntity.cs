using System.ComponentModel.DataAnnotations;

namespace ESFA.DC.ILR2021.DataStore.EF.StoredProc
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
