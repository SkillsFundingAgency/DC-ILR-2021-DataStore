CREATE TABLE [Rulebase].[AEC_ApprenticeshipPriceEpisode_Period] (
    [UKPRN]                                                  INT             NOT NULL,
    [LearnRefNumber]                                         VARCHAR (12)    NOT NULL,
    [PriceEpisodeIdentifier]                                 VARCHAR (25)    NOT NULL,
    [Period]                                                 INT             NOT NULL,
    [PriceEpisodeApplic1618FrameworkUpliftBalancing]         DECIMAL (12, 5) NULL,
    [PriceEpisodeApplic1618FrameworkUpliftCompletionPayment] DECIMAL (12, 5) NULL,
    [PriceEpisodeApplic1618FrameworkUpliftOnProgPayment]     DECIMAL (12, 5) NULL,
    [PriceEpisodeBalancePayment]                             DECIMAL (12, 5) NULL,
    [PriceEpisodeBalanceValue]                               DECIMAL (12, 5) NULL,
    [PriceEpisodeCompletionPayment]                          DECIMAL (12, 5) NULL,
    [PriceEpisodeFirstDisadvantagePayment]                   DECIMAL (12, 5) NULL,
    [PriceEpisodeFirstEmp1618Pay]                            DECIMAL (12, 5) NULL,
    [PriceEpisodeFirstProv1618Pay]                           DECIMAL (12, 5) NULL,
    [PriceEpisodeInstalmentsThisPeriod]                      INT             NULL,
    [PriceEpisodeLevyNonPayInd]                              INT             NULL,
    [PriceEpisodeLSFCash]                                    DECIMAL (12, 5) NULL,
    [PriceEpisodeOnProgPayment]                              DECIMAL (12, 5) NULL,
    [PriceEpisodeProgFundIndMaxEmpCont]                      DECIMAL (12, 5) NULL,
    [PriceEpisodeProgFundIndMinCoInvest]                     DECIMAL (12, 5) NULL,
    [PriceEpisodeSecondDisadvantagePayment]                  DECIMAL (12, 5) NULL,
    [PriceEpisodeSecondEmp1618Pay]                           DECIMAL (12, 5) NULL,
    [PriceEpisodeSecondProv1618Pay]                          DECIMAL (12, 5) NULL,
    [PriceEpisodeSFAContribPct]                              DECIMAL (12, 5) NULL,
    [PriceEpisodeTotProgFunding]                             DECIMAL (12, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [PriceEpisodeIdentifier] ASC, [Period] ASC)
);


GO
CREATE NONCLUSTERED INDEX [ix_AEC_ApprenticeshipPriceEpisodePeriod]
    ON [Rulebase].[AEC_ApprenticeshipPriceEpisode_Period]([UKPRN] ASC, [LearnRefNumber] ASC, [PriceEpisodeIdentifier] ASC);

