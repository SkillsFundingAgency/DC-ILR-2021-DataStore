using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreIlr : AbstractStore, IStoreIlr
    {
        private readonly ILearnerValidDataBuilder _learnerValidDataBuilder;
        private readonly ILearnerInvalidDataBuilder _learnerInvalidDataBuilder;

        public StoreIlr(ILearnerValidDataBuilder learnerValidDataBuilder, ILearnerInvalidDataBuilder learnerInvalidDataBuilder)
        {
            _learnerValidDataBuilder = learnerValidDataBuilder;
            _learnerInvalidDataBuilder = learnerInvalidDataBuilder;
        }

        public async Task StoreAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, IMessage ilr, List<string> validLearners, CancellationToken cancellationToken)
        {
            await ProcessFileDetails(dataStoreContext, sqlConnection, sqlTransaction, ilr, cancellationToken);
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
            var validLearnerData = _learnerValidDataBuilder.BuildValidLearnerData(ilr, learnersValid);
            var invalidLearnerData = _learnerInvalidDataBuilder.BuildInvalidLearnerData(ilr, learnersValid);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await PersistLearnerRecords(validLearnerData, invalidLearnerData, sqlConnection, sqlTransaction, cancellationToken);
        }

        private async Task PersistLearnerRecords(ValidLearnerData validLearnerData, InvalidLearnerData invalidLearnerData, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("Invalid.AppFinRecord", invalidLearnerData.RecordsInvalidAppFinRecords, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.ContactPreference", invalidLearnerData.RecordsInvalidContactPreferences, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.EmploymentStatusMonitoring", invalidLearnerData.RecordsInvalidEmploymentStatusMonitorings, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.Learner", invalidLearnerData.RecordsInvalidLearners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerEmploymentStatus", invalidLearnerData.RecordsInvalidLearnerEmploymentStatus, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerFAM", invalidLearnerData.RecordsInvalidLearnerFams, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerHE", invalidLearnerData.RecordsInvalidLearnerHes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerHEFinancialSupport", invalidLearnerData.RecordsInvalidLearnerHefinancialSupports, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDelivery", invalidLearnerData.RecordsInvalidLearningDeliverys, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryFAM", invalidLearnerData.RecordsInvalidLearnerDeliveryFams, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryHE", invalidLearnerData.RecordsInvalidLearningDeliveryHes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryWorkPlacement", invalidLearnerData.RecordsInvalidLearningDeliveryWorkPlacements, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LLDDandHealthProblem", invalidLearnerData.RecordsInvalidLlddandHealthProblems, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.ProviderSpecDeliveryMonitoring", invalidLearnerData.RecordsInvalidProviderSpecDeliveryMonitorings, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.ProviderSpecLearnerMonitoring", invalidLearnerData.RecordsInvalidProviderSpecLearnerMonitorings, sqlTransaction, cancellationToken);

            await _bulkInsert.Insert("Valid.AppFinRecord", validLearnerData.RecordsValidAppFinRecords, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.ContactPreference", validLearnerData.RecordsValidContactPreferences, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.EmploymentStatusMonitoring", validLearnerData.RecordsValidEmploymentStatusMonitorings, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.Learner", validLearnerData.RecordsValidLearners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerEmploymentStatus", validLearnerData.RecordsValidLearnerEmploymentStatus, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerFAM", validLearnerData.RecordsValidLearnerFams, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerHE", validLearnerData.RecordsValidLearnerHes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerHEFinancialSupport", validLearnerData.RecordsValidLearnerHefinancialSupports, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDelivery", validLearnerData.RecordsValidLearningDeliverys, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryFAM", validLearnerData.RecordsValidLearnerDeliveryFams, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryHE", validLearnerData.RecordsValidLearningDeliveryHes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryWorkPlacement", validLearnerData.RecordsValidLearningDeliveryWorkPlacements, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LLDDandHealthProblem", validLearnerData.RecordsValidLlddandHealthProblems, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.ProviderSpecDeliveryMonitoring", validLearnerData.RecordsValidProviderSpecDeliveryMonitorings, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.ProviderSpecLearnerMonitoring", validLearnerData.RecordsValidProviderSpecLearnerMonitorings, sqlTransaction, cancellationToken);
        }

        private async Task ProcessFileDetails(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, IMessage ilr, CancellationToken cancellationToken)
        {
            var ukprn = dataStoreContext.Ukprn;

            EF.Valid.CollectionDetail collectionDetailsValid = new EF.Valid.CollectionDetail
            {
                UKPRN = ukprn,
                Collection = ilr.HeaderEntity.CollectionDetailsEntity.CollectionString,
                FilePreparationDate = ilr.HeaderEntity.CollectionDetailsEntity.FilePreparationDate,
                Year = ilr.HeaderEntity.CollectionDetailsEntity.YearString
            };

            EF.Invalid.CollectionDetail collectionDetailsInvalid = new EF.Invalid.CollectionDetail
            {
                UKPRN = ukprn,
                Collection = ilr.HeaderEntity.CollectionDetailsEntity.CollectionString,
                FilePreparationDate = ilr.HeaderEntity.CollectionDetailsEntity.FilePreparationDate,
                Year = ilr.HeaderEntity.CollectionDetailsEntity.YearString
            };

            EF.Valid.LearningProvider learningProviderValid = new EF.Valid.LearningProvider
            {
                UKPRN = ukprn
            };

            EF.Invalid.LearningProvider learningProviderInvalid = new EF.Invalid.LearningProvider
            {
                UKPRN = ukprn
            };

            var source = ilr.HeaderEntity.SourceEntity;

            var sourceValid = new EF.Valid.Source
            {
                UKPRN = ukprn,
                ComponentSetVersion = source.ComponentSetVersion,
                DateTime = source.DateTime,
                ProtectiveMarking = source.ProtectiveMarkingString,
                ReferenceData = source.ReferenceData,
                Release = source.Release,
                SerialNo = source.SerialNo,
                SoftwarePackage = source.SoftwarePackage,
                SoftwareSupplier = source.SoftwareSupplier
            };

            var sourceInvalid = new EF.Invalid.Source
            {
                UKPRN = ukprn,
                ComponentSetVersion = source.ComponentSetVersion,
                DateTime = source.DateTime,
                ProtectiveMarking = source.ProtectiveMarkingString,
                ReferenceData = source.ReferenceData,
                Release = source.Release,
                SerialNo = source.SerialNo,
                SoftwarePackage = source.SoftwarePackage,
                SoftwareSupplier = source.SoftwareSupplier
            };

            var sourceFilesValid = ilr
                .SourceFilesCollection?
                .Select(sf => new EF.Valid.SourceFile
                {
                    UKPRN = ukprn,
                    DateTime = sf.DateTimeNullable,
                    FilePreparationDate = sf.FilePreparationDate,
                    Release = sf.Release,
                    SerialNo = sf.SerialNo,
                    SoftwarePackage = sf.SoftwarePackage,
                    SoftwareSupplier = sf.SoftwareSupplier,
                    SourceFileName = sf.SourceFileName,
                }).ToList()
                ?? new List<EF.Valid.SourceFile>();

            var sourceFilesInvalid = ilr
                .SourceFilesCollection?
                .Select(sf => new EF.Invalid.SourceFile
                {
                    UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                    DateTime = sf.DateTimeNullable,
                    FilePreparationDate = sf.FilePreparationDate,
                    Release = sf.Release,
                    SerialNo = sf.SerialNo,
                    SoftwarePackage = sf.SoftwarePackage,
                    SoftwareSupplier = sf.SoftwareSupplier,
                    SourceFileName = sf.SourceFileName,
                })
                .ToList()
                ?? new List<EF.Invalid.SourceFile>();

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert("Valid.CollectionDetails", new List<EF.Valid.CollectionDetail> { collectionDetailsValid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningProvider", new List<EF.Valid.LearningProvider> { learningProviderValid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.Source", new List<EF.Valid.Source> { sourceValid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Valid.SourceFile", sourceFilesValid, sqlTransaction, cancellationToken);

            await _bulkInsert.Insert("Invalid.CollectionDetails", new List<EF.Invalid.CollectionDetail> { collectionDetailsInvalid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningProvider", new List<EF.Invalid.LearningProvider> { learningProviderInvalid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.Source", new List<EF.Invalid.Source> { sourceInvalid }, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert("Invalid.SourceFile", sourceFilesInvalid, sqlTransaction, cancellationToken);
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