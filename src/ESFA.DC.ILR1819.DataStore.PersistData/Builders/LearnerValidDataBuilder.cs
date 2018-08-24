using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;

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
            var learners = ilr.Learners
                .Where(l => learnersValid.Contains(l.LearnRefNumber, StringComparer.OrdinalIgnoreCase)).ToList();

            PopulateValidLearners(ilr, learners);

            return null;
        }

        private void PopulateValidLearners(IMessage ilr, List<ILearner> learners)
        {
            int lLDDandHealthProblemID = 1;

            learners.ForEach(learner =>
            {
                _validLearnerData.RecordsValidLearners.Add(LearnerBuilder.BuildValidLearner(ilr, learner));

                learner.ContactPreferences.ToList().ForEach(contactPreference => { PopulateContactPreferences(ilr, learner, contactPreference); });
                learner.LearningDeliveries.ToList().ForEach(learningDelivery =>
                {
                    PopulateLearningDelivery(ilr, learner, learningDelivery);

                    if (learningDelivery.LearningDeliveryHEEntity != null)
                    {
                        PopulateLearningDeliveryHERecord(ilr, learner, learningDelivery, learningDelivery.LearningDeliveryHEEntity);
                    }

                    learningDelivery.AppFinRecords.ToList()
                        .ForEach(appFinRecord => { PopulateLearningDeliveryAppFinRecord(ilr, learner, learningDelivery, appFinRecord); });
                    learningDelivery.LearningDeliveryFAMs.ToList()
                        .ForEach(famRecord => PopulateLearningDeliveryFAMRecord(ilr, learner, learningDelivery, famRecord));
                    learningDelivery.LearningDeliveryWorkPlacements.ToList()
                        .ForEach(workPlacement => PopulateLearningDeliveryWorkPlacement(ilr, learner, learningDelivery, workPlacement));
                    learningDelivery.ProviderSpecDeliveryMonitorings.ToList()
                        .ForEach(monitoring => PopulateProviderSpecDeliveryMonitoring(ilr, learner, learningDelivery, monitoring));
                });

                learner.LearnerEmploymentStatuses.ToList()
                    .ForEach(employmentStatus =>
                    {
                        PopulateLearnerEmploymentStatus(ilr, learner, employmentStatus);

                        employmentStatus.EmploymentStatusMonitorings.ToList()
                            .ForEach(monitoring => PopulateEmploymentStatusMonitoring(ilr, learner, employmentStatus, monitoring));
                    });

                learner.LearnerFAMs.ToList()
                    .ForEach(fam => PopulateLearnerFAM(ilr, learner, fam));

                if (learner.LearnerHEEntity != null)
                {
                    PopulateLearnerHE(ilr, learner);
                    learner.LearnerHEEntity.LearnerHEFinancialSupports.ToList()
                        .ForEach(support => PopulateLearnerHEFinancialSupport(ilr, learner, support));
                }

                learner.LLDDAndHealthProblems.ToList()
                    .ForEach(problem => PopulateLLDDAndHealthProblem(ilr, learner, problem, lLDDandHealthProblemID++));

                learner.ProviderSpecLearnerMonitorings.ToList()
                    .ForEach(monitoring => PopulateProviderSpecLearnerMonitorings(ilr, learner, monitoring));
            });
        }

        private void PopulateContactPreferences(IMessage ilr, ILearner learner, IContactPreference contactPreference)
        {
           _validLearnerData.RecordsValidContactPreferences.Add(ContactPreferenceBuilder.BuildValidContactPreference(ilr, learner, contactPreference));
        }

        private void PopulateLearningDelivery(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery)
        {
            _validLearnerData.RecordsValidLearningDeliverys.Add(LearningDeliveryBuilder.BuildValidLearningDelivery(ilr, learner, learningDelivery));
        }

        private void PopulateLearningDeliveryAppFinRecord(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, IAppFinRecord appFinRecord)
        {
            _validLearnerData.RecordsValidAppFinRecords.Add(AppFinRecordBuilder.BuildValidAppFinRecord(ilr, learner, learningDelivery, appFinRecord));
        }

        private void PopulateLearningDeliveryFAMRecord(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryFAM famRecord)
        {
            _validLearnerData.RecordsValidLearnerDeliveryFams.Add(LearningDeliveryFAMBuilder.BuildValidFamRecord(ilr, learner, learningDelivery, famRecord));
        }

        private void PopulateLearningDeliveryHERecord(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryHE heRecord)
        {
            _validLearnerData.RecordsValidLearningDeliveryHes.Add(LearningDeliveryHEBuilder.BuildValidHERecord(ilr, learner, learningDelivery, heRecord));
        }

        private void PopulateLearningDeliveryWorkPlacement(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryWorkPlacement workPlacement)
        {
            _validLearnerData.RecordsValidLearningDeliveryWorkPlacements
                .Add(LearningDeliveryWorkPlacementBuilder.BuildValidWorkPlacementRecord(ilr, learner, learningDelivery, workPlacement));
        }

        private void PopulateProviderSpecDeliveryMonitoring(IMessage ilr, ILearner learner, ILearningDelivery learningDelivery, IProviderSpecDeliveryMonitoring monitoring)
        {
            _validLearnerData.RecordsValidProviderSpecDeliveryMonitorings
                .Add(ProviderSpecDeliveryMonitoringBuilder.BuildValidProviderSpecDeliveryMonitoringRecord(ilr, learner, learningDelivery, monitoring));
        }

        private void PopulateLearnerEmploymentStatus(IMessage ilr, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus)
        {
            _validLearnerData.RecordsValidLearnerEmploymentStatus
                .Add(LearnerEmploymentStatusBuilder.BuildValidLearnerEmploymentStatus(ilr, learner, learnerEmploymentStatus));
        }

        private void PopulateEmploymentStatusMonitoring(IMessage ilr, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, IEmploymentStatusMonitoring employmentStatusMonitoring)
        {
            _validLearnerData.RecordsValidEmploymentStatusMonitorings
                .Add(EmploymentStatusMonitoringBuilder.BuildValidEmploymentStatusMonitoring(ilr, learner, learnerEmploymentStatus, employmentStatusMonitoring));
        }

        private void PopulateLearnerFAM(IMessage ilr, ILearner learner, ILearnerFAM fam)
        {
            _validLearnerData.RecordsValidLearnerFams
                .Add(LearnerFAMBuilder.BuildValidLearnerFAM(ilr, learner, fam));
        }

        private void PopulateLearnerHE(IMessage ilr, ILearner learner)
        {
            _validLearnerData.RecordsValidLearnerHes
                .Add(LearnerHEBuilder.BuildValidLearnerHE(ilr, learner));
        }

        private void PopulateLearnerHEFinancialSupport(IMessage ilr, ILearner learner, ILearnerHEFinancialSupport support)
        {
            _validLearnerData.RecordsValidLearnerHefinancialSupports
                .Add(LearnerHEFinancialSupportBuilder.BuildValidLearnerHEFinancialSupport(ilr, learner, support));
        }

        private void PopulateLLDDAndHealthProblem(IMessage ilr, ILearner learner, ILLDDAndHealthProblem problem, int id)
        {
            _validLearnerData.RecordsValidLlddandHealthProblems
                .Add(LLDDAndHealthProblemBuilder.BuildValidLLDDandHealthProblem(ilr, learner, problem, id));
        }

        private void PopulateProviderSpecLearnerMonitorings(IMessage ilr, ILearner learner, IProviderSpecLearnerMonitoring monitoring)
        {
            _validLearnerData.RecordsValidProviderSpecLearnerMonitorings
                .Add(ProviderSpecLearnerMonitoringBuilder.BuildValidProviderSpecLearnerMonitoring(ilr, learner, monitoring));
        }
    }
}
