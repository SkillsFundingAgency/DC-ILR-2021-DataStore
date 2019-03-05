using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class InvalidLearnerDataMapper : IInvalidLearnerDataMapper
    {
        public InvalidLearnerData MapInvalidLearnerData(IMessage ilr, IEnumerable<string> learnersValid)
        {
            var ukprn = ilr.LearningProviderEntity.UKPRN;

            var learners = ilr.Learners?.Where(l => !learnersValid.Contains(l.LearnRefNumber, StringComparer.OrdinalIgnoreCase));

            var learnerDestinationAndProgressions = ilr.LearnerDestinationAndProgressions?.Where(ldp => !learnersValid.Contains(ldp.LearnRefNumber, StringComparer.OrdinalIgnoreCase));

            return PopulateInvalidLearners(ukprn, learners, learnerDestinationAndProgressions);
        }

        private InvalidLearnerData PopulateInvalidLearners(int ukprn, IEnumerable<ILearner> learners, IEnumerable<ILearnerDestinationAndProgression> learnerDestinationAndProgressions)
        {
            var invalidLearnerData = new InvalidLearnerData();

            int learnerId = 1;
            int learnerDeliveryId = 1;
            int learnerEmploymentStatusId = 1;
            int learnerEmploymentStatusMonitoringId = 1;
            int learningDeliveryHEId = 1;
            int learnerDeliveryFamId = 1;
            int appFinRecordId = 1;
            int learningDeliveryWorkPlacementId = 1;
            int learnerFAMId = 1;
            int learnerHEId = 1;
            int learnerHEFinancialSupportId = 1;
            int providerSpecLearnerMonitoringId = 1;
            int providerSpecDeliveryMonitoringId = 1;
            int contactPreferenceId = 1;
            int lLDDandHealthProblemID = 1;
            int learnerDestinationandProgressionId = 1;
            int dPOutcomeId = 1;

            learners.NullSafeForEach(learner =>
            {
                invalidLearnerData.RecordsInvalidLearners.Add(LearnerBuilder.BuildInvalidLearner(ukprn, learner, learnerId));

                learner.ContactPreferences.NullSafeForEach(
                    contactPreference =>
                        PopulateContactPreferences(ukprn, learner, contactPreference, learnerId, contactPreferenceId++, invalidLearnerData));

                learner.LearningDeliveries.NullSafeForEach(learningDelivery =>
                {
                    PopulateLearningDelivery(ukprn, learner, learningDelivery, learnerId, learnerDeliveryId, invalidLearnerData);

                    if (learningDelivery.LearningDeliveryHEEntity != null)
                    {
                        PopulateLearningDeliveryHERecord(ukprn, learner, learningDelivery, learningDelivery.LearningDeliveryHEEntity, learningDeliveryHEId++, invalidLearnerData);
                    }

                    learningDelivery.AppFinRecords.NullSafeForEach(
                        appFinRecord =>
                            PopulateLearningDeliveryAppFinRecord(ukprn, learner, learningDelivery, appFinRecord, learnerDeliveryId, appFinRecordId++, invalidLearnerData));

                    learningDelivery.LearningDeliveryFAMs.NullSafeForEach(
                        famRecord =>
                            PopulateLearningDeliveryFAMRecord(ukprn, learner, learningDelivery, famRecord, learnerDeliveryId, learnerDeliveryFamId++, invalidLearnerData));

                    learningDelivery.LearningDeliveryWorkPlacements.NullSafeForEach(workPlacement =>
                            PopulateLearningDeliveryWorkPlacement(ukprn, learner, learningDelivery, workPlacement, learnerDeliveryId, learningDeliveryWorkPlacementId++, invalidLearnerData));

                    learningDelivery.ProviderSpecDeliveryMonitorings.NullSafeForEach(monitoring =>
                            PopulateProviderSpecDeliveryMonitoring(ukprn, learner, learningDelivery, monitoring, learnerDeliveryId, providerSpecDeliveryMonitoringId++, invalidLearnerData));

                    learnerDeliveryId++;
                });

                learner.LearnerEmploymentStatuses.NullSafeForEach(employmentStatus =>
                    {
                        PopulateLearnerEmploymentStatus(ukprn, learner, employmentStatus, learnerId, learnerEmploymentStatusId, invalidLearnerData);

                        employmentStatus.EmploymentStatusMonitorings?.ToList()
                            .ForEach(monitoring =>
                                PopulateEmploymentStatusMonitoring(ukprn, learner, employmentStatus, monitoring, learnerEmploymentStatusId, learnerEmploymentStatusMonitoringId++, invalidLearnerData));

                        learnerEmploymentStatusId++;
                    });

                learner.LearnerFAMs.NullSafeForEach(fam => PopulateLearnerFAM(ukprn, learner, fam, learnerId, learnerFAMId++, invalidLearnerData));

                if (learner.LearnerHEEntity != null)
                {
                    PopulateLearnerHE(ukprn, learner, learnerId, learnerHEId++, invalidLearnerData);

                    learner.LearnerHEEntity.LearnerHEFinancialSupports.NullSafeForEach(support => PopulateLearnerHEFinancialSupport(ukprn, learner, support, learnerHEFinancialSupportId++, invalidLearnerData));
                }

                learner.LLDDAndHealthProblems.NullSafeForEach(problem => PopulateLLDDAndHealthProblem(ukprn, learner, problem, learnerId, lLDDandHealthProblemID++, invalidLearnerData));

                learner.ProviderSpecLearnerMonitorings.NullSafeForEach(monitoring => PopulateProviderSpecLearnerMonitorings(ukprn, learner, monitoring, learnerId, providerSpecLearnerMonitoringId++, invalidLearnerData));

                learnerId++;
            });

            learnerDestinationAndProgressions.NullSafeForEach(learnerDestinationAndProgression =>
            {
                invalidLearnerData.RecordsInvalidLearnerDestinationandProgressions.Add(new EF.Invalid.LearnerDestinationandProgression
                {
                    LearnerDestinationandProgression_Id = learnerDestinationandProgressionId,
                    UKPRN = ukprn,
                    LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                    ULN = learnerDestinationAndProgression.ULN
                });

                learnerDestinationAndProgression.DPOutcomes.NullSafeForEach(dpOutcome =>
                {
                    invalidLearnerData.RecordsInvalidDpOutcomes.Add(new EF.Invalid.DPOutcome
                    {
                        DPOutcome_Id = dPOutcomeId,
                        LearnerDestinationandProgression_Id = learnerDestinationandProgressionId,
                        LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                        OutCode = dpOutcome.OutCode,
                        UKPRN = ukprn,
                        OutCollDate = dpOutcome.OutCollDate,
                        OutEndDate = dpOutcome.OutEndDateNullable,
                        OutStartDate = dpOutcome.OutStartDate,
                        OutType = dpOutcome.OutType
                    });

                    dPOutcomeId++;
                });

                learnerDestinationandProgressionId++;
            });

            return invalidLearnerData;
        }

        private void PopulateContactPreferences(int ukprn, ILearner learner, IContactPreference contactPreference, int learnerId, int contactPreferenceId, InvalidLearnerData invalidLearnerData)
        {
           invalidLearnerData.RecordsInvalidContactPreferences.Add(ContactPreferenceBuilder.BuildInvalidContactPreference(ukprn, learner, contactPreference, learnerId, contactPreferenceId));
        }

        private void PopulateLearningDelivery(int ukprn, ILearner learner, ILearningDelivery learningDelivery, int learnerId, int deliveryId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLearningDeliverys.Add(LearningDeliveryBuilder.BuildInvalidLearningDelivery(ukprn, learner, learningDelivery, learnerId, deliveryId));
        }

        private void PopulateLearningDeliveryAppFinRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IAppFinRecord appFinRecord, int learnerDeliveryId, int appFinRecordId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidAppFinRecords.Add(AppFinRecordBuilder.BuildInvalidAppFinRecord(ukprn, learner, learningDelivery, appFinRecord, learnerDeliveryId, appFinRecordId));
        }

        private void PopulateLearningDeliveryFAMRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryFAM famRecord, int learnerDeliveryId, int famId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLearnerDeliveryFams.Add(LearningDeliveryFAMBuilder.BuildInvalidFamRecord(ukprn, learner, learningDelivery, famRecord, learnerDeliveryId, famId));
        }

        private void PopulateLearningDeliveryHERecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryHE heRecord, int id, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLearningDeliveryHes.Add(LearningDeliveryHEBuilder.BuildInvalidHERecord(ukprn, learner, learningDelivery, heRecord, id));
        }

        private void PopulateLearningDeliveryWorkPlacement(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryWorkPlacement workPlacement, int learnerDeliveryId, int learningDeliveryWorkPlacementId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLearningDeliveryWorkPlacements.Add(LearningDeliveryWorkPlacementBuilder.BuildInvalidWorkPlacementRecord(ukprn, learner, learningDelivery, workPlacement, learnerDeliveryId, learningDeliveryWorkPlacementId));
        }

        private void PopulateProviderSpecDeliveryMonitoring(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IProviderSpecDeliveryMonitoring monitoring, int learnerDeliveryId, int providerSpecDeliveryMonitoringId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidProviderSpecDeliveryMonitorings.Add(ProviderSpecDeliveryMonitoringBuilder.BuildInvalidProviderSpecDeliveryMonitoringRecord(ukprn, learner, learningDelivery, monitoring, learnerDeliveryId, providerSpecDeliveryMonitoringId));
        }

        private void PopulateLearnerEmploymentStatus(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, int learnerId, int learnerEmploymentStatusId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLearnerEmploymentStatus.Add(LearnerEmploymentStatusBuilder.BuildInvalidLearnerEmploymentStatus(ukprn, learner, learnerEmploymentStatus, learnerId, learnerEmploymentStatusId));
        }

        private void PopulateEmploymentStatusMonitoring(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, IEmploymentStatusMonitoring employmentStatusMonitoring, int learnerEmploymentStatusId, int learnerEmploymentStatusMonitoringId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidEmploymentStatusMonitorings.Add(EmploymentStatusMonitoringBuilder.BuildInvalidEmploymentStatusMonitoring(ukprn, learner, learnerEmploymentStatus, employmentStatusMonitoring, learnerEmploymentStatusId, learnerEmploymentStatusMonitoringId));
        }

        private void PopulateLearnerFAM(int ukprn, ILearner learner, ILearnerFAM fam, int learnerId, int learnerFAMId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLearnerFams.Add(LearnerFAMBuilder.BuildInvalidLearnerFAM(ukprn, learner, fam, learnerId, learnerFAMId));
        }

        private void PopulateLearnerHE(int ukprn, ILearner learner, int learnerId, int learnerHEId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLearnerHes.Add(LearnerHEBuilder.BuildInvalidLearnerHE(ukprn, learner, learnerId, learnerHEId));
        }

        private void PopulateLearnerHEFinancialSupport(int ukprn, ILearner learner, ILearnerHEFinancialSupport support, int learnerHEFinancialSupportId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLearnerHefinancialSupports.Add(LearnerHEFinancialSupportBuilder.BuildInvalidLearnerHEFinancialSupport(ukprn, learner, support, learnerHEFinancialSupportId));
        }

        private void PopulateLLDDAndHealthProblem(int ukprn, ILearner learner, ILLDDAndHealthProblem problem, int learnerId, int lLDDandHealthProblemId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidLlddandHealthProblems.Add(LLDDAndHealthProblemBuilder.BuildInvalidLLDDandHealthProblem(ukprn, learner, problem, learnerId, lLDDandHealthProblemId));
        }

        private void PopulateProviderSpecLearnerMonitorings(int ukprn, ILearner learner, IProviderSpecLearnerMonitoring monitoring, int learnerId, int providerSpecLearnerMonitoringId, InvalidLearnerData invalidLearnerData)
        {
            invalidLearnerData.RecordsInvalidProviderSpecLearnerMonitorings.Add(ProviderSpecLearnerMonitoringBuilder.BuildInvalidProviderSpecLearnerMonitoring(ukprn, learner, monitoring, learnerId, providerSpecLearnerMonitoringId));
        }
    }
}
