CREATE TABLE [Rulebase].[ALB_LearningDelivery] (
    [UKPRN]                               INT			  NOT NULL,
    [LearnRefNumber]                      VARCHAR (12)    NOT NULL,
    [AimSeqNumber]                        INT             NOT NULL,
    [AreaCostFactAdj]                     DECIMAL (10, 5) NULL,
    [WeightedRate]                        DECIMAL (12, 5) NULL,
    [PlannedNumOnProgInstalm]             INT             NULL,
    [FundStart]                           BIT             NULL,
    [Achieved]                            BIT             NULL,
    [ActualNumInstalm]                    INT             NULL,
    [OutstndNumOnProgInstalm]             INT             NULL,
    [AreaCostInstalment]                  DECIMAL (12, 5) NULL,
    [AdvLoan]                             BIT             NULL,
    [LoanBursAreaUplift]                  BIT             NULL,
    [LoanBursSupp]                        BIT             NULL,
    [FundLine]                            VARCHAR (50)    NULL,
    [LiabilityDate]                       DATE            NULL,
    [ApplicProgWeightFact]                VARCHAR (1)     NULL,
    [ApplicFactDate]                      DATE            NULL,
    [LearnDelEligCareerLearnPilot]        BIT             NULL,
    [LearnDelApplicSubsidyPilotAreaCode]  VARCHAR (50)    NULL,
    [LearnDelApplicLARSCarPilFundSubRate] DECIMAL (12, 5) NULL,
    [LearnDelCarLearnPilotAimValue]       DECIMAL (12, 5) NULL,
    [LearnDelCarLearnPilotInstalAmount]   DECIMAL (12, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[ALB_LearningDelivery] ADD CONSTRAINT [FK_ALBLearningDelivery_ALBLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Rulebase].[ALB_Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Rulebase].[ALB_LearningDelivery] CHECK CONSTRAINT [FK_ALBLearningDelivery_ALBLearner]
GO


