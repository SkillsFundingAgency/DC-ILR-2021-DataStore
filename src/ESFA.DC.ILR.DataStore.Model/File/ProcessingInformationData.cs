using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Model.File
{
    public class ProcessingInformationData
    {
        public FileDetail FileDetail { get; set; }

        public ProcessingData ProcessingData { get; set; }
    }
}
