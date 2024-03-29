﻿CREATE TABLE [Rulebase].[TBL_LearningDelivery] (
    [UKPRN]                          INT             NOT NULL,
    [LearnRefNumber]                 VARCHAR (12)    NOT NULL,
    [AimSeqNumber]                   INT             NOT NULL,
    [ProgStandardStartDate]          DATE            NULL,
    [FundLine]                       VARCHAR (50)    NULL,
    [MathEngAimValue]                DECIMAL (15, 5) NULL,
    [PlannedNumOnProgInstalm]        INT             NULL,
    [LearnSuppFundCash]              DECIMAL (15, 5) NULL,
    [AdjProgStartDate]               DATE            NULL,
    [LearnSuppFund]                  BIT             NULL,
    [AdjStartDate]                   DATE             NULL,
    [MathEngOnProgPayment]           DECIMAL (15, 5) NULL,
    [InstPerPeriod]                  INT             NULL,
    [SmallBusPayment]                DECIMAL (15, 5) NULL,
    [YoungAppSecondPayment]          DECIMAL (15, 5) NULL,
    [CoreGovContPayment]             DECIMAL (15, 5) NULL,
    [YoungAppEligible]               BIT             NULL,
    [SmallBusEligible]               BIT             NULL,
    [MathEngOnProgPct]               INT             NULL,
    [AgeStandardStart]               INT             NULL,
    [SmallBusThresholdDate]			 DATE            NULL,
    [YoungAppSecondThresholdDate]    DATE            NULL,
    [EmpIdFirstDayStandard]          INT             NULL,
    [EmpIdFirstYoungAppDate]         INT             NULL,
    [EmpIdSecondYoungAppDate]        INT             NULL,
    [EmpIdSmallBusDate]              INT             NULL,
    [YoungAppFirstThresholdDate]     DATE            NULL,
    [AchApplicDate]                  DATE            NULL,
    [AchEligible]                    BIT             NULL,
    [Achieved]                       BIT             NULL,
    [AchievementApplicVal]           DECIMAL (15, 5) NULL,
    [AchPayment]                     DECIMAL (15, 5) NULL,
    [ActualNumInstalm]               INT             NULL,
    [CombinedAdjProp]                DECIMAL (15, 5) NULL,
    [EmpIdAchDate]                   INT             NULL,
    [LearnDelDaysIL]                 INT             NULL,
    [LearnDelStandardAccDaysIL]      INT             NULL,
    [LearnDelStandardPrevAccDaysIL]  INT             NULL,
    [LearnDelStandardTotalDaysIL]    INT             NULL,
    [ActualDaysIL]                   INT             NULL,
    [MathEngBalPayment]              DECIMAL (15, 5) NULL,
    [MathEngBalPct]                  BIGINT          NULL,
    [MathEngLSFFundStart]            BIT             NULL,
    [PlannedTotalDaysIL]             INT             NULL,
    [MathEngLSFThresholdDays]        INT             NULL,
    [OutstandNumOnProgInstalm]       INT             NULL,
    [SmallBusApplicVal]              DECIMAL (15, 5) NULL,
    [SmallBusStatusFirstDayStandard] INT             NULL,
    [SmallBusStatusThreshold]        INT             NULL,
    [YoungAppApplicVal]              DECIMAL (15, 5) NULL,
    [CoreGovContCapApplicVal]        BIGINT          NULL,
    [CoreGovContUncapped]            DECIMAL (15, 5) NULL,
    [ApplicFundValDate]              DATE            NULL,
    [YoungAppFirstPayment]           DECIMAL (15, 5) NULL,
    [YoungAppPayment]                DECIMAL (15, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[TBL_LearningDelivery] ADD CONSTRAINT [FK_TBLLearningDelivery_TBLLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Rulebase].[TBL_Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Rulebase].[TBL_LearningDelivery] CHECK CONSTRAINT [FK_TBLLearningDelivery_TBLLearner]
GO


ALTER TABLE [Rulebase].[TBL_LearningDelivery]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_LearningDelivery_ValidLearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Valid].[LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber])
GO

ALTER TABLE [Rulebase].[TBL_LearningDelivery] CHECK CONSTRAINT [FK_TBL_LearningDelivery_ValidLearningDelivery]
GO
