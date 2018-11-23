using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM35 : AbstractStore, IStoreService<IEnumerable<FM35_global>>
    {
        public async Task StoreAsync(SqlTransaction sqlTransaction, int ukprn, IEnumerable<FM35_global> rulebaseData, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var globals = rulebaseData;
            var learners = rulebaseData.SelectMany(l => l.FM35_Learner);
            var learningDeliveries = rulebaseData.SelectMany(l => l.FM35_Learner.SelectMany(ld => ld.FM35_LearningDelivery));
            var learningDeliveryPeriod = rulebaseData.SelectMany(l => l.FM35_Learner.SelectMany(ld => ld.FM35_LearningDelivery.SelectMany(p => p.FM35_LearningDelivery_Period)));
            var learningDeliveryPeriodisedValues = rulebaseData.SelectMany(l => l.FM35_Learner.SelectMany(ld => ld.FM35_LearningDelivery.SelectMany(p => p.FM35_LearningDelivery_PeriodisedValues)));

            await _bulkInsert.Insert("Rulebase.FM35_global", globals, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.FM35_Learner", learners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.FM35_LearningDelivery", learningDeliveries, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.FM35_LearningDelivery_Period", learningDeliveryPeriod, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Rulebase.FM35_LearningDelivery_PeriodisedValues", learningDeliveryPeriodisedValues, sqlTransaction, cancellationToken);
        }
    }
}
