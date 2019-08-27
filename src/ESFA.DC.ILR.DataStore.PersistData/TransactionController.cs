using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData
{
    public class TransactionController : ITransactionController
    {
        private readonly IILRTransaction _ilrTransaction;
        private readonly IFM36HistoryTransaction _fm36HistoryTransaction;
        private readonly IESFFundingTransaction _esfFundingTransaction;
        private readonly ILogger _logger;

        public TransactionController(
            IILRTransaction ilrTransaction,
            IFM36HistoryTransaction fm36HistoryTransaction,
            IESFFundingTransaction esfFundingTransaction,
            ILogger logger)
        {
            _ilrTransaction = ilrTransaction;
            _fm36HistoryTransaction = fm36HistoryTransaction;
            _esfFundingTransaction = esfFundingTransaction;
            _logger = logger;
        }

        public async Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            try
            {
                await _ilrTransaction.WriteILRDataAsync(dataStoreContext, cache, cancellationToken);
                await _fm36HistoryTransaction.WriteFM36HistoryAsync(dataStoreContext, cache, cancellationToken);
                await _esfFundingTransaction.WriteESFFundingAsync(dataStoreContext, cache, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Transaction Controller failed - {ex.Message}");
                return false;
            }

            return true;
        }
    }
}