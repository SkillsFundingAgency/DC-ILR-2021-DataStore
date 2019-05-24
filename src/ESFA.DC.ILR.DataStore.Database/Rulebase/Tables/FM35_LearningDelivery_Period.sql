CREATE TABLE [Rulebase].[FM35_LearningDelivery_Period] (
    [UKPRN]                  INT             NOT NULL,
    [LearnRefNumber]         VARCHAR (12)    NOT NULL,
    [AimSeqNumber]           INT             NOT NULL,
    [Period]                 INT             NOT NULL,
    [AchievePayment]         DECIMAL (10, 5) NULL,
    [AchievePayPct]          DECIMAL (10, 5) NULL,
    [AchievePayPctTrans]     DECIMAL (10, 5) NULL,
    [BalancePayment]         DECIMAL (10, 5) NULL,
    [BalancePaymentUncapped] DECIMAL (10, 5) NULL,
    [BalancePct]             DECIMAL (10, 5) NULL,
    [BalancePctTrans]        DECIMAL (10, 5) NULL,
    [EmpOutcomePay]          DECIMAL (10, 5) NULL,
    [EmpOutcomePct]          DECIMAL (10, 5) NULL,
    [EmpOutcomePctTrans]     DECIMAL (10, 5) NULL,
    [InstPerPeriod]          INT             NULL,
    [LearnSuppFund]          BIT             NULL,
    [LearnSuppFundCash]      DECIMAL (10, 5) NULL,
    [OnProgPayment]          DECIMAL (10, 5) NULL,
    [OnProgPaymentUncapped]  DECIMAL (10, 5) NULL,
    [OnProgPayPct]           DECIMAL (10, 5) NULL,
    [OnProgPayPctTrans]      DECIMAL (10, 5) NULL,
    [TransInstPerPeriod]     INT             NULL,
    CONSTRAINT [PK_FM35_LearningDelivery_Period] PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [Period] ASC)
);
GO

ALTER TABLE [Rulebase].[FM35_LearningDelivery_Period] ADD CONSTRAINT [FK_FM35LearningDeliveryPeriod_FM35LearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Rulebase].[FM35_LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber]);
GO

ALTER TABLE [Rulebase].[FM35_LearningDelivery_Period] CHECK CONSTRAINT [FK_FM35LearningDeliveryPeriod_FM35LearningDelivery]
GO