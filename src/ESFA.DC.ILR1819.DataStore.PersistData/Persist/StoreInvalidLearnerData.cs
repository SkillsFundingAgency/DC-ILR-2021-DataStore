using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreInvalidLearnerData : AbstractStore, IStoreService<InvalidLearnerData>
    {
        public StoreInvalidLearnerData(IBulkInsert bulkInsert)
            : base(bulkInsert)
        {
        }

        public async Task StoreAsync(InvalidLearnerData model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("Invalid.AppFinRecord", model.RecordsInvalidAppFinRecords, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.ContactPreference", model.RecordsInvalidContactPreferences, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.EmploymentStatusMonitoring", model.RecordsInvalidEmploymentStatusMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.Learner", model.RecordsInvalidLearners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerEmploymentStatus", model.RecordsInvalidLearnerEmploymentStatus, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerFAM", model.RecordsInvalidLearnerFams, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerHE", model.RecordsInvalidLearnerHes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerHEFinancialSupport", model.RecordsInvalidLearnerHefinancialSupports, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDelivery", model.RecordsInvalidLearningDeliverys, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryFAM", model.RecordsInvalidLearnerDeliveryFams, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryHE", model.RecordsInvalidLearningDeliveryHes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryWorkPlacement", model.RecordsInvalidLearningDeliveryWorkPlacements, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LLDDandHealthProblem", model.RecordsInvalidLlddandHealthProblems, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.ProviderSpecDeliveryMonitoring", model.RecordsInvalidProviderSpecDeliveryMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.ProviderSpecLearnerMonitoring", model.RecordsInvalidProviderSpecLearnerMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.DPOutcome", model.RecordsInvalidDpOutcomes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerDestinationandProgression", model.RecordsInvalidLearnerDestinationandProgressions, sqlConnection, cancellationToken);
        }
    }
}
