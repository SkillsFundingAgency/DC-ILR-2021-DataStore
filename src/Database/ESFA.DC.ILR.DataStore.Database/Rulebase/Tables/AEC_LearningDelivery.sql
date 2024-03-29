﻿CREATE TABLE [Rulebase].[AEC_LearningDelivery] (
    [UKPRN]                                         INT             NOT NULL,
    [LearnRefNumber]                                VARCHAR (12)    NOT NULL,
    [AimSeqNumber]                                  INT             NOT NULL,
    [ActualDaysIL]                                  INT             NULL,
    [ActualNumInstalm]                              INT             NULL,
    [AdjStartDate]                                  DATE            NULL,
    [AgeAtProgStart]                                INT             NULL,
    [AppAdjLearnStartDate]                          DATE            NULL,
    [AppAdjLearnStartDateMatchPathway]              DATE            NULL,
    [ApplicCompDate]                                DATE            NULL,
    [CombinedAdjProp]                               DECIMAL (12, 5) NULL,
    [Completed]                                     BIT             NULL,
    [FirstIncentiveThresholdDate]                   DATE            NULL,
    [FundStart]                                     BIT             NULL,
    [LDApplic1618FrameworkUpliftTotalActEarnings]   DECIMAL (12, 5) NULL,
    [LearnAimRef]                                   VARCHAR (8)     NULL,
    [LearnDel1618AtStart]                           BIT             NULL,
    [LearnDelAppAccDaysIL]                          INT             NULL,
    [LearnDelApplicDisadvAmount]                    DECIMAL (12, 5) NULL,
    [LearnDelApplicEmp1618Incentive]                DECIMAL (12, 5) NULL,
    [LearnDelApplicEmpDate]                         DATE            NULL,
    [LearnDelApplicProv1618FrameworkUplift]         DECIMAL (12, 5) NULL,
    [LearnDelApplicProv1618Incentive]               DECIMAL (12, 5) NULL,
    [LearnDelAppPrevAccDaysIL]                      INT             NULL,
    [LearnDelDaysIL]                                INT             NULL,
    [LearnDelDisadAmount]                           DECIMAL (12, 5) NULL,
    [LearnDelEligDisadvPayment]                     BIT             NULL,
    [LearnDelEmpIdFirstAdditionalPaymentThreshold]  INT             NULL,
    [LearnDelEmpIdSecondAdditionalPaymentThreshold] INT             NULL,
    [LearnDelHistDaysThisApp]                       INT             NULL,
    [LearnDelHistProgEarnings]                      DECIMAL (12, 5) NULL,
    [LearnDelInitialFundLineType]                   VARCHAR (100)   NULL,
    [LearnDelMathEng]                               BIT             NULL,
    [MathEngAimValue]                               DECIMAL (12, 5) NULL,
    [OutstandNumOnProgInstalm]                      INT             NULL,
    [PlannedNumOnProgInstalm]                       INT             NULL,
    [PlannedTotalDaysIL]                            INT             NULL,
    [SecondIncentiveThresholdDate]                  DATE            NULL,
    [ThresholdDays]                                 INT             NULL,
    [LearnDelProgEarliestACT2Date]                  DATE            NULL,
    [LearnDelNonLevyProcured]                       BIT             NULL,
    [LearnDelApplicCareLeaverIncentive]             DECIMAL (12, 5) NULL,
    [LearnDelHistDaysCareLeavers]                   INT             NULL,
    [LearnDelAccDaysILCareLeavers]                  INT             NULL,
    [LearnDelPrevAccDaysILCareLeavers]              INT             NULL,
    [LearnDelLearnerAddPayThresholdDate]            DATE            NULL,
    [LearnDelRedCode]                               INT             NULL,
    [LearnDelRedStartDate]                          DATE            NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[AEC_LearningDelivery] ADD CONSTRAINT [FK_AECLearningDelivery_AECLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Rulebase].[AEC_Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Rulebase].[AEC_LearningDelivery] CHECK CONSTRAINT [FK_AECLearningDelivery_AECLearner]
GO

ALTER TABLE [Rulebase].[AEC_LearningDelivery]  WITH NOCHECK ADD  CONSTRAINT [FK_AEC_LearningDelivery_ValidLearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Valid].[LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber])
GO

ALTER TABLE [Rulebase].[AEC_LearningDelivery] CHECK CONSTRAINT [FK_AEC_LearningDelivery_ValidLearningDelivery]
GO
