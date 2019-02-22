CREATE TABLE [Rulebase].[AEC_LearningDelivery_Period] (
    [UKPRN]                                        INT             NOT NULL,
    [LearnRefNumber]                               VARCHAR (12)    NOT NULL,
    [AimSeqNumber]                                 INT             NOT NULL,
    [Period]                                       INT             NOT NULL,
    [DisadvFirstPayment]                           DECIMAL (12, 5) NULL,
    [DisadvSecondPayment]                          DECIMAL (12, 5) NULL,
    [FundLineType]                                 VARCHAR (100)   NULL,
    [InstPerPeriod]                                INT             NULL,
    [LDApplic1618FrameworkUpliftBalancingPayment]  DECIMAL (12, 5) NULL,
    [LDApplic1618FrameworkUpliftCompletionPayment] DECIMAL (12, 5) NULL,
    [LDApplic1618FrameworkUpliftOnProgPayment]     DECIMAL (12, 5) NULL,
    [LearnDelContType]                             VARCHAR (50)    NULL,
    [LearnDelFirstEmp1618Pay]                      DECIMAL (12, 5) NULL,
    [LearnDelFirstProv1618Pay]                     DECIMAL (12, 5) NULL,
    [LearnDelLevyNonPayInd]                        INT             NULL,
    [LearnDelSecondEmp1618Pay]                     DECIMAL (12, 5) NULL,
    [LearnDelSecondProv1618Pay]                    DECIMAL (12, 5) NULL,
    [LearnDelSEMContWaiver]                        BIT             NULL,
    [LearnDelSFAContribPct]                        DECIMAL (12, 5) NULL,
    [LearnSuppFund]                                BIT             NULL,
    [LearnSuppFundCash]                            DECIMAL (12, 5) NULL,
    [MathEngBalPayment]                            DECIMAL (12, 5) NULL,
    [MathEngBalPct]                                DECIMAL (12, 5) NULL,
    [MathEngOnProgPayment]                         DECIMAL (12, 5) NULL,
    [MathEngOnProgPct]                             DECIMAL (12, 5) NULL,
    [ProgrammeAimBalPayment]                       DECIMAL (12, 5) NULL,
    [ProgrammeAimCompletionPayment]                DECIMAL (12, 5) NULL,
    [ProgrammeAimOnProgPayment]                    DECIMAL (12, 5) NULL,
    [ProgrammeAimProgFundIndMaxEmpCont]            DECIMAL (12, 5) NULL,
    [ProgrammeAimProgFundIndMinCoInvest]           DECIMAL (12, 5) NULL,
    [ProgrammeAimTotProgFund]                      DECIMAL (12, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [Period] ASC)
);
GO

ALTER TABLE [Rulebase].[AEC_LearningDelivery_Period] ADD CONSTRAINT [FK_AECLearningDeliveryPeriod_AECLearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Rulebase].[AEC_LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber]);
GO

ALTER TABLE [Rulebase].[AEC_LearningDelivery_Period] CHECK CONSTRAINT [FK_AECLearningDeliveryPeriod_AECLearningDelivery]
GO