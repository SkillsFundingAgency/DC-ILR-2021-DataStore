CREATE TABLE [Valid].[ProviderSpecLearnerMonitoring] (
    [UKPRN]                 INT          NOT NULL,
    [LearnRefNumber]        VARCHAR (12) NOT NULL,
    [ProvSpecLearnMonOccur] VARCHAR (1)  NOT NULL,
    [ProvSpecLearnMon]      VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [ProvSpecLearnMonOccur] ASC)
);

