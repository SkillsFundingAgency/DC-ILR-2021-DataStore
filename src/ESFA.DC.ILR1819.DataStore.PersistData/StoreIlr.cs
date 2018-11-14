using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreIlr : AbstractStore, IStoreIlr
    {
        private readonly ILearnerValidDataBuilder _learnerValidDataBuilder;
        private readonly ILearnerInvalidDataBuilder _learnerInvalidDataBuilder;

        private ValidLearnerData _validLearnerData;
        private InvalidLearnerData _invalidLearnerData;

        public StoreIlr(
            ILearnerValidDataBuilder learnerValidDataBuilder,
            ILearnerInvalidDataBuilder learnerInvalidDataBuilder)
        {
            _learnerValidDataBuilder = learnerValidDataBuilder;
            _learnerInvalidDataBuilder = learnerInvalidDataBuilder;
        }

        public async Task StoreAsync(IJobContextMessage jobContextMessage, SqlConnection sqlConnection, SqlTransaction sqlTransaction, IMessage ilr, List<string> validLearners, CancellationToken cancellationToken)
        {
            await ProcessFileDetails(jobContextMessage, sqlConnection, sqlTransaction, ilr, cancellationToken);
            await ProcessLearners(sqlConnection, sqlTransaction, ilr, validLearners, cancellationToken);
            await ProcessLearnerDestinationsAndProgressions(sqlConnection, sqlTransaction, ilr, validLearners, cancellationToken);
        }

        private async Task ProcessLearners(
            SqlConnection sqlConnection,
            SqlTransaction sqlTransaction,
            IMessage ilr,
            List<string> learnersValid,
            CancellationToken cancellationToken)
        {
            _validLearnerData = _learnerValidDataBuilder.BuildValidLearnerData(ilr, learnersValid);
            _invalidLearnerData = _learnerInvalidDataBuilder.BuildInvalidLearnerData(ilr, learnersValid);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await SaveLearnerRecords(sqlConnection, sqlTransaction, cancellationToken);
        }

        private async Task SaveLearnerRecords(SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("Invalid.AppFinRecord", _invalidLearnerData.RecordsInvalidAppFinRecords, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.ContactPreference", _invalidLearnerData.RecordsInvalidContactPreferences, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.EmploymentStatusMonitoring", _invalidLearnerData.RecordsInvalidEmploymentStatusMonitorings, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.Learner", _invalidLearnerData.RecordsInvalidLearners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerEmploymentStatus", _invalidLearnerData.RecordsInvalidLearnerEmploymentStatus, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerFAM", _invalidLearnerData.RecordsInvalidLearnerFams, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerHE", _invalidLearnerData.RecordsInvalidLearnerHes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerHEFinancialSupport", _invalidLearnerData.RecordsInvalidLearnerHefinancialSupports, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDelivery", _invalidLearnerData.RecordsInvalidLearningDeliverys, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryFAM", _invalidLearnerData.RecordsInvalidLearnerDeliveryFams, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryHE", _invalidLearnerData.RecordsInvalidLearningDeliveryHes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryWorkPlacement", _invalidLearnerData.RecordsInvalidLearningDeliveryWorkPlacements, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LLDDandHealthProblem", _invalidLearnerData.RecordsInvalidLlddandHealthProblems, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.ProviderSpecDeliveryMonitoring", _invalidLearnerData.RecordsInvalidProviderSpecDeliveryMonitorings, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.ProviderSpecLearnerMonitoring", _invalidLearnerData.RecordsInvalidProviderSpecLearnerMonitorings, sqlTransaction, cancellationToken);

            await _bulkInsert.Insert("Valid.AppFinRecord", _validLearnerData.RecordsValidAppFinRecords, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.ContactPreference", _validLearnerData.RecordsValidContactPreferences, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.EmploymentStatusMonitoring", _validLearnerData.RecordsValidEmploymentStatusMonitorings, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.Learner", _validLearnerData.RecordsValidLearners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerEmploymentStatus", _validLearnerData.RecordsValidLearnerEmploymentStatus, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerFAM", _validLearnerData.RecordsValidLearnerFams, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerHE", _validLearnerData.RecordsValidLearnerHes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerHEFinancialSupport", _validLearnerData.RecordsValidLearnerHefinancialSupports, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDelivery", _validLearnerData.RecordsValidLearningDeliverys, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryFAM", _validLearnerData.RecordsValidLearnerDeliveryFams, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryHE", _validLearnerData.RecordsValidLearningDeliveryHes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryWorkPlacement", _validLearnerData.RecordsValidLearningDeliveryWorkPlacements, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LLDDandHealthProblem", _validLearnerData.RecordsValidLlddandHealthProblems, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.ProviderSpecDeliveryMonitoring", _validLearnerData.RecordsValidProviderSpecDeliveryMonitorings, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.ProviderSpecLearnerMonitoring", _validLearnerData.RecordsValidProviderSpecLearnerMonitorings, sqlTransaction, cancellationToken);
        }

        private async Task ProcessFileDetails(IJobContextMessage jobContextMessage, SqlConnection sqlConnection, SqlTransaction sqlTransaction, IMessage ilr, CancellationToken cancellationToken)
        {
            DateTime nowUtc = DateTime.UtcNow;

            var originalFileName = Path.GetFileName(jobContextMessage.KeyValuePairs["OriginalFilename"].ToString());

            EF.Valid.CollectionDetail collectionDetailsValid = new EF.Valid.CollectionDetail
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                Collection = ilr.HeaderEntity.CollectionDetailsEntity.CollectionString,
                FilePreparationDate = ilr.HeaderEntity.CollectionDetailsEntity.FilePreparationDate,
                Year = ilr.HeaderEntity.CollectionDetailsEntity.YearString
            };

            EF.Invalid.CollectionDetail collectionDetailsInvalid = new EF.Invalid.CollectionDetail
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                Collection = ilr.HeaderEntity.CollectionDetailsEntity.CollectionString,
                FilePreparationDate = ilr.HeaderEntity.CollectionDetailsEntity.FilePreparationDate,
                Year = ilr.HeaderEntity.CollectionDetailsEntity.YearString
            };

            EF.Valid.LearningProvider learningProviderValid = new EF.Valid.LearningProvider
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };

            EF.Invalid.LearningProvider learningProviderInvalid = new EF.Invalid.LearningProvider
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };

            EF.Valid.Source sourceValid = new EF.Valid.Source
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                ComponentSetVersion = "1.0",
                DateTime = nowUtc,
                ProtectiveMarking = "NA",
                ReferenceData = "NA",
                Release = "0.1.0",
                SerialNo = "NA",
                SoftwarePackage = "DataStore Persist",
                SoftwareSupplier = "ESFA DC"
            };

            EF.Invalid.Source sourceInvalid = new EF.Invalid.Source
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                ComponentSetVersion = "1.0",
                DateTime = nowUtc,
                ProtectiveMarking = "NA",
                ReferenceData = "NA",
                Release = "0.1.0",
                SerialNo = "NA",
                SoftwarePackage = "DataStore Persist",
                SoftwareSupplier = "ESFA DC"
            };

            EF.Valid.SourceFile sourceFileValid = new EF.Valid.SourceFile
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                DateTime = nowUtc,
                FilePreparationDate = ilr.HeaderEntity.SourceEntity.DateTime,
                Release = "0.1.0",
                SerialNo = "NA",
                SoftwarePackage = "DataStore Persist",
                SoftwareSupplier = "ESFA DC",
                SourceFileName = originalFileName,
            };

            EF.Invalid.SourceFile sourceFileInvalid = new EF.Invalid.SourceFile
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                DateTime = nowUtc,
                FilePreparationDate = ilr.HeaderEntity.SourceEntity.DateTime,
                Release = "0.1.0",
                SerialNo = "NA",
                SoftwarePackage = "DataStore Persist",
                SoftwareSupplier = "ESFA DC",
                SourceFileName = originalFileName,
            };

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert("Valid.CollectionDetails", new List<EF.Valid.CollectionDetail> { collectionDetailsValid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningProvider", new List<EF.Valid.LearningProvider> { learningProviderValid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.Source", new List<EF.Valid.Source> { sourceValid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.SourceFile", new List<EF.Valid.SourceFile> { sourceFileValid }, sqlTransaction, cancellationToken);

            await _bulkInsert.Insert("Invalid.CollectionDetails", new List<EF.Invalid.CollectionDetail> { collectionDetailsInvalid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningProvider", new List<EF.Invalid.LearningProvider> { learningProviderInvalid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.Source", new List<EF.Invalid.Source> { sourceInvalid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.SourceFile", new List<EF.Invalid.SourceFile> { sourceFileInvalid }, sqlTransaction, cancellationToken);
        }

        private async Task ProcessLearnerDestinationsAndProgressions(
            SqlConnection sqlConnection,
            SqlTransaction sqlTransaction,
            IMessage ilr,
            List<string> learnersValid,
            CancellationToken cancellationToken)
        {
            int learnerDestinationandProgressionId = 1;
            int dPOutcomeId = 1;

            List<EF.Valid.DPOutcome> recordsValidDpoutcomes = new List<EF.Valid.DPOutcome>();
            List<EF.Invalid.DPOutcome> recordsInvalidDpoutcomes = new List<EF.Invalid.DPOutcome>();

            List<EF.Valid.LearnerDestinationandProgression> recordsValidLearnerDestinationandProgressions = new List<EF.Valid.LearnerDestinationandProgression>();
            List<EF.Invalid.LearnerDestinationandProgression> recordsInvalidLearnerDestinationandProgressions = new List<EF.Invalid.LearnerDestinationandProgression>();

            foreach (ILearnerDestinationAndProgression learnerDestinationAndProgression in ilr.LearnerDestinationAndProgressions ?? Enumerable.Empty<ILearnerDestinationAndProgression>())
            {
                if (learnersValid.Contains(learnerDestinationAndProgression.LearnRefNumber, StringComparer.OrdinalIgnoreCase))
                {
                    recordsValidLearnerDestinationandProgressions.Add(new EF.Valid.LearnerDestinationandProgression
                    {
                        UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                        LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                        ULN = learnerDestinationAndProgression.ULN
                    });

                    foreach (IDPOutcome dpOutcome in learnerDestinationAndProgression.DPOutcomes)
                    {
                        recordsValidDpoutcomes.Add(new EF.Valid.DPOutcome
                        {
                            LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                            OutCode = dpOutcome.OutCode,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            OutCollDate = dpOutcome.OutCollDate,
                            OutEndDate = dpOutcome.OutEndDateNullable,
                            OutStartDate = dpOutcome.OutStartDate,
                            OutType = dpOutcome.OutType
                        });
                    }
                }
                else
                {
                    recordsInvalidLearnerDestinationandProgressions.Add(new EF.Invalid.LearnerDestinationandProgression
                    {
                        LearnerDestinationandProgression_Id = learnerDestinationandProgressionId,
                        UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                        LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                        ULN = learnerDestinationAndProgression.ULN
                    });

                    foreach (IDPOutcome dpOutcome in learnerDestinationAndProgression.DPOutcomes)
                    {
                        recordsInvalidDpoutcomes.Add(new EF.Invalid.DPOutcome
                        {
                            DPOutcome_Id = dPOutcomeId,
                            LearnerDestinationandProgression_Id = learnerDestinationandProgressionId,
                            LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                            OutCode = dpOutcome.OutCode,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            OutCollDate = dpOutcome.OutCollDate,
                            OutEndDate = dpOutcome.OutEndDateNullable,
                            OutStartDate = dpOutcome.OutStartDate,
                            OutType = dpOutcome.OutType
                        });

                        dPOutcomeId++;
                    }

                    learnerDestinationandProgressionId++;
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert("Invalid.DPOutcome", recordsInvalidDpoutcomes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerDestinationandProgression", recordsInvalidLearnerDestinationandProgressions, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.DPOutcome", recordsValidDpoutcomes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerDestinationandProgression", recordsValidLearnerDestinationandProgressions, sqlTransaction, cancellationToken);
        }
    }
}