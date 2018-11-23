using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearnerValidDataBuilder : ILearnerValidDataBuilder
    {
        private readonly ValidLearnerData _validLearnerData;

        public LearnerValidDataBuilder()
        {
            _validLearnerData = new ValidLearnerData();
        }

        public ValidLearnerData BuildValidLearnerData(IMessage ilr, List<string> learnersValid)
        {
            var ukprn = ilr.LearningProviderEntity.UKPRN;

            var learners = ilr.Learners
                .Where(l => learnersValid.Contains(l.LearnRefNumber, StringComparer.OrdinalIgnoreCase)).ToList();

            PopulateValidLearners(ukprn, learners);

            return _validLearnerData;
        }

        private void PopulateValidLearners(int ukprn, List<ILearner> learners)
        {
            int lLDDandHealthProblemID = 1;
            int learningDeliveryFamId = 1;

            learners.ForEach(learner =>
            {
                _validLearnerData.RecordsValidLearners.Add(LearnerBuilder.BuildValidLearner(ukprn, learner));

                learner.ContactPreferences?.ToList().ForEach(contactPreference => { PopulateContactPreferences(ukprn, learner, contactPreference); });
                learner.LearningDeliveries?.ToList().ForEach(learningDelivery =>
                {
                    PopulateLearningDelivery(ukprn, learner, learningDelivery);

                    if (learningDelivery.LearningDeliveryHEEntity != null)
                    {
                        PopulateLearningDeliveryHERecord(ukprn, learner, learningDelivery, learningDelivery.LearningDeliveryHEEntity);
                    }

                    learningDelivery.AppFinRecords?.ToList()
                        .ForEach(appFinRecord => { PopulateLearningDeliveryAppFinRecord(ukprn, learner, learningDelivery, appFinRecord); });
                    learningDelivery.LearningDeliveryFAMs?.ToList()
                        .ForEach(famRecord => PopulateLearningDeliveryFAMRecord(ukprn, learner, learningDelivery, famRecord, learningDeliveryFamId++));
                    learningDelivery.LearningDeliveryWorkPlacements?.ToList()
                        .ForEach(workPlacement => PopulateLearningDeliveryWorkPlacement(ukprn, learner, learningDelivery, workPlacement));
                    learningDelivery.ProviderSpecDeliveryMonitorings?.ToList()
                        .ForEach(monitoring => PopulateProviderSpecDeliveryMonitoring(ukprn, learner, learningDelivery, monitoring));
                });

                learner.LearnerEmploymentStatuses?.ToList()
                    .ForEach(employmentStatus =>
                    {
                        PopulateLearnerEmploymentStatus(ukprn, learner, employmentStatus);

                        employmentStatus.EmploymentStatusMonitorings?.ToList()
                            .ForEach(monitoring => PopulateEmploymentStatusMonitoring(ukprn, learner, employmentStatus, monitoring));
                    });

                learner.LearnerFAMs?.ToList()
                    .ForEach(fam => PopulateLearnerFAM(ukprn, learner, fam));

                if (learner.LearnerHEEntity != null)
                {
                    PopulateLearnerHE(ukprn, learner);
                    learner.LearnerHEEntity.LearnerHEFinancialSupports?.ToList()
                        .ForEach(support => PopulateLearnerHEFinancialSupport(ukprn, learner, support));
                }

                learner.LLDDAndHealthProblems?.ToList()
                    .ForEach(problem => PopulateLLDDAndHealthProblem(ukprn, learner, problem, lLDDandHealthProblemID++));

                learner.ProviderSpecLearnerMonitorings?.ToList()
                    .ForEach(monitoring => PopulateProviderSpecLearnerMonitorings(ukprn, learner, monitoring));
            });
        }

        private void PopulateContactPreferences(int ukprn, ILearner learner, IContactPreference contactPreference)
        {
           _validLearnerData.RecordsValidContactPreferences.Add(ContactPreferenceBuilder.BuildValidContactPreference(ukprn, learner, contactPreference));
        }

        private void PopulateLearningDelivery(int ukprn, ILearner learner, ILearningDelivery learningDelivery)
        {
            _validLearnerData.RecordsValidLearningDeliverys.Add(LearningDeliveryBuilder.BuildValidLearningDelivery(ukprn, learner, learningDelivery));
        }

        private void PopulateLearningDeliveryAppFinRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IAppFinRecord appFinRecord)
        {
            _validLearnerData.RecordsValidAppFinRecords.Add(AppFinRecordBuilder.BuildValidAppFinRecord(ukprn, learner, learningDelivery, appFinRecord));
        }

        private void PopulateLearningDeliveryFAMRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryFAM famRecord, int id)
        {
            _validLearnerData.RecordsValidLearnerDeliveryFams.Add(LearningDeliveryFAMBuilder.BuildValidFamRecord(ukprn, learner, learningDelivery, famRecord, id));
        }

        private void PopulateLearningDeliveryHERecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryHE heRecord)
        {
            _validLearnerData.RecordsValidLearningDeliveryHes.Add(LearningDeliveryHEBuilder.BuildValidHERecord(ukprn, learner, learningDelivery, heRecord));
        }

        private void PopulateLearningDeliveryWorkPlacement(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryWorkPlacement workPlacement)
        {
            _validLearnerData.RecordsValidLearningDeliveryWorkPlacements
                .Add(LearningDeliveryWorkPlacementBuilder.BuildValidWorkPlacementRecord(ukprn, learner, learningDelivery, workPlacement));
        }

        private void PopulateProviderSpecDeliveryMonitoring(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IProviderSpecDeliveryMonitoring monitoring)
        {
            _validLearnerData.RecordsValidProviderSpecDeliveryMonitorings
                .Add(ProviderSpecDeliveryMonitoringBuilder.BuildValidProviderSpecDeliveryMonitoringRecord(ukprn, learner, learningDelivery, monitoring));
        }

        private void PopulateLearnerEmploymentStatus(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus)
        {
            _validLearnerData.RecordsValidLearnerEmploymentStatus
                .Add(LearnerEmploymentStatusBuilder.BuildValidLearnerEmploymentStatus(ukprn, learner, learnerEmploymentStatus));
        }

        private void PopulateEmploymentStatusMonitoring(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, IEmploymentStatusMonitoring employmentStatusMonitoring)
        {
            _validLearnerData.RecordsValidEmploymentStatusMonitorings
                .Add(EmploymentStatusMonitoringBuilder.BuildValidEmploymentStatusMonitoring(ukprn, learner, learnerEmploymentStatus, employmentStatusMonitoring));
        }

        private void PopulateLearnerFAM(int ukprn, ILearner learner, ILearnerFAM fam)
        {
            _validLearnerData.RecordsValidLearnerFams
                .Add(LearnerFAMBuilder.BuildValidLearnerFAM(ukprn, learner, fam));
        }

        private void PopulateLearnerHE(int ukprn, ILearner learner)
        {
            _validLearnerData.RecordsValidLearnerHes
                .Add(LearnerHEBuilder.BuildValidLearnerHE(ukprn, learner));
        }

        private void PopulateLearnerHEFinancialSupport(int ukprn, ILearner learner, ILearnerHEFinancialSupport support)
        {
            _validLearnerData.RecordsValidLearnerHefinancialSupports
                .Add(LearnerHEFinancialSupportBuilder.BuildValidLearnerHEFinancialSupport(ukprn, learner, support));
        }

        private void PopulateLLDDAndHealthProblem(int ukprn, ILearner learner, ILLDDAndHealthProblem problem, int id)
        {
            _validLearnerData.RecordsValidLlddandHealthProblems
                .Add(LLDDAndHealthProblemBuilder.BuildValidLLDDandHealthProblem(ukprn, learner, problem, id));
        }

        private void PopulateProviderSpecLearnerMonitorings(int ukprn, ILearner learner, IProviderSpecLearnerMonitoring monitoring)
        {
            _validLearnerData.RecordsValidProviderSpecLearnerMonitorings
                .Add(ProviderSpecLearnerMonitoringBuilder.BuildValidProviderSpecLearnerMonitoring(ukprn, learner, monitoring));
        }
    }
}
