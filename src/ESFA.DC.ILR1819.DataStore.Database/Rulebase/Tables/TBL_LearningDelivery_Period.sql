CREATE TABLE [Rulebase].[TBL_LearningDelivery_Period] (
    [UKPRN]                 INT             NOT NULL,
    [LearnRefNumber]        VARCHAR (12)    NOT NULL,
    [AimSeqNumber]          INT             NOT NULL,
    [Period]                INT             NOT NULL,
    [AchPayment]            DECIMAL (10, 5) NULL,
    [CoreGovContPayment]    DECIMAL (10, 5) NULL,
    [CoreGovContUncapped]   DECIMAL (10, 5) NULL,
    [InstPerPeriod]         INT             NULL,
    [LearnSuppFund]         BIT             NULL,
    [LearnSuppFundCash]     DECIMAL (10, 5) NULL,
    [MathEngBalPayment]     DECIMAL (10, 5) NULL,
    [MathEngBalPct]         DECIMAL (8, 5)  NULL,
    [MathEngOnProgPayment]  DECIMAL (10, 5) NULL,
    [MathEngOnProgPct]      DECIMAL (8, 5)  NULL,
    [SmallBusPayment]       DECIMAL (10, 5) NULL,
    [YoungAppFirstPayment]  DECIMAL (10, 5) NULL,
    [YoungAppPayment]       DECIMAL (10, 5) NULL,
    [YoungAppSecondPayment] DECIMAL (10, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [Period] ASC)
);
GO

ALTER TABLE [Rulebase].[TBL_LearningDelivery_Period] ADD CONSTRAINT [FK_TBLLearningDeliveryPeriod_TBLLearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Rulebase].[TBL_LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber]);
GO

ALTER TABLE [Rulebase].[TBL_LearningDelivery_Period] CHECK CONSTRAINT [FK_TBLLearningDeliveryPeriod_TBLLearningDelivery]
GO