using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace ESFA.DC.ILR1819.DataStore.EF.Console.DesignTime
{
    public class ReferenceDataCandidateNamingService : CandidateNamingService
    {
        public override string GenerateCandidateIdentifier(DatabaseTable originalTable)
        {
            return originalTable.Name;
        }

        public override string GenerateCandidateIdentifier(DatabaseColumn originalColumn)
        {
            return originalColumn.Name;
        }
    }
}
