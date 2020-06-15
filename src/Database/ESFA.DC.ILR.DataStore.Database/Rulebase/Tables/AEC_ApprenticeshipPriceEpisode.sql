CREATE TABLE [Rulebase].[AEC_ApprenticeshipPriceEpisode] (
    [UKPRN]                                                  INT             NOT NULL,
    [LearnRefNumber]                                         VARCHAR (12)    NOT NULL,
    [PriceEpisodeIdentifier]                                 VARCHAR (25)    NOT NULL,
    [TNP4]                                                   DECIMAL (12, 5) NULL,
    [TNP1]                                                   DECIMAL (12, 5) NULL,
    [EpisodeStartDate]                                       DATE            NULL,
    [TNP2]                                                   DECIMAL (12, 5) NULL,
    [TNP3]                                                   DECIMAL (12, 5) NULL,
	[PriceEpisode1618FrameworkUpliftRemainingAmount]         DECIMAL (12, 5) NULL,
	[PriceEpisode1618FrameworkUpliftTotPrevEarnings]         DECIMAL (12, 5) NULL,
	[PriceEpisode1618FUBalValue]                             DECIMAL (12, 5) NULL,
	[PriceEpisode1618FUMonthInstValue]                       DECIMAL (12, 5) NULL,
	[PriceEpisode1618FUTotEarnings]                          DECIMAL (12, 5) NULL,
    [PriceEpisodeUpperBandLimit]                             DECIMAL (12, 5) NULL,
    [PriceEpisodePlannedEndDate]                             DATE            NULL,
    [PriceEpisodeActualEndDate]                              DATE            NULL,
    [PriceEpisodeActualEndDateIncEPA]                        DATE            NULL,
    [PriceEpisodeTotalTNPPrice]                              DECIMAL (12, 5) NULL,
    [PriceEpisodeUpperLimitAdjustment]                       DECIMAL (12, 5) NULL,
    [PriceEpisodePlannedInstalments]                         INT             NULL,
    [PriceEpisodeActualInstalments]                          INT             NULL,
    [PriceEpisodeCompletionElement]                          DECIMAL (12, 5) NULL,
    [PriceEpisodePreviousEarnings]                           DECIMAL (12, 5) NULL,
    [PriceEpisodeInstalmentValue]                            DECIMAL (12, 5) NULL,
    [PriceEpisodeTotalEarnings]                              DECIMAL (12, 5) NULL,
    [PriceEpisodeCompleted]                                  BIT             NULL,
    [PriceEpisodeRemainingTNPAmount]                         DECIMAL (12, 5) NULL,
    [PriceEpisodeRemainingAmountWithinUpperLimit]            DECIMAL (12, 5) NULL,
    [PriceEpisodeCappedRemainingTNPAmount]                   DECIMAL (12, 5) NULL,
    [PriceEpisodeExpectedTotalMonthlyValue]                  DECIMAL (12, 5) NULL,
    [PriceEpisodeAimSeqNumber]                               INT             NOT NULL,
    [PriceEpisodeApplic1618FrameworkUpliftCompElement]		 DECIMAL (12, 5) NULL,
    [PriceEpisodeFundLineType]                               VARCHAR (100)   NULL,
    [EpisodeEffectiveTNPStartDate]                           DATE            NULL,
    [PriceEpisodeFirstAdditionalPaymentThresholdDate]        DATE            NULL,
    [PriceEpisodeSecondAdditionalPaymentThresholdDate]       DATE            NULL,
    [PriceEpisodeContractType]                               VARCHAR (50)    NULL,
    [PriceEpisodePreviousEarningsSameProvider]               DECIMAL (12, 5) NULL,
    [PriceEpisodeTotalPMRs]                                  DECIMAL (12, 5) NULL,
    [PriceEpisodeCumulativePMRs]                             DECIMAL (12, 5) NULL,
    [PriceEpisodeCompExemCode]                               INT             NULL,
    [PriceEpisodeLearnerAdditionalPaymentThresholdDate]      DATE            NULL,
    [PriceEpisodeAgreeId]                                    VARCHAR (6)     NULL,
    [PriceEpisodeRedStartDate]                               DATE            NULL,
    [PriceEpisodeRedStatusCode]                              INT             NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [PriceEpisodeIdentifier] ASC)
);
GO

ALTER TABLE [Rulebase].[AEC_ApprenticeshipPriceEpisode] ADD CONSTRAINT [FK_AECApprenticeshipPriceEpisode_AECLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Rulebase].[AEC_Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Rulebase].[AEC_ApprenticeshipPriceEpisode] CHECK CONSTRAINT [FK_AECApprenticeshipPriceEpisode_AECLearner]
GO

ALTER TABLE [Rulebase].[AEC_ApprenticeshipPriceEpisode]  WITH NOCHECK ADD  CONSTRAINT [FK_AEC_ApprenticeshipPriceEpisode_ValidLearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [PriceEpisodeAimSeqNumber])
REFERENCES [Valid].[LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber])
GO

ALTER TABLE [Rulebase].[AEC_ApprenticeshipPriceEpisode] CHECK CONSTRAINT [FK_AEC_ApprenticeshipPriceEpisode_ValidLearningDelivery]
GO
