using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Valid;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class ValidLearnerDataMapper : IValidLearnerDataMapper
    {
        public ValidLearnerData MapLearnerData(IMessage ilr, IEnumerable<string> learnersValid)
        {
            var ukprn = ilr.LearningProviderEntity.UKPRN;

            var header = ilr.HeaderEntity;
            var sourceFileCollection = ilr.SourceFilesCollection;
            var learners = ilr.Learners?.Where(l => learnersValid.Contains(l.LearnRefNumber, StringComparer.OrdinalIgnoreCase));
            var destinationAndProgressions = ilr.LearnerDestinationAndProgressions?.Where(ldp => learnersValid.Contains(ldp.LearnRefNumber, StringComparer.OrdinalIgnoreCase));

            return PopulateValidLearners(ukprn, header, sourceFileCollection, learners, destinationAndProgressions);
        }

        private ValidLearnerData PopulateValidLearners(int ukprn, IHeader header, IReadOnlyCollection<ISourceFile> sourceFileCollection, IEnumerable<ILearner> learners, IEnumerable<ILearnerDestinationAndProgression> destinationAndProgressions)
        {
            var validLearnerData = new ValidLearnerData();

            validLearnerData.CollectionDetails = new List<CollectionDetail>
            {
                new CollectionDetail
                {
                    UKPRN = ukprn,
                    Collection = header.CollectionDetailsEntity.CollectionString,
                    FilePreparationDate = header.CollectionDetailsEntity.FilePreparationDate,
                    Year = header.CollectionDetailsEntity.YearString,
                },
            };

            validLearnerData.LearningProviders = new List<LearningProvider>
            {
                new LearningProvider
                {
                    UKPRN = ukprn,
                },
            };

            var source = header.SourceEntity;

            validLearnerData.Sources = new List<Source>
            {
                new Source
                {
                    UKPRN = ukprn,
                    ComponentSetVersion = source.ComponentSetVersion,
                    DateTime = source.DateTime,
                    ProtectiveMarking = source.ProtectiveMarkingString,
                    ReferenceData = source.ReferenceData,
                    Release = source.Release,
                    SerialNo = source.SerialNo,
                    SoftwarePackage = source.SoftwarePackage,
                    SoftwareSupplier = source.SoftwareSupplier,
                },
            };

            validLearnerData.SourceFiles = sourceFileCollection?
                                              .Select(sf => new SourceFile
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
                                           ?? new List<SourceFile>();

            int lLDDandHealthProblemID = 1;
            int learningDeliveryFamId = 1;

            learners.NullSafeForEach(learner =>
            {
                validLearnerData.RecordsValidLearners.Add(LearnerBuilder.BuildValidLearner(ukprn, learner));

                learner.ContactPreferences.NullSafeForEach(contactPreference => PopulateContactPreferences(ukprn, learner, contactPreference, validLearnerData));
                learner.LearningDeliveries.NullSafeForEach(learningDelivery =>
                {
                    PopulateLearningDelivery(ukprn, learner, learningDelivery, validLearnerData);

                    if (learningDelivery.LearningDeliveryHEEntity != null)
                    {
                        PopulateLearningDeliveryHERecord(ukprn, learner, learningDelivery, learningDelivery.LearningDeliveryHEEntity, validLearnerData);
                    }

                    learningDelivery.AppFinRecords.NullSafeForEach(appFinRecord => PopulateLearningDeliveryAppFinRecord(ukprn, learner, learningDelivery, appFinRecord, validLearnerData));
                    learningDelivery.LearningDeliveryFAMs.NullSafeForEach(famRecord => PopulateLearningDeliveryFAMRecord(ukprn, learner, learningDelivery, famRecord, learningDeliveryFamId++, validLearnerData));
                    learningDelivery.LearningDeliveryWorkPlacements.NullSafeForEach(workPlacement => PopulateLearningDeliveryWorkPlacement(ukprn, learner, learningDelivery, workPlacement, validLearnerData));
                    learningDelivery.ProviderSpecDeliveryMonitorings.NullSafeForEach(monitoring => PopulateProviderSpecDeliveryMonitoring(ukprn, learner, learningDelivery, monitoring, validLearnerData));
                });

                learner.LearnerEmploymentStatuses.NullSafeForEach(employmentStatus =>
                    {
                        PopulateLearnerEmploymentStatus(ukprn, learner, employmentStatus, validLearnerData);

                        employmentStatus.EmploymentStatusMonitorings.NullSafeForEach(monitoring => PopulateEmploymentStatusMonitoring(ukprn, learner, employmentStatus, monitoring, validLearnerData));
                    });

                learner.LearnerFAMs.NullSafeForEach(fam => PopulateLearnerFAM(ukprn, learner, fam, validLearnerData));

                if (learner.LearnerHEEntity != null)
                {
                    PopulateLearnerHE(ukprn, learner, validLearnerData);
                    learner.LearnerHEEntity.LearnerHEFinancialSupports.NullSafeForEach(support => PopulateLearnerHEFinancialSupport(ukprn, learner, support, validLearnerData));
                }

                learner.LLDDAndHealthProblems.NullSafeForEach(problem => PopulateLLDDAndHealthProblem(ukprn, learner, problem, lLDDandHealthProblemID++, validLearnerData));

                learner.ProviderSpecLearnerMonitorings.NullSafeForEach(monitoring => PopulateProviderSpecLearnerMonitorings(ukprn, learner, monitoring, validLearnerData));
            });

            destinationAndProgressions.NullSafeForEach(destinationAndProgression =>
            {
                validLearnerData.RecordsValidLearnerDestinationandProgressions.Add(new ILR1819.DataStore.EF.Valid.LearnerDestinationandProgression
                {
                    UKPRN = ukprn,
                    LearnRefNumber = destinationAndProgression.LearnRefNumber,
                    ULN = destinationAndProgression.ULN
                });

                destinationAndProgression.DPOutcomes.NullSafeForEach(dpOutcome =>
                {
                    validLearnerData.RecordsValidDpOutcomes.Add(new ILR1819.DataStore.EF.Valid.DPOutcome
                    {
                        LearnRefNumber = destinationAndProgression.LearnRefNumber,
                        OutCode = dpOutcome.OutCode,
                        UKPRN = ukprn,
                        OutCollDate = dpOutcome.OutCollDate,
                        OutEndDate = dpOutcome.OutEndDateNullable,
                        OutStartDate = dpOutcome.OutStartDate,
                        OutType = dpOutcome.OutType
                    });
                });
            });

            return validLearnerData;
        }

        private void PopulateContactPreferences(int ukprn, ILearner learner, IContactPreference contactPreference, ValidLearnerData validLearnerData)
        {
           validLearnerData.RecordsValidContactPreferences.Add(ContactPreferenceBuilder.BuildValidContactPreference(ukprn, learner, contactPreference));
        }

        private void PopulateLearningDelivery(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLearningDeliverys.Add(LearningDeliveryBuilder.BuildValidLearningDelivery(ukprn, learner, learningDelivery));
        }

        private void PopulateLearningDeliveryAppFinRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IAppFinRecord appFinRecord, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidAppFinRecords.Add(AppFinRecordBuilder.BuildValidAppFinRecord(ukprn, learner, learningDelivery, appFinRecord));
        }

        private void PopulateLearningDeliveryFAMRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryFAM famRecord, int id, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLearnerDeliveryFams.Add(LearningDeliveryFAMBuilder.BuildValidFamRecord(ukprn, learner, learningDelivery, famRecord, id));
        }

        private void PopulateLearningDeliveryHERecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryHE heRecord, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLearningDeliveryHes.Add(LearningDeliveryHEBuilder.BuildValidHERecord(ukprn, learner, learningDelivery, heRecord));
        }

        private void PopulateLearningDeliveryWorkPlacement(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryWorkPlacement workPlacement, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLearningDeliveryWorkPlacements.Add(LearningDeliveryWorkPlacementBuilder.BuildValidWorkPlacementRecord(ukprn, learner, learningDelivery, workPlacement));
        }

        private void PopulateProviderSpecDeliveryMonitoring(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IProviderSpecDeliveryMonitoring monitoring, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidProviderSpecDeliveryMonitorings.Add(ProviderSpecDeliveryMonitoringBuilder.BuildValidProviderSpecDeliveryMonitoringRecord(ukprn, learner, learningDelivery, monitoring));
        }

        private void PopulateLearnerEmploymentStatus(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLearnerEmploymentStatus.Add(LearnerEmploymentStatusBuilder.BuildValidLearnerEmploymentStatus(ukprn, learner, learnerEmploymentStatus));
        }

        private void PopulateEmploymentStatusMonitoring(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, IEmploymentStatusMonitoring employmentStatusMonitoring, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidEmploymentStatusMonitorings.Add(EmploymentStatusMonitoringBuilder.BuildValidEmploymentStatusMonitoring(ukprn, learner, learnerEmploymentStatus, employmentStatusMonitoring));
        }

        private void PopulateLearnerFAM(int ukprn, ILearner learner, ILearnerFAM fam, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLearnerFams.Add(LearnerFAMBuilder.BuildValidLearnerFAM(ukprn, learner, fam));
        }

        private void PopulateLearnerHE(int ukprn, ILearner learner, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLearnerHes.Add(LearnerHEBuilder.BuildValidLearnerHE(ukprn, learner));
        }

        private void PopulateLearnerHEFinancialSupport(int ukprn, ILearner learner, ILearnerHEFinancialSupport support, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLearnerHefinancialSupports.Add(LearnerHEFinancialSupportBuilder.BuildValidLearnerHEFinancialSupport(ukprn, learner, support));
        }

        private void PopulateLLDDAndHealthProblem(int ukprn, ILearner learner, ILLDDAndHealthProblem problem, int id, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidLlddandHealthProblems.Add(LLDDAndHealthProblemBuilder.BuildValidLLDDandHealthProblem(ukprn, learner, problem, id));
        }

        private void PopulateProviderSpecLearnerMonitorings(int ukprn, ILearner learner, IProviderSpecLearnerMonitoring monitoring, ValidLearnerData validLearnerData)
        {
            validLearnerData.RecordsValidProviderSpecLearnerMonitorings.Add(ProviderSpecLearnerMonitoringBuilder.BuildValidProviderSpecLearnerMonitoring(ukprn, learner, monitoring));
        }
    }
}
