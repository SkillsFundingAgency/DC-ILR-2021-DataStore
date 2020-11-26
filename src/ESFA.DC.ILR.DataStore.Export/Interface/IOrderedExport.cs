using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Export.Interface
{
    public interface IOrderedExport
    {
        int TaskOrder { get; }

        string TaskKey { get; }

        Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath, CancellationToken cancellationToken);
    }
}
