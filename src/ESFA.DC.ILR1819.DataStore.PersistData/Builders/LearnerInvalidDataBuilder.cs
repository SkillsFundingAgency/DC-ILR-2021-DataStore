using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearnerInvalidDataBuilder : ILearnerInvalidDataBuilder
    {
        private readonly InvalidLearnerData _invalidLearnerData;

        public LearnerInvalidDataBuilder()
        {
            _invalidLearnerData = new InvalidLearnerData();
        }

        public InvalidLearnerData BuildInvalidLearnerData(IMessage ilr, List<string> learnersValid)
        {
            var ukprn = ilr.LearningProviderEntity.UKPRN;

            var learners = ilr.Learners
                .Where(l => !learnersValid.Contains(l.LearnRefNumber, StringComparer.OrdinalIgnoreCase)).ToList();

            PopulateInvalidLearners(ukprn, learners);

            return _invalidLearnerData;
        }

        private void PopulateInvalidLearners(int ukprn, List<ILearner> learners)
        {
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

            learners.ForEach(learner =>
            {
                _invalidLearnerData.RecordsInvalidLearners.Add(LearnerBuilder.BuildInvalidLearner(ukprn, learner, learnerId));

                learner.ContactPreferences?.ToList().ForEach(contactPreference => PopulateContactPreferences(ukprn, learner, contactPreference, learnerId, contactPreferenceId++));

                learner.LearningDeliveries?.ToList().ForEach(learningDelivery =>
                {
                    PopulateLearningDelivery(ukprn, learner, learningDelivery, learnerId, learnerDeliveryId);

                    if (learningDelivery.LearningDeliveryHEEntity != null)
                    {
                        PopulateLearningDeliveryHERecord(ukprn, learner, learningDelivery, learningDelivery.LearningDeliveryHEEntity, learningDeliveryHEId++);
                    }

                    learningDelivery.AppFinRecords?.ToList()
                        .ForEach(appFinRecord =>
                            PopulateLearningDeliveryAppFinRecord(ukprn, learner, learningDelivery, appFinRecord, learnerDeliveryId, appFinRecordId++));

                    learningDelivery.LearningDeliveryFAMs?.ToList()
                        .ForEach(famRecord =>
                            PopulateLearningDeliveryFAMRecord(ukprn, learner, learningDelivery, famRecord, learnerDeliveryId, learnerDeliveryFamId++));

                    learningDelivery.LearningDeliveryWorkPlacements?.ToList()
                        .ForEach(workPlacement =>
                            PopulateLearningDeliveryWorkPlacement(ukprn, learner, learningDelivery, workPlacement, learnerDeliveryId, learningDeliveryWorkPlacementId++));

                    learningDelivery.ProviderSpecDeliveryMonitorings?.ToList()
                        .ForEach(monitoring =>
                            PopulateProviderSpecDeliveryMonitoring(ukprn, learner, learningDelivery, monitoring, learnerDeliveryId, providerSpecDeliveryMonitoringId++));

                    learnerDeliveryId++;
                });

                learner.LearnerEmploymentStatuses?.ToList()
                    .ForEach(employmentStatus =>
                    {
                        PopulateLearnerEmploymentStatus(ukprn, learner, employmentStatus, learnerId, learnerEmploymentStatusId);

                        employmentStatus.EmploymentStatusMonitorings?.ToList()
                            .ForEach(monitoring =>
                                PopulateEmploymentStatusMonitoring(ukprn, learner, employmentStatus, monitoring, learnerEmploymentStatusId, learnerEmploymentStatusMonitoringId++));

                        learnerEmploymentStatusId++;
                    });

                learner.LearnerFAMs?.ToList()
                    .ForEach(fam => PopulateLearnerFAM(ukprn, learner, fam, learnerId, learnerFAMId++));

                if (learner.LearnerHEEntity != null)
                {
                    PopulateLearnerHE(ukprn, learner, learnerId, learnerHEId++);
                    learner.LearnerHEEntity.LearnerHEFinancialSupports?.ToList()
                        .ForEach(support => PopulateLearnerHEFinancialSupport(ukprn, learner, support, learnerHEFinancialSupportId++));
                }

                learner.LLDDAndHealthProblems?.ToList()
                    .ForEach(problem => PopulateLLDDAndHealthProblem(ukprn, learner, problem, learnerId, lLDDandHealthProblemID++));

                learner.ProviderSpecLearnerMonitorings?.ToList()
                    .ForEach(monitoring => PopulateProviderSpecLearnerMonitorings(ukprn, learner, monitoring, learnerId, providerSpecLearnerMonitoringId++));

                learnerId++;
            });
        }

        private void PopulateContactPreferences(
            int ukprn,
            ILearner learner,
            IContactPreference contactPreference,
            int learnerId,
            int contactPreferenceId)
        {
           _invalidLearnerData.RecordsInvalidContactPreferences.Add(
               ContactPreferenceBuilder.BuildInvalidContactPreference(ukprn, learner, contactPreference, learnerId, contactPreferenceId));
        }

        private void PopulateLearningDelivery(int ukprn, ILearner learner, ILearningDelivery learningDelivery, int learnerId, int deliveryId)
        {
            _invalidLearnerData.RecordsInvalidLearningDeliverys.Add(
                LearningDeliveryBuilder.BuildInvalidLearningDelivery(ukprn, learner, learningDelivery, learnerId, deliveryId));
        }

        private void PopulateLearningDeliveryAppFinRecord(
            int ukprn,
            ILearner learner,
            ILearningDelivery learningDelivery,
            IAppFinRecord appFinRecord,
            int learnerDeliveryId,
            int appFinRecordId)
        {
            _invalidLearnerData.RecordsInvalidAppFinRecords.Add(
                AppFinRecordBuilder.BuildInvalidAppFinRecord(ukprn, learner, learningDelivery, appFinRecord, learnerDeliveryId, appFinRecordId));
        }

        private void PopulateLearningDeliveryFAMRecord(
            int ukprn,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryFAM famRecord,
            int learnerDeliveryId,
            int famId)
        {
            _invalidLearnerData.RecordsInvalidLearnerDeliveryFams.Add(
                LearningDeliveryFAMBuilder.BuildInvalidFamRecord(ukprn, learner, learningDelivery, famRecord, learnerDeliveryId, famId));
        }

        private void PopulateLearningDeliveryHERecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryHE heRecord, int id)
        {
            _invalidLearnerData.RecordsInvalidLearningDeliveryHes.Add(LearningDeliveryHEBuilder.BuildInvalidHERecord(ukprn, learner, learningDelivery, heRecord, id));
        }

        private void PopulateLearningDeliveryWorkPlacement(
            int ukprn,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryWorkPlacement workPlacement,
            int learnerDeliveryId,
            int learningDeliveryWorkPlacementId)
        {
            _invalidLearnerData.RecordsInvalidLearningDeliveryWorkPlacements
                .Add(LearningDeliveryWorkPlacementBuilder
                    .BuildInvalidWorkPlacementRecord(ukprn, learner, learningDelivery, workPlacement, learnerDeliveryId, learningDeliveryWorkPlacementId));
        }

        private void PopulateProviderSpecDeliveryMonitoring(
            int ukprn,
            ILearner learner,
            ILearningDelivery learningDelivery,
            IProviderSpecDeliveryMonitoring monitoring,
            int learnerDeliveryId,
            int providerSpecDeliveryMonitoringId)
        {
            _invalidLearnerData.RecordsInvalidProviderSpecDeliveryMonitorings
                .Add(ProviderSpecDeliveryMonitoringBuilder
                    .BuildInvalidProviderSpecDeliveryMonitoringRecord(ukprn, learner, learningDelivery, monitoring, learnerDeliveryId, providerSpecDeliveryMonitoringId));
        }

        private void PopulateLearnerEmploymentStatus(
            int ukprn,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus,
            int learnerId,
            int learnerEmploymentStatusId)
        {
            _invalidLearnerData.RecordsInvalidLearnerEmploymentStatus
                .Add(LearnerEmploymentStatusBuilder
                    .BuildInvalidLearnerEmploymentStatus(ukprn, learner, learnerEmploymentStatus, learnerId, learnerEmploymentStatusId));
        }

        private void PopulateEmploymentStatusMonitoring(
            int ukprn,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus,
            IEmploymentStatusMonitoring employmentStatusMonitoring,
            int learnerEmploymentStatusId,
            int learnerEmploymentStatusMonitoringId)
        {
            _invalidLearnerData.RecordsInvalidEmploymentStatusMonitorings
                .Add(EmploymentStatusMonitoringBuilder
                    .BuildInvalidEmploymentStatusMonitoring(
                        ukprn, learner, learnerEmploymentStatus, employmentStatusMonitoring, learnerEmploymentStatusId, learnerEmploymentStatusMonitoringId));
        }

        private void PopulateLearnerFAM(
            int ukprn,
            ILearner learner,
            ILearnerFAM fam,
            int learnerId,
            int learnerFAMId)
        {
            _invalidLearnerData.RecordsInvalidLearnerFams
                .Add(LearnerFAMBuilder.BuildInvalidLearnerFAM(ukprn, learner, fam, learnerId, learnerFAMId));
        }

        private void PopulateLearnerHE(int ukprn, ILearner learner, int learnerId, int learnerHEId)
        {
            _invalidLearnerData.RecordsInvalidLearnerHes
                .Add(LearnerHEBuilder.BuildInvalidLearnerHE(ukprn, learner, learnerId, learnerHEId));
        }

        private void PopulateLearnerHEFinancialSupport(
            int ukprn,
            ILearner learner,
            ILearnerHEFinancialSupport support,
            int learnerHEFinancialSupportId)
        {
            _invalidLearnerData.RecordsInvalidLearnerHefinancialSupports
                .Add(LearnerHEFinancialSupportBuilder.BuildInvalidLearnerHEFinancialSupport(ukprn, learner, support, learnerHEFinancialSupportId));
        }

        private void PopulateLLDDAndHealthProblem(
            int ukprn,
            ILearner learner,
            ILLDDAndHealthProblem problem,
            int learnerId,
            int lLDDandHealthProblemId)
        {
            _invalidLearnerData.RecordsInvalidLlddandHealthProblems
                .Add(LLDDAndHealthProblemBuilder.BuildInvalidLLDDandHealthProblem(ukprn, learner, problem, learnerId, lLDDandHealthProblemId));
        }

        private void PopulateProviderSpecLearnerMonitorings(
            int ukprn,
            ILearner learner,
            IProviderSpecLearnerMonitoring monitoring,
            int learnerId,
            int providerSpecLearnerMonitoringId)
        {
            _invalidLearnerData.RecordsInvalidProviderSpecLearnerMonitorings
                .Add(ProviderSpecLearnerMonitoringBuilder
                    .BuildInvalidProviderSpecLearnerMonitoring(ukprn, learner, monitoring, learnerId, providerSpecLearnerMonitoringId));
        }
    }
}
