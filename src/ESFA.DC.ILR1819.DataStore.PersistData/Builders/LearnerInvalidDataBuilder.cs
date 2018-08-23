using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;
using ESFA.DC.ILR1819.DataStore.PersistData.Models;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearnerInvalidDataBuilder
    {
        private InvalidLearnerData _InvalidLearnerData;

        public LearnerInvalidDataBuilder()
        {
            _InvalidLearnerData = new InvalidLearnerData();
        }

        public InvalidLearnerData BuildInvalidLearnerData(IMessage ilr, List<string> learnersInvalid)
        {
            var learners = ilr.Learners
                .Where(l => learnersInvalid.Contains(l.LearnRefNumber, StringComparer.OrdinalIgnoreCase)).ToList();

            PopulateInvalidLearners(ilr, learners);

            return null;
        }

        private void PopulateInvalidLearners(IMessage ilr, List<ILearner> learners)
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
            int lLDDandHealthProblemId = 1;
            int providerSpecLearnerMonitoringId = 1;
            int providerSpecDeliveryMonitoringId = 1;
            int contactPreferenceId = 1;
            int lLDDandHealthProblemID = 1;

            learners.ForEach(learner =>
            {
                _InvalidLearnerData.RecordsInvalidLearners.Add(LearnerBuilder.BuildInvalidLearner(ilr, learner, learnerId));

                learner.ContactPreferences.ToList().ForEach(contactPreference => { PopulateContactPreferences(ilr, learner, contactPreference, learnerId, contactPreferenceId++); });
                learner.LearningDeliveries.ToList().ForEach(learningDelivery =>
                {
                    PopulateLearningDelivery(ilr, learner, learningDelivery, learnerId, learnerDeliveryId);

                    if (learningDelivery.LearningDeliveryHEEntity != null)
                    {
                        PopulateLearningDeliveryHERecord(ilr, learner, learningDelivery, learningDelivery.LearningDeliveryHEEntity, learningDeliveryHEId++);
                    }

                    learningDelivery.AppFinRecords.ToList()
                        .ForEach(appFinRecord => { PopulateLearningDeliveryAppFinRecord(ilr, learner, learningDelivery, appFinRecord, learnerDeliveryId, appFinRecordId++); });
                    learningDelivery.LearningDeliveryFAMs.ToList()
                        .ForEach(famRecord => PopulateLearningDeliveryFAMRecord(ilr, learner, learningDelivery, famRecord, learnerDeliveryId, learnerDeliveryFamId++));
                    learningDelivery.LearningDeliveryWorkPlacements.ToList()
                        .ForEach(workPlacement => PopulateLearningDeliveryWorkPlacement(ilr, learner, learningDelivery, workPlacement, learnerDeliveryId, learningDeliveryWorkPlacementId++));
                    learningDelivery.ProviderSpecDeliveryMonitorings.ToList()
                        .ForEach(monitoring => PopulateProviderSpecDeliveryMonitoring(ilr, learner, learningDelivery, monitoring, learnerDeliveryId, providerSpecDeliveryMonitoringId++));

                    learnerDeliveryId++;
                });

                learner.LearnerEmploymentStatuses.ToList()
                    .ForEach(employmentStatus =>
                    {
                        PopulateLearnerEmploymentStatus(ilr, learner, employmentStatus, learnerId, learnerEmploymentStatusId);

                        employmentStatus.EmploymentStatusMonitorings.ToList()
                            .ForEach(monitoring => PopulateEmploymentStatusMonitoring(ilr, learner, employmentStatus, monitoring, learnerEmploymentStatusId, learnerEmploymentStatusMonitoringId++));

                        learnerEmploymentStatusId++;
                    });

                learner.LearnerFAMs.ToList()
                    .ForEach(fam => PopulateLearnerFAM(ilr, learner, fam));

                if (learner.LearnerHEEntity != null)
                {
                    PopulateLearnerHE(ilr, learner, learnerId, learnerHEId);
                    learner.LearnerHEEntity.LearnerHEFinancialSupports.ToList()
                        .ForEach(support => PopulateLearnerHEFinancialSupport(ilr, learner, support));
                    learnerHEId++;
                }

                learner.LLDDAndHealthProblems.ToList()
                    .ForEach(problem => PopulateLLDDAndHealthProblem(ilr, learner, problem, lLDDandHealthProblemID++));

                learner.ProviderSpecLearnerMonitorings.ToList()
                    .ForEach(monitoring => PopulateProviderSpecLearnerMonitorings(ilr, learner, monitoring));

                learnerId++;
            });
        }

        private void PopulateContactPreferences(IMessage ilr, ILearner learner, IContactPreference contactPreference, int learnerId, int contactPreferenceId)
        {
           _InvalidLearnerData.RecordsInvalidContactPreferences.Add(ContactPreferenceBuilder.BuildInvalidContactPreference(ilr, learner, contactPreference, learnerId, contactPreferenceId));
        }

        private void PopulateLearningDelivery(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, int learnerId, int deliveryId)
        {
            _InvalidLearnerData.RecordsInvalidLearningDeliverys.Add(LearningDeliveryBuilder.BuildInvalidLearningDelivery(ilr, learner, learningDelivery, learnerId, deliveryId));
        }

        private void PopulateLearningDeliveryAppFinRecord(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, IAppFinRecord appFinRecord, int learnerDeliveryId, int appFinRecordId)
        {
            _InvalidLearnerData.RecordsInvalidAppFinRecords.Add(AppFinRecordBuilder.BuildInvalidAppFinRecord(ilr, learner, learningDelivery, appFinRecord, learnerDeliveryId, appFinRecordId));
        }

        private void PopulateLearningDeliveryFAMRecord(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryFAM famRecord, int learnerDeliveryId, int famId)
        {
            _InvalidLearnerData.RecordsInvalidLearnerDeliveryFams.Add(LearningDeliveryFAMBuilder.BuildInvalidFamRecord(ilr, learner, learningDelivery, famRecord, learnerDeliveryId, famId));
        }

        private void PopulateLearningDeliveryHERecord(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryHE heRecord, int id)
        {
            _InvalidLearnerData.RecordsInvalidLearningDeliveryHes.Add(LearningDeliveryHEBuilder.BuildInvalidHERecord(ilr, learner, learningDelivery, heRecord, id));
        }

        private void PopulateLearningDeliveryWorkPlacement(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryWorkPlacement workPlacement, int learnerDeliveryId, int learningDeliveryWorkPlacementId)
        {
            _InvalidLearnerData.RecordsInvalidLearningDeliveryWorkPlacements
                .Add(LearningDeliveryWorkPlacementBuilder.BuildInvalidWorkPlacementRecord(ilr, learner, learningDelivery, workPlacement, learnerDeliveryId, learningDeliveryWorkPlacementId));
        }

        private void PopulateProviderSpecDeliveryMonitoring(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, IProviderSpecDeliveryMonitoring monitoring, int learnerDeliveryId, int providerSpecDeliveryMonitoringId)
        {
            _InvalidLearnerData.RecordsInvalidProviderSpecDeliveryMonitorings
                .Add(ProviderSpecDeliveryMonitoringBuilder.BuildInvalidProviderSpecDeliveryMonitoringRecord(ilr, learner, learningDelivery, monitoring, learnerDeliveryId, providerSpecDeliveryMonitoringId));
        }

        private void PopulateLearnerEmploymentStatus(IMessage ilr, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, int learnerId, int learnerEmploymentStatusId)
        {
            _InvalidLearnerData.RecordsInvalidLearnerEmploymentStatus
                .Add(LearnerEmploymentStatusBuilder.BuildInvalidLearnerEmploymentStatus(ilr, learner, learnerEmploymentStatus, learnerId, learnerEmploymentStatusId));
        }

        private void PopulateEmploymentStatusMonitoring(IMessage ilr, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, IEmploymentStatusMonitoring employmentStatusMonitoring, int learnerEmploymentStatusId, int learnerEmploymentStatusMonitoringId)
        {
            _InvalidLearnerData.RecordsInvalidEmploymentStatusMonitorings
                .Add(EmploymentStatusMonitoringBuilder.BuildInvalidEmploymentStatusMonitoring(ilr, learner, learnerEmploymentStatus, employmentStatusMonitoring, learnerEmploymentStatusId, learnerEmploymentStatusMonitoringId));
        }

        private void PopulateLearnerFAM(IMessage ilr, ILearner learner, ILearnerFAM fam)
        {
            _InvalidLearnerData.RecordsInvalidLearnerFams
                .Add(LearnerFAMBuilder.BuildInvalidLearnerFAM(ilr, learner, fam));
        }

        private void PopulateLearnerHE(IMessage ilr, ILearner learner, int learnerId, int learnerHEId)
        {
            _InvalidLearnerData.RecordsInvalidLearnerHes
                .Add(LearnerHEBuilder.BuildInvalidLearnerHE(ilr, learner, learnerId, learnerHEId));
        }

        private void PopulateLearnerHEFinancialSupport(IMessage ilr, ILearner learner, ILearnerHEFinancialSupport support)
        {
            _InvalidLearnerData.RecordsInvalidLearnerHefinancialSupports
                .Add(LearnerHEFinancialSupportBuilder.BuildInvalidLearnerHEFinancialSupport(ilr, learner, support));
        }

        private void PopulateLLDDAndHealthProblem(IMessage ilr, ILearner learner, ILLDDAndHealthProblem problem, int id)
        {
            _InvalidLearnerData.RecordsInvalidLlddandHealthProblems
                .Add(LLDDAndHealthProblemBuilder.BuildInvalidLLDDandHealthProblem(ilr, learner, problem, id));
        }

        private void PopulateProviderSpecLearnerMonitorings(IMessage ilr, ILearner learner, IProviderSpecLearnerMonitoring monitoring)
        {
            _InvalidLearnerData.RecordsInvalidProviderSpecLearnerMonitorings
                .Add(ProviderSpecLearnerMonitoringBuilder.BuildInvalidProviderSpecLearnerMonitoring(ilr, learner, monitoring));
        }
    }
}
