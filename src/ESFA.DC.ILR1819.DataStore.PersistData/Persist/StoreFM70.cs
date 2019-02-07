using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM70 : IStoreService<FM70Global>
    {
        private readonly IFM70Mapper _fm70Mapper;
        private readonly IBulkInsert _bulkInsert;

        public StoreFM70()
        {
        }

        public StoreFM70(IFM70Mapper fm70Mapper, IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
            _fm70Mapper = fm70Mapper;
        }

        public async Task StoreAsync(SqlConnection sqlConnection, FM70Global fundingOutput, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var global = new List<ESF_global> { _fm70Mapper.MapGlobal(fundingOutput) };
            var learners = _fm70Mapper.MapLearners(fundingOutput);
            var learnerDPOutcomes = _fm70Mapper.MapDPOutcomes(fundingOutput);
            var learningDeliveries = _fm70Mapper.MapLearningDeliveries(fundingOutput);
            var learningDeliveryDeliverables = _fm70Mapper.MapLearningDeliveryDeliverables(fundingOutput);
            var learningDeliveryDeliverablePeriods = _fm70Mapper.MapLearningDeliveryDeliverablePeriods(fundingOutput);
            var learningDeliveryDeliverablePeriodisedValues = _fm70Mapper.MapLearningDeliveryDeliverablePeriodisedValues(fundingOutput);

            await _bulkInsert.Insert(FM70Constants.FM70_global, global, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_Learner, learners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_DPOutcome, learnerDPOutcomes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_LearningDelivery, learningDeliveries, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_LearningDeliveryDeliverable, learningDeliveryDeliverables, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_LearningDeliveryDeliverable_Period, learningDeliveryDeliverablePeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_LearningDeliveryDeliverable_PeriodisedValues, learningDeliveryDeliverablePeriodisedValues, sqlConnection, cancellationToken);
        }
    }
}
