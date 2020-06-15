CREATE TABLE [Rulebase].[ESF_LearningDelivery] (
    [UKPRN]                              INT             NOT NULL,
    [LearnRefNumber]                     VARCHAR (12)    NOT NULL,
    [AimSeqNumber]                       INT             NOT NULL,
    [Achieved]                           BIT             NULL,
    [AddProgCostElig]                    BIT             NULL,
    [AdjustedAreaCostFactor]             DECIMAL (10, 5)  NULL,
    [AdjustedPremiumFactor]              DECIMAL (10, 5)  NULL,
    [AdjustedStartDate]                  DATE            NULL,
    [AimClassification]                  VARCHAR (50)    NULL,
    [AimValue]                           DECIMAL (10, 5) NULL,
    [ApplicWeightFundRate]               DECIMAL (10, 5) NULL,
    [EligibleProgressionOutcomeCode]     BIGINT          NULL,
    [EligibleProgressionOutcomeType]     VARCHAR (4)     NULL,
    [EligibleProgressionOutomeStartDate] DATE            NULL,
    [FundStart]                          BIT             NULL,
    [LARSWeightedRate]                   DECIMAL (10, 5) NULL,
    [LatestPossibleStartDate]            DATE            NULL,
    [LDESFEngagementStartDate]           DATE            NULL,
	[LearnDelLearnerEmpAtStart]			 BIT		     NULL,
    [PotentiallyEligibleForProgression]  BIT             NULL,
    [ProgressionEndDate]                 DATE            NULL,
    [Restart]                            BIT             NULL,
    [WeightedRateFromESOL]               DECIMAL (10, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[ESF_LearningDelivery] ADD CONSTRAINT [FK_ESFLearningDelivery_ESFLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Rulebase].[ESF_Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Rulebase].[ESF_LearningDelivery] CHECK CONSTRAINT [FK_ESFLearningDelivery_ESFLearner]
GO



ALTER TABLE [Rulebase].[ESF_LearningDelivery]  WITH NOCHECK ADD  CONSTRAINT [FK_ESF_LearningDelivery_ValidLearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Valid].[LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber])
GO

ALTER TABLE [Rulebase].[ESF_LearningDelivery] CHECK CONSTRAINT [FK_ESF_LearningDelivery_ValidLearningDelivery]
GO
