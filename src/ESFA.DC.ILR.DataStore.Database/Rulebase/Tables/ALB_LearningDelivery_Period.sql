CREATE TABLE [Rulebase].[ALB_LearningDelivery_Period] (
    [UKPRN]                              INT             NOT NULL,
    [LearnRefNumber]                     VARCHAR (12)    NOT NULL,
    [AimSeqNumber]                       INT             NOT NULL,
    [Period]                             INT             NOT NULL,
    [AreaUpliftOnProgPayment]            DECIMAL (12, 5) NULL,
    [AreaUpliftBalPayment]               DECIMAL (12, 5) NULL,
    [ALBCode]                            INT             NULL,
    [ALBSupportPayment]                  DECIMAL (12, 5) NULL,
    [LearnDelCarLearnPilotOnProgPayment] DECIMAL (12, 5) NULL,
    [LearnDelCarLearnPilotBalPayment]    DECIMAL (12, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [Period] ASC)
);
GO

ALTER TABLE [Rulebase].[ALB_LearningDelivery_Period] ADD CONSTRAINT [FK_ALBLearningDeliveryPeriod_ALBLearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Rulebase].[ALB_LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber]);
GO

ALTER TABLE [Rulebase].[ALB_LearningDelivery_Period] CHECK CONSTRAINT [FK_ALBLearningDeliveryPeriod_ALBLearningDelivery]
GO