using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.DataStore.Access.Interface
{
    public interface IGenerateSchema
    {
        Task Generate(string connectionString, CancellationToken cancellationToken);
    }
}
