using System.Collections.Generic;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Model.File
{
    public class InvalidLearnerData
    {
        public List<CollectionDetail> CollectionDetails { get; set; } = new List<CollectionDetail>();

        public List<LearningProvider> LearningProviders { get; set; } = new List<LearningProvider>();

        public List<Source> Sources { get; set; } = new List<Source>();

        public List<SourceFile> SourceFiles { get; set; } = new List<SourceFile>();

        public List<Learner> RecordsInvalidLearners { get; set; } = new List<Learner>();

        public List<AppFinRecord> RecordsInvalidAppFinRecords { get; set; } = new List<AppFinRecord>();

        public List<LearningDelivery> RecordsInvalidLearningDeliverys { get; set; } = new List<LearningDelivery>();

        public List<ContactPreference> RecordsInvalidContactPreferences { get; set; } = new List<ContactPreference>();

        public List<EmploymentStatusMonitoring> RecordsInvalidEmploymentStatusMonitorings { get; set; } = new List<EmploymentStatusMonitoring>();

        public List<LearnerEmploymentStatus> RecordsInvalidLearnerEmploymentStatus { get; set; } = new List<LearnerEmploymentStatus>();

        public List<LearnerFAM> RecordsInvalidLearnerFams { get; set; } = new List<LearnerFAM>();

        public List<LearningDeliveryFAM> RecordsInvalidLearnerDeliveryFams { get; set; } = new List<LearningDeliveryFAM>();

        public List<LearnerHE> RecordsInvalidLearnerHes { get; set; } = new List<LearnerHE>();

        public List<LearningDeliveryHE> RecordsInvalidLearningDeliveryHes { get; set; } = new List<LearningDeliveryHE>();

        public List<LearningDeliveryWorkPlacement> RecordsInvalidLearningDeliveryWorkPlacements { get; set; } = new List<LearningDeliveryWorkPlacement>();

        public List<LearnerHEFinancialSupport> RecordsInvalidLearnerHefinancialSupports { get; set; } = new List<LearnerHEFinancialSupport>();

        public List<LLDDandHealthProblem> RecordsInvalidLlddandHealthProblems { get; set; } = new List<LLDDandHealthProblem>();

        public List<ProviderSpecDeliveryMonitoring> RecordsInvalidProviderSpecDeliveryMonitorings { get; set; } = new List<ProviderSpecDeliveryMonitoring>();

        public List<ProviderSpecLearnerMonitoring> RecordsInvalidProviderSpecLearnerMonitorings { get; set; } = new List<ProviderSpecLearnerMonitoring>();

        public List<DPOutcome> RecordsInvalidDpOutcomes { get; set; } = new List<DPOutcome>();

        public List<LearnerDestinationandProgression> RecordsInvalidLearnerDestinationandProgressions { get; set; } = new List<LearnerDestinationandProgression>();
    }
}