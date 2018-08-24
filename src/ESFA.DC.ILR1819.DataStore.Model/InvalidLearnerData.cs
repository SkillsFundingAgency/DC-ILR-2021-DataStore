using System.Collections.Generic;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.Model
{
    public class InvalidLearnerData
    {
        public InvalidLearnerData()
        {
            RecordsInvalidLearners = new List<Learner>();
            RecordsInvalidAppFinRecords = new List<AppFinRecord>();
            RecordsInvalidLearningDeliverys = new List<LearningDelivery>();
            RecordsInvalidContactPreferences = new List<ContactPreference>();
            RecordsInvalidEmploymentStatusMonitorings = new List<EmploymentStatusMonitoring>();
            RecordsInvalidLearnerEmploymentStatus = new List<LearnerEmploymentStatu>();
            RecordsInvalidLearnerFams = new List<LearnerFAM>();
            RecordsInvalidLearnerDeliveryFams = new List<LearningDeliveryFAM>();
            RecordsInvalidLearnerHes = new List<LearnerHE>();
            RecordsInvalidLearningDeliveryHes = new List<LearningDeliveryHE>();
            RecordsInvalidLearningDeliveryWorkPlacements = new List<LearningDeliveryWorkPlacement>();
            RecordsInvalidLearnerHefinancialSupports = new List<LearnerHEFinancialSupport>();
            RecordsInvalidLlddandHealthProblems = new List<LLDDandHealthProblem>();
            RecordsInvalidProviderSpecDeliveryMonitorings = new List<ProviderSpecDeliveryMonitoring>();
            RecordsInvalidProviderSpecLearnerMonitorings = new List<ProviderSpecLearnerMonitoring>();
        }

        public List<Learner> RecordsInvalidLearners { get; set; }

        public List<AppFinRecord> RecordsInvalidAppFinRecords { get; set; }

        public List<LearningDelivery> RecordsInvalidLearningDeliverys { get; set; }

        public List<ContactPreference> RecordsInvalidContactPreferences { get; set; }

        public List<EmploymentStatusMonitoring> RecordsInvalidEmploymentStatusMonitorings { get; set; }

        public List<LearnerEmploymentStatu> RecordsInvalidLearnerEmploymentStatus { get; set; }

        public List<LearnerFAM> RecordsInvalidLearnerFams { get; set; }

        public List<LearningDeliveryFAM> RecordsInvalidLearnerDeliveryFams { get; set; }

        public List<LearnerHE> RecordsInvalidLearnerHes { get; set; }

        public List<LearningDeliveryHE> RecordsInvalidLearningDeliveryHes { get; set; }

        public List<LearningDeliveryWorkPlacement> RecordsInvalidLearningDeliveryWorkPlacements { get; set; }

        public List<LearnerHEFinancialSupport> RecordsInvalidLearnerHefinancialSupports { get; set; }

        public List<LLDDandHealthProblem> RecordsInvalidLlddandHealthProblems { get; set; }

        public List<ProviderSpecDeliveryMonitoring> RecordsInvalidProviderSpecDeliveryMonitorings { get; set; }

        public List<ProviderSpecLearnerMonitoring> RecordsInvalidProviderSpecLearnerMonitorings { get; set; }
    }
}