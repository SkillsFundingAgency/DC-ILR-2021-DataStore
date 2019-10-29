﻿using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Export.Interface
{
    public interface ISchemaExport
    {
        Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, OleDbTransaction transaction, string exportPath, CancellationToken cancellationToken);
    }
}
