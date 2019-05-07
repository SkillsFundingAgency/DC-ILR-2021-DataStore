using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreValidLearnerData : AbstractStore, IStoreService<ValidLearnerData>
    {
        public StoreValidLearnerData(IBulkInsert bulkInsert)
            : base(bulkInsert)
        {
        }

        public async Task StoreAsync(ValidLearnerData model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("Valid.AppFinRecord", model.RecordsValidAppFinRecords, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.ContactPreference", model.RecordsValidContactPreferences, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.EmploymentStatusMonitoring", model.RecordsValidEmploymentStatusMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.Learner", model.RecordsValidLearners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerEmploymentStatus", model.RecordsValidLearnerEmploymentStatus, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerFAM", model.RecordsValidLearnerFams, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerHE", model.RecordsValidLearnerHes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerHEFinancialSupport", model.RecordsValidLearnerHefinancialSupports, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDelivery", model.RecordsValidLearningDeliverys, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryFAM", model.RecordsValidLearnerDeliveryFams, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryHE", model.RecordsValidLearningDeliveryHes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryWorkPlacement", model.RecordsValidLearningDeliveryWorkPlacements, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LLDDandHealthProblem", model.RecordsValidLlddandHealthProblems, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.ProviderSpecDeliveryMonitoring", model.RecordsValidProviderSpecDeliveryMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.ProviderSpecLearnerMonitoring", model.RecordsValidProviderSpecLearnerMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.DPOutcome", model.RecordsValidDpOutcomes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerDestinationandProgression", model.RecordsValidLearnerDestinationandProgressions, sqlConnection, cancellationToken);
        }
    }
}
