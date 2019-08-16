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
        private readonly IESFSummarisationTransaction _esfSummarisationTransaction;
        private readonly ILogger _logger;

        public TransactionController(
            IILRTransaction ilrTransaction,
            IFM36HistoryTransaction fm36HistoryTransaction,
            IESFSummarisationTransaction esfSummarisationTransaction,
            ILogger logger)
        {
            _ilrTransaction = ilrTransaction;
            _fm36HistoryTransaction = fm36HistoryTransaction;
            _esfSummarisationTransaction = esfSummarisationTransaction;
            _logger = logger;
        }

        public async Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            try
            {
                await _ilrTransaction.WriteILRDataAsync(dataStoreContext, cache, cancellationToken);
                _logger.LogDebug("ILR Transaction complete");

                await _fm36HistoryTransaction.WriteFM36HistoryAsync(dataStoreContext, cache, cancellationToken);
                _logger.LogDebug("FM36 Transaction complete");

                await  _esfSummarisationTransaction.WriteESFSummarisationAsync(dataStoreContext, cache, cancellationToken);
                _logger.LogDebug("ESF Summarisation Transaction complete");
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