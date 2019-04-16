using ESFA.DC.ILR1819.DataStore.EF.Invalid;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.Model.File
{
    public class InvalidHeaderData
    {
        public List<CollectionDetail> CollectionDetails { get; set; } = new List<CollectionDetail>();

        public List<LearningProvider> LearningProviders { get; set; } = new List<LearningProvider>();

        public List<Source> Sources { get; set; } = new List<Source>();

        public List<SourceFile> SourceFiles { get; set; } = new List<SourceFile>();
    }
}
