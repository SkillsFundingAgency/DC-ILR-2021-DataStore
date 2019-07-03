using System.Collections.Generic;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Model.File
{
    public class ValidLearnerData
    {
        public List<CollectionDetail> CollectionDetails { get; set; } = new List<CollectionDetail>();

        public List<LearningProvider> LearningProviders { get; set; } = new List<LearningProvider>();

        public List<Source> Sources { get; set; } = new List<Source>();

        public List<SourceFile> SourceFiles { get; set; } = new List<SourceFile>();

        public List<Learner> RecordsValidLearners { get; set; } = new List<Learner>();

        public List<AppFinRecord> RecordsValidAppFinRecords { get; set; } = new List<AppFinRecord>();

        public List<LearningDelivery> RecordsValidLearningDeliverys { get; set; } = new List<LearningDelivery>();

        public List<ContactPreference> RecordsValidContactPreferences { get; set; } = new List<ContactPreference>();

        public List<EmploymentStatusMonitoring> RecordsValidEmploymentStatusMonitorings { get; set; } = new List<EmploymentStatusMonitoring>();

        public List<LearnerEmploymentStatus> RecordsValidLearnerEmploymentStatus { get; set; } = new List<LearnerEmploymentStatus>();

        public List<LearnerFAM> RecordsValidLearnerFams { get; set; } = new List<LearnerFAM>();

        public List<LearningDeliveryFAM> RecordsValidLearnerDeliveryFams { get; set; } = new List<LearningDeliveryFAM>();

        public List<LearnerHE> RecordsValidLearnerHes { get; set; } = new List<LearnerHE>();

        public List<LearningDeliveryHE> RecordsValidLearningDeliveryHes { get; set; } = new List<LearningDeliveryHE>();

        public List<LearningDeliveryWorkPlacement> RecordsValidLearningDeliveryWorkPlacements { get; set; } = new List<LearningDeliveryWorkPlacement>();

        public List<LearnerHEFinancialSupport> RecordsValidLearnerHefinancialSupports { get; set; } = new List<LearnerHEFinancialSupport>();

        public List<LLDDandHealthProblem> RecordsValidLlddandHealthProblems { get; set; } = new List<LLDDandHealthProblem>();

        public List<ProviderSpecDeliveryMonitoring> RecordsValidProviderSpecDeliveryMonitorings { get; set; } = new List<ProviderSpecDeliveryMonitoring>();

        public List<ProviderSpecLearnerMonitoring> RecordsValidProviderSpecLearnerMonitorings { get; set; } = new List<ProviderSpecLearnerMonitoring>();

        public List<DPOutcome> RecordsValidDpOutcomes { get; set; } = new List<DPOutcome>();
        
        public List<LearnerDestinationandProgression> RecordsValidLearnerDestinationandProgressions { get; set; } = new List<LearnerDestinationandProgression>();
    }
}
