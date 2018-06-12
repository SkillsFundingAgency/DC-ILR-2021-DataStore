

CREATE procedure [dbo].[DeleteExistingRecords] (@ukprn int, @fileName NVARCHAR(100)) as
BEGIN 

--FileDetails--
-- Todo: Fix this
DELETE FROM [dbo].[FileDetails] WHERE [UKPRN] = @ukprn AND [Filename] = @fileName -- AND [Success] ='0' 
DELETE FROM [dbo].[ValidationError] WHERE UKPRN = @ukprn


DELETE FROM [Invalid].[AppFinRecord] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[CollectionDetails] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[ContactPreference] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[DPOutcome] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[EmploymentStatusMonitoring] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[Learner] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearnerDestinationandProgression] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearnerEmploymentStatus] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearnerFAM] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearnerHE] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearnerHEFinancialSupport] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearningDeliveryFAM] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearningDeliveryHE] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearningDeliveryWorkPlacement] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LearningProvider] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[LLDDandHealthProblem] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[ProviderSpecDeliveryMonitoring] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[ProviderSpecLearnerMonitoring] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[Source] WHERE UKPRN = @ukprn
DELETE FROM [Invalid].[SourceFile] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_ApprenticeshipPriceEpisode] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_ApprenticeshipPriceEpisode_Period] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_ApprenticeshipPriceEpisode_PeriodisedValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_HistoricEarningOutput] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_LearningDelivery_Period] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_LearningDelivery_PeriodisedTextValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[AEC_LearningDelivery_PeriodisedValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ALB_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ALB_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ALB_Learner_Period] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ALB_Learner_PeriodisedValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ALB_LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ALB_LearningDelivery_Period] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ALB_LearningDelivery_PeriodisedValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[DV_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[DV_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[DV_Learner] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[DV_LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[FM25_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[FM25_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[FM25_Learner] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[EFA_SFA_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[EFA_SFA_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[EFA_SFA_Learner_Period] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[EFA_SFA_Learner_PeriodisedValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESFVAL_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESFVAL_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESFVAL_ValidationError] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESF_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESF_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESF_LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESF_LearningDeliveryDeliverable] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESF_LearningDeliveryDeliverable_Period] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESF_LearningDeliveryDeliverable_PeriodisedValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[ESF_DPOutcome] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[FM35_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[FM35_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[FM35_LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[FM35_LearningDelivery_Period] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[FM35_LearningDelivery_PeriodisedValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[TBL_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[TBL_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[TBL_LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[TBL_LearningDelivery_Period] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[TBL_LearningDelivery_PeriodisedValues] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VAL_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VAL_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VAL_Learner] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VAL_LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VAL_ValidationError] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VALDP_Cases] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VALDP_global] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VALDP_ValidationError] WHERE UKPRN = @ukprn
DELETE FROM [Rulebase].[VALFD_ValidationError] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[AppFinRecord] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[CollectionDetails] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[ContactPreference] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[DPOutcome] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[EmploymentStatusMonitoring] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[Learner] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearnerDestinationandProgression] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearnerEmploymentStatus] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearnerFAM] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearnerHE] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearnerHEFinancialSupport] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearningDelivery] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearningDeliveryFAM] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearningDeliveryHE] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearningDeliveryWorkPlacement] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LearningProvider] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[LLDDandHealthProblem] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[ProviderSpecDeliveryMonitoring] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[ProviderSpecLearnerMonitoring] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[Source] WHERE UKPRN = @ukprn
DELETE FROM [Valid].[SourceFile] WHERE UKPRN = @ukprn

END

GO

GRANT EXECUTE ON [dbo].[DeleteExistingRecords] TO [DataProcessing]

