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
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public sealed class StoreIlr : AbstractStore, IStoreIlr
    {
        private readonly ILogger _logger;
        private readonly ILearnerValidDataBuilder _learnerValidDataBuilder;
        private readonly ILearnerInvalidDataBuilder _learnerInvalidDataBuilder;

        public StoreIlr(ILogger logger, ILearnerValidDataBuilder learnerValidDataBuilder, ILearnerInvalidDataBuilder learnerInvalidDataBuilder)
        {
            _logger = logger;
            _learnerValidDataBuilder = learnerValidDataBuilder;
            _learnerInvalidDataBuilder = learnerInvalidDataBuilder;
        }

        public async Task StoreAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, IMessage ilr, List<string> validLearners, CancellationToken cancellationToken)
        {
            await ProcessFileDetails(dataStoreContext, sqlConnection, ilr, cancellationToken);
            await ProcessLearners(sqlConnection, ilr, validLearners, cancellationToken);
            await ProcessLearnerDestinationsAndProgressions(sqlConnection, ilr, validLearners, cancellationToken);
        }

        private async Task ProcessLearners(
            SqlConnection sqlConnection,
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

            await PersistLearnerRecords(validLearnerData, invalidLearnerData, sqlConnection, cancellationToken);
        }

        private async Task PersistLearnerRecords(ValidLearnerData validLearnerData, InvalidLearnerData invalidLearnerData, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("Invalid.AppFinRecord", invalidLearnerData.RecordsInvalidAppFinRecords, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.ContactPreference", invalidLearnerData.RecordsInvalidContactPreferences, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.EmploymentStatusMonitoring", invalidLearnerData.RecordsInvalidEmploymentStatusMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.Learner", invalidLearnerData.RecordsInvalidLearners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerEmploymentStatus", invalidLearnerData.RecordsInvalidLearnerEmploymentStatus, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerFAM", invalidLearnerData.RecordsInvalidLearnerFams, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerHE", invalidLearnerData.RecordsInvalidLearnerHes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerHEFinancialSupport", invalidLearnerData.RecordsInvalidLearnerHefinancialSupports, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDelivery", invalidLearnerData.RecordsInvalidLearningDeliverys, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryFAM", invalidLearnerData.RecordsInvalidLearnerDeliveryFams, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryHE", invalidLearnerData.RecordsInvalidLearningDeliveryHes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningDeliveryWorkPlacement", invalidLearnerData.RecordsInvalidLearningDeliveryWorkPlacements, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LLDDandHealthProblem", invalidLearnerData.RecordsInvalidLlddandHealthProblems, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.ProviderSpecDeliveryMonitoring", invalidLearnerData.RecordsInvalidProviderSpecDeliveryMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.ProviderSpecLearnerMonitoring", invalidLearnerData.RecordsInvalidProviderSpecLearnerMonitorings, sqlConnection, cancellationToken);

            await _bulkInsert.Insert("Valid.AppFinRecord", validLearnerData.RecordsValidAppFinRecords, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.ContactPreference", validLearnerData.RecordsValidContactPreferences, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.EmploymentStatusMonitoring", validLearnerData.RecordsValidEmploymentStatusMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.Learner", validLearnerData.RecordsValidLearners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerEmploymentStatus", validLearnerData.RecordsValidLearnerEmploymentStatus, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerFAM", validLearnerData.RecordsValidLearnerFams, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerHE", validLearnerData.RecordsValidLearnerHes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerHEFinancialSupport", validLearnerData.RecordsValidLearnerHefinancialSupports, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDelivery", validLearnerData.RecordsValidLearningDeliverys, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryFAM", validLearnerData.RecordsValidLearnerDeliveryFams, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryHE", validLearnerData.RecordsValidLearningDeliveryHes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningDeliveryWorkPlacement", validLearnerData.RecordsValidLearningDeliveryWorkPlacements, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LLDDandHealthProblem", validLearnerData.RecordsValidLlddandHealthProblems, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.ProviderSpecDeliveryMonitoring", validLearnerData.RecordsValidProviderSpecDeliveryMonitorings, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.ProviderSpecLearnerMonitoring", validLearnerData.RecordsValidProviderSpecLearnerMonitorings, sqlConnection, cancellationToken);

            _logger.LogDebug("WriteToDEDS - Persist Learners Complete");
        }

        private async Task ProcessFileDetails(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, IMessage ilr, CancellationToken cancellationToken)
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

            var sourceFilesInvalid = BuildInvalidSourceFileCollection(ilr.SourceFilesCollection, ilr.LearningProviderEntity.UKPRN);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert("Valid.CollectionDetails", new List<EF.Valid.CollectionDetail> { collectionDetailsValid }, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningProvider", new List<EF.Valid.LearningProvider> { learningProviderValid }, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.Source", new List<EF.Valid.Source> { sourceValid }, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.SourceFile", sourceFilesValid, sqlConnection, cancellationToken);

            await _bulkInsert.Insert("Invalid.CollectionDetails", new List<EF.Invalid.CollectionDetail> { collectionDetailsInvalid }, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningProvider", new List<EF.Invalid.LearningProvider> { learningProviderInvalid }, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.Source", new List<EF.Invalid.Source> { sourceInvalid }, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.SourceFile", sourceFilesInvalid, sqlConnection, cancellationToken);

            _logger.LogDebug("WriteToDEDS - Process File Details Complete");
        }

        private List<EF.Invalid.SourceFile> BuildInvalidSourceFileCollection(IEnumerable<ISourceFile> sourceFiles, int ukprn)
        {
            var sourceFilesList = new List<EF.Invalid.SourceFile>();

            if (sourceFiles == null)
            {
                return sourceFilesList;
            }

            var sourceFilesArray = sourceFiles.ToArray();
            var arraySize = sourceFilesArray.Length;

            for (var i = 0; i < arraySize; i++)
            {
                var sf = sourceFilesArray[i];
                sourceFilesList.Add(new EF.Invalid.SourceFile
                {
                    SourceFile_Id = i,
                    UKPRN = ukprn,
                    DateTime = sf.DateTimeNullable,
                    FilePreparationDate = sf.FilePreparationDate,
                    Release = sf.Release,
                    SerialNo = sf.SerialNo,
                    SoftwarePackage = sf.SoftwarePackage,
                    SoftwareSupplier = sf.SoftwareSupplier,
                    SourceFileName = sf.SourceFileName,
                });
            }

            return sourceFilesList;
        }

        private async Task ProcessLearnerDestinationsAndProgressions(
            SqlConnection sqlConnection,
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

            await _bulkInsert.Insert("Invalid.DPOutcome", recordsInvalidDpoutcomes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearnerDestinationandProgression", recordsInvalidLearnerDestinationandProgressions, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.DPOutcome", recordsValidDpoutcomes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearnerDestinationandProgression", recordsValidLearnerDestinationandProgressions, sqlConnection, cancellationToken);

            _logger.LogDebug("WriteToDEDS - Process Learner Destination And Progressions Complete");
        }
    }
}