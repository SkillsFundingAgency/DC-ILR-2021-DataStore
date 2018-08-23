using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;
using ESFA.DC.ILR1819.DataStore.PersistData.Models;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreIlr : IStoreIlr
    {
        private readonly SqlConnection _connection;

        private readonly SqlTransaction _transaction;

        private readonly IJobContextMessage _jobContextMessage;

        private ValidLearnerData _validLearnerData;
        private InvalidLearnerData _invalidLearnerData;

        public StoreIlr(
            SqlConnection connection,
            SqlTransaction transaction,
            IJobContextMessage jobContextMessage)
        {
            _connection = connection;
            _transaction = transaction;
            _jobContextMessage = jobContextMessage;
        }

        public async Task StoreAsync(IMessage ilr, List<string> validLearners, CancellationToken cancellationToken)
        {
            Task fileDetailsTask = ProcessFileDetails(ilr, cancellationToken);

            await Task.WhenAll(
                ProcessLearners(ilr, validLearners, cancellationToken),
                ProcessLearnerDestinationsAndProgressions(ilr, validLearners, cancellationToken),
                fileDetailsTask);
        }

        private async Task ProcessLearners(
            IMessage ilr,
            List<string> learnersValid,
            CancellationToken cancellationToken)
        {
            _validLearnerData = new ValidLearnerData();
            _invalidLearnerData = new InvalidLearnerData();

            foreach (ILearner ilrLearner in ilr.Learners)
            {
                    foreach (ILearnerFAM learnerFaM in ilrLearner.LearnerFAMs ?? Enumerable.Empty<ILearnerFAM>())
                    {
                        recordsInvalidLearnerFams.Add(new EF.Invalid.LearnerFAM
                        {
                            LearnerFAM_Id = learnerFAMId,
                            Learner_Id = learnerId,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            LearnFAMCode = learnerFaM.LearnFAMCode,
                            LearnFAMType = learnerFaM.LearnFAMType
                        });

                        learnerFAMId++;
                    }


                    foreach (ILearnerHEFinancialSupport heFinancialSupport in ilrLearner.LearnerHEEntity?.LearnerHEFinancialSupports ?? Enumerable.Empty<ILearnerHEFinancialSupport>())
                    {
                        recordsInvalidLearnerHefinancialSupports.Add(new EF.Invalid.LearnerHEFinancialSupport
                        {
                            LearnerHEFinancialSupport_Id = learnerHEFinancialSupportId,
                            FINAMOUNT = heFinancialSupport.FINAMOUNT,
                            FINTYPE = heFinancialSupport.FINTYPE,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
                        });

                        learnerHEFinancialSupportId++;
                    }

                    foreach (ILLDDAndHealthProblem llddAndHealthProblem in ilrLearner.LLDDAndHealthProblems ?? Enumerable.Empty<ILLDDAndHealthProblem>())
                    {
                        recordsInvalidLlddandHealthProblems.Add(new EF.Invalid.LLDDandHealthProblem
                        {
                            LLDDandHealthProblem_Id = lLDDandHealthProblemId,
                            Learner_Id = learnerId,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            LLDDCat = llddAndHealthProblem.LLDDCat,
                            PrimaryLLDD = llddAndHealthProblem.PrimaryLLDDNullable,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
                        });

                        lLDDandHealthProblemId++;
                    }

                    foreach (IProviderSpecLearnerMonitoring providerSpecLearnerMonitoring in ilrLearner.ProviderSpecLearnerMonitorings ?? Enumerable.Empty<IProviderSpecLearnerMonitoring>())
                    {
                        recordsInvalidProviderSpecLearnerMonitorings.Add(new EF.Invalid.ProviderSpecLearnerMonitoring
                        {
                            ProviderSpecLearnerMonitoring_Id = providerSpecLearnerMonitoringId,
                            Learner_Id = learnerId,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            ProvSpecLearnMon = providerSpecLearnerMonitoring.ProvSpecLearnMon,
                            ProvSpecLearnMonOccur = providerSpecLearnerMonitoring.ProvSpecLearnMonOccur
                        });

                        providerSpecLearnerMonitoringId++;
                    }

                    learnerId++;
                }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await SaveLearnerRecords(cancellationToken);
        }

        private async Task SaveLearnerRecords(CancellationToken cancellationToken)
        {
            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("Invalid.AppFinRecord", _invalidLearnerData.RecordsInvalidAppFinRecords);
                await bulkInsert.Insert("Invalid.ContactPreference", _invalidLearnerData.RecordsInvalidContactPreferences);
                await bulkInsert.Insert("Invalid.EmploymentStatusMonitoring", _invalidLearnerData.RecordsInvalidEmploymentStatusMonitorings);
                await bulkInsert.Insert("Invalid.Learner", _invalidLearnerData.RecordsInvalidLearners);
                await bulkInsert.Insert("Invalid.LearnerEmploymentStatus", _invalidLearnerData.RecordsInvalidLearnerEmploymentStatus);
                await bulkInsert.Insert("Invalid.LearnerFAM", _invalidLearnerData.RecordsInvalidLearnerFams);
                await bulkInsert.Insert("Invalid.LearnerHE", _invalidLearnerData.RecordsInvalidLearnerHes);
                await bulkInsert.Insert("Invalid.LearnerHEFinancialSupport", _invalidLearnerData.RecordsInvalidLearnerHefinancialSupports);
                await bulkInsert.Insert("Invalid.LearningDelivery", _invalidLearnerData.RecordsInvalidLearningDeliverys);
                await bulkInsert.Insert("Invalid.LearningDeliveryFAM", _invalidLearnerData.RecordsInvalidLearnerDeliveryFams);
                await bulkInsert.Insert("Invalid.LearningDeliveryHE", _invalidLearnerData.RecordsInvalidLearningDeliveryHes);
                await bulkInsert.Insert("Invalid.LearningDeliveryWorkPlacement", _invalidLearnerData.RecordsInvalidLearningDeliveryWorkPlacements);
                await bulkInsert.Insert("Invalid.LLDDandHealthProblem", _invalidLearnerData.RecordsInvalidLlddandHealthProblems);
                await bulkInsert.Insert("Invalid.ProviderSpecDeliveryMonitoring", _invalidLearnerData.RecordsInvalidProviderSpecDeliveryMonitorings);
                await bulkInsert.Insert("Invalid.ProviderSpecLearnerMonitoring", _invalidLearnerData.RecordsInvalidProviderSpecLearnerMonitorings);

                await bulkInsert.Insert("Valid.AppFinRecord", _validLearnerData.RecordsValidAppFinRecords);
                await bulkInsert.Insert("Valid.ContactPreference", _validLearnerData.RecordsValidContactPreferences);
                await bulkInsert.Insert("Valid.EmploymentStatusMonitoring", _validLearnerData.RecordsValidEmploymentStatusMonitorings);
                await bulkInsert.Insert("Valid.Learner", _validLearnerData.RecordsValidLearners);
                await bulkInsert.Insert("Valid.LearnerEmploymentStatus", _validLearnerData.RecordsValidLearnerEmploymentStatus);
                await bulkInsert.Insert("Valid.LearnerFAM", _validLearnerData.RecordsValidLearnerFams);
                await bulkInsert.Insert("Valid.LearnerHE", _validLearnerData.RecordsValidLearnerHes);
                await bulkInsert.Insert("Valid.LearnerHEFinancialSupport", _validLearnerData.RecordsValidLearnerHefinancialSupports);
                await bulkInsert.Insert("Valid.LearningDelivery", _validLearnerData.RecordsValidLearningDeliverys);
                await bulkInsert.Insert("Valid.LearningDeliveryFAM", _validLearnerData.RecordsValidLearnerDeliveryFams);
                await bulkInsert.Insert("Valid.LearningDeliveryHE", _validLearnerData.RecordsValidLearningDeliveryHes);
                await bulkInsert.Insert("Valid.LearningDeliveryWorkPlacement", _validLearnerData.RecordsValidLearningDeliveryWorkPlacements);
                await bulkInsert.Insert("Valid.LLDDandHealthProblem", _validLearnerData.RecordsValidLlddandHealthProblems);
                await bulkInsert.Insert("Valid.ProviderSpecDeliveryMonitoring", _validLearnerData.RecordsValidProviderSpecDeliveryMonitorings);
                await bulkInsert.Insert("Valid.ProviderSpecLearnerMonitoring", _validLearnerData.RecordsValidProviderSpecLearnerMonitorings);
            }
        }

        private async Task ProcessFileDetails(IMessage ilr, CancellationToken cancellationToken)
        {
            DateTime nowUtc = DateTime.UtcNow;

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
                SourceFileName = _jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString()
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
                SourceFileName = _jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString()
            };

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("Valid.CollectionDetails", new List<EF.Valid.CollectionDetail> { collectionDetailsValid });
                await bulkInsert.Insert("Valid.LearningProvider", new List<EF.Valid.LearningProvider> { learningProviderValid });
                await bulkInsert.Insert("Valid.Source", new List<EF.Valid.Source> { sourceValid });
                await bulkInsert.Insert("Valid.SourceFile", new List<EF.Valid.SourceFile> { sourceFileValid });

                await bulkInsert.Insert("Invalid.CollectionDetails", new List<EF.Invalid.CollectionDetail> { collectionDetailsInvalid });
                await bulkInsert.Insert("Invalid.LearningProvider", new List<EF.Invalid.LearningProvider> { learningProviderInvalid });
                await bulkInsert.Insert("Invalid.Source", new List<EF.Invalid.Source> { sourceInvalid });
                await bulkInsert.Insert("Invalid.SourceFile", new List<EF.Invalid.SourceFile> { sourceFileInvalid });
            }
        }

        private async Task ProcessLearnerDestinationsAndProgressions(
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

            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("Invalid.DPOutcome", recordsInvalidDpoutcomes);
                await bulkInsert.Insert("Invalid.LearnerDestinationandProgression", recordsInvalidLearnerDestinationandProgressions);
                await bulkInsert.Insert("Valid.DPOutcome", recordsValidDpoutcomes);
                await bulkInsert.Insert("Valid.LearnerDestinationandProgression", recordsValidLearnerDestinationandProgressions);
            }
        }
    }
}