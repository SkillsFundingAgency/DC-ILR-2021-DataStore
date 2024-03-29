﻿


CREATE procedure [dbo].[DeleteExistingRecords] (
	@ukprn int,
	@fileName varchar(100)
) as
begin

	delete from [dbo].[FileDetails] where [UKPRN] = @ukprn and [Filename] = @fileName

	delete from dbo.ValidationError where UKPRN = @ukprn

	delete from Invalid.AppFinRecord where UKPRN = @ukprn
	delete from Invalid.CollectionDetails where UKPRN = @ukprn
	delete from Invalid.ContactPreference where UKPRN = @ukprn
	delete from Invalid.DPOutcome where UKPRN = @ukprn
	delete from Invalid.EmploymentStatusMonitoring where UKPRN = @ukprn
	delete from Invalid.Learner where UKPRN = @ukprn
	delete from Invalid.LearnerDestinationandProgression where UKPRN = @ukprn
	delete from Invalid.LearnerEmploymentStatus where UKPRN = @ukprn
	delete from Invalid.LearnerFAM where UKPRN = @ukprn
	delete from Invalid.LearnerHE where UKPRN = @ukprn
	delete from Invalid.LearnerHEFinancialSupport where UKPRN = @ukprn
	delete from Invalid.LearningDelivery where UKPRN = @ukprn
	delete from Invalid.LearningDeliveryFAM where UKPRN = @ukprn
	delete from Invalid.LearningDeliveryHE where UKPRN = @ukprn
	delete from Invalid.LearningDeliveryWorkPlacement where UKPRN = @ukprn
	delete from Invalid.LearningProvider where UKPRN = @ukprn
	delete from Invalid.LLDDandHealthProblem where UKPRN = @ukprn
	delete from Invalid.ProviderSpecDeliveryMonitoring where UKPRN = @ukprn
	delete from Invalid.ProviderSpecLearnerMonitoring where UKPRN = @ukprn
	delete from Invalid.[Source] where UKPRN = @ukprn
	delete from Invalid.SourceFile where UKPRN = @ukprn

	delete from Rulebase.ALB_LearningDelivery_PeriodisedValues where UKPRN = @ukprn
	delete from Rulebase.ALB_LearningDelivery_Period where UKPRN = @ukprn
	delete from Rulebase.ALB_LearningDelivery where UKPRN = @ukprn
	delete from Rulebase.ALB_Learner_PeriodisedValues where UKPRN = @ukprn
	delete from Rulebase.ALB_Learner_Period where UKPRN = @ukprn
	delete from Rulebase.ALB_Learner where UKPRN = @ukprn
	delete from Rulebase.ALB_global where UKPRN = @ukprn
	
	delete from Rulebase.DV_LearningDelivery where UKPRN = @ukprn
	delete from Rulebase.DV_Learner where UKPRN = @ukprn
	delete from Rulebase.DV_global where UKPRN = @ukprn
	
	
	delete from Rulebase.FM25_FM35_Learner_PeriodisedValues where UKPRN = @ukprn
	delete from Rulebase.FM25_FM35_Learner_Period where UKPRN = @ukprn
	delete from Rulebase.FM25_FM35_global where UKPRN = @ukprn

	delete from Rulebase.FM25_Learner where UKPRN = @ukprn
	delete from Rulebase.FM25_global where UKPRN = @ukprn
		
	delete from Rulebase.ESFVAL_ValidationError where UKPRN = @ukprn
	delete from Rulebase.ESFVAL_global where UKPRN = @ukprn
	
	delete from Rulebase.ESF_DPOutcome where UKPRN = @ukprn
	delete from Rulebase.ESF_LearningDeliveryDeliverable_PeriodisedValues where UKPRN = @ukprn
	delete from Rulebase.ESF_LearningDeliveryDeliverable_Period where UKPRN = @ukprn
	delete from Rulebase.ESF_LearningDeliveryDeliverable where UKPRN = @ukprn
	delete from Rulebase.ESF_LearningDelivery where UKPRN = @ukprn
	delete from Rulebase.ESF_Learner where UKPRN = @ukprn
	delete from Rulebase.ESF_global where UKPRN = @ukprn
	
	delete from Rulebase.FM35_LearningDelivery_PeriodisedValues where UKPRN = @ukprn
	delete from Rulebase.FM35_LearningDelivery_Period where UKPRN = @ukprn
	delete from Rulebase.FM35_LearningDelivery where UKPRN = @ukprn
	delete from Rulebase.FM35_Learner where UKPRN = @ukprn
	delete from Rulebase.FM35_global where UKPRN = @ukprn
	
	delete from Rulebase.TBL_LearningDelivery_PeriodisedValues where UKPRN = @ukprn
	delete from Rulebase.TBL_LearningDelivery_Period where UKPRN = @ukprn
	delete from Rulebase.TBL_LearningDelivery where UKPRN = @ukprn
	delete from Rulebase.TBL_Learner where UKPRN = @ukprn
	delete from Rulebase.TBL_global where UKPRN = @ukprn
	
	delete from Rulebase.VAL_ValidationError where UKPRN = @ukprn
	delete from Rulebase.VAL_LearningDelivery where UKPRN = @ukprn
	delete from Rulebase.VAL_Learner where UKPRN = @ukprn
	delete from Rulebase.VAL_global where UKPRN = @ukprn
	
	DELETE FROM Rulebase.VALDP_ValidationError WHERE UKPRN = @ukprn
	DELETE FROM Rulebase.VALDP_global WHERE UKPRN = @ukprn
	
	delete from Rulebase.VALFD_ValidationError where UKPRN = @ukprn

	delete from Valid.AppFinRecord where UKPRN = @ukprn
	delete from Valid.CollectionDetails where UKPRN = @ukprn
	delete from Valid.ContactPreference where UKPRN = @ukprn
	delete from Valid.DPOutcome where UKPRN = @ukprn
	delete from Valid.EmploymentStatusMonitoring where UKPRN = @ukprn
	delete from Valid.ProviderSpecLearnerMonitoring where UKPRN = @ukprn
	delete from Valid.ProviderSpecDeliveryMonitoring where UKPRN = @ukprn
	delete from Valid.LLDDandHealthProblem where UKPRN = @ukprn
	delete from Valid.LearningProvider where UKPRN = @ukprn
	delete from Valid.LearningDeliveryWorkPlacement where UKPRN = @ukprn
	delete from Valid.LearningDeliveryHE where UKPRN = @ukprn
	delete from Valid.LearningDeliveryFAM where UKPRN = @ukprn
	delete from Valid.LearningDelivery where UKPRN = @ukprn
	delete from Valid.LearnerHEFinancialSupport where UKPRN = @ukprn
	delete from Valid.LearnerHE where UKPRN = @ukprn
	delete from Valid.LearnerFAM where UKPRN = @ukprn
	delete from Valid.LearnerEmploymentStatus where UKPRN = @ukprn
	delete from Valid.LearnerDestinationandProgression where UKPRN = @ukprn
	delete from Valid.Learner where UKPRN = @ukprn
	delete from Valid.[Source] where UKPRN = @ukprn
	delete from Valid.SourceFile where UKPRN = @ukprn
end

GO



