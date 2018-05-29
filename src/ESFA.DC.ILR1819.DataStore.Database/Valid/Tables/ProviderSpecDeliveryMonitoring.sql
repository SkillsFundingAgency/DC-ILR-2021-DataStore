CREATE TABLE [Valid].[ProviderSpecDeliveryMonitoring] (
    [UKPRN]               INT          NOT NULL,
    [LearnRefNumber]      VARCHAR (12) NOT NULL,
    [AimSeqNumber]        INT          NOT NULL,
    [ProvSpecDelMonOccur] VARCHAR (1)  NOT NULL,
    [ProvSpecDelMon]      VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [ProvSpecDelMonOccur] ASC)
);

