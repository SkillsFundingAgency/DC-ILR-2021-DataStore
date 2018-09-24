﻿using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreFM35
    {
        Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, FM35FundingOutputs fundingOutputs, CancellationToken cancellationToken);
    }
}