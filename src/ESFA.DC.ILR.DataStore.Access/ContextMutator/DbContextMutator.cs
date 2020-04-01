using EntityFrameworkCore.Jet;
using EntityFrameworkCore.Jet.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Access.ContextMutator
{
    public class DbContextMutator
    {
        protected internal static DbContextOptions<T> MutateOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            var jetDbContextOptions = options.FindExtension<JetOptionsExtension>();

            return new DbContextOptionsBuilder<T>()
                .UseJet(jetDbContextOptions.ConnectionString)
                .Options;
        }
    }
}
