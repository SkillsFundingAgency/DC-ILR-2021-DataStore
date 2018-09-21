using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IILRProviderService
    {
        Task<Message> ReadAndDeserialiseIlrAsync(string ilrFilename, CancellationToken cancellationToken);
    }
}