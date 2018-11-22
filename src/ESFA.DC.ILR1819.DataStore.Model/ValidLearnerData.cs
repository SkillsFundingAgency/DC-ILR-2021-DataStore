using System.Collections.Generic;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.Model
{
    public class ValidLearnerData
    {
        public ValidLearnerData()
        {
            RecordsValidLearners = new List<Learner>();
            RecordsValidAppFinRecords = new List<AppFinRecord>();
            RecordsValidLearningDeliverys = new List<LearningDelivery>();
            RecordsValidContactPreferences = new List<ContactPreference>();
            RecordsValidEmploymentStatusMonitorings = new List<EmploymentStatusMonitoring>();
            RecordsValidLearnerEmploymentStatus = new List<LearnerEmploymentStatus>();
            RecordsValidLearnerFams = new List<LearnerFAM>();
            RecordsValidLearnerDeliveryFams = new List<LearningDeliveryFAM>();
            RecordsValidLearnerHes = new List<LearnerHE>();
            RecordsValidLearningDeliveryHes = new List<LearningDeliveryHE>();
            RecordsValidLearningDeliveryWorkPlacements = new List<LearningDeliveryWorkPlacement>();
            RecordsValidLearnerHefinancialSupports = new List<LearnerHEFinancialSupport>();
            RecordsValidLlddandHealthProblems = new List<LLDDandHealthProblem>();
            RecordsValidProviderSpecDeliveryMonitorings = new List<ProviderSpecDeliveryMonitoring>();
            RecordsValidProviderSpecLearnerMonitorings = new List<ProviderSpecLearnerMonitoring>();
        }

        public List<Learner> RecordsValidLearners { get; set; }

        public List<AppFinRecord> RecordsValidAppFinRecords { get; set; }

        public List<LearningDelivery> RecordsValidLearningDeliverys { get; set; }

        public List<ContactPreference> RecordsValidContactPreferences { get; set; }

        public List<EmploymentStatusMonitoring> RecordsValidEmploymentStatusMonitorings { get; set; }

        public List<LearnerEmploymentStatus> RecordsValidLearnerEmploymentStatus { get; set; }

        public List<LearnerFAM> RecordsValidLearnerFams { get; set; }

        public List<LearningDeliveryFAM> RecordsValidLearnerDeliveryFams { get; set; }

        public List<LearnerHE> RecordsValidLearnerHes { get; set; }

        public List<LearningDeliveryHE> RecordsValidLearningDeliveryHes { get; set; }

        public List<LearningDeliveryWorkPlacement> RecordsValidLearningDeliveryWorkPlacements { get; set; }

        public List<LearnerHEFinancialSupport> RecordsValidLearnerHefinancialSupports { get; set; }

        public List<LLDDandHealthProblem> RecordsValidLlddandHealthProblems { get; set; }

        public List<ProviderSpecDeliveryMonitoring> RecordsValidProviderSpecDeliveryMonitorings { get; set; }

        public List<ProviderSpecLearnerMonitoring> RecordsValidProviderSpecLearnerMonitorings { get; set; }
    }
}
