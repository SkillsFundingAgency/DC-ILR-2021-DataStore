CREATE TABLE [Valid].[ProviderSpecDeliveryMonitoring] (
    [UKPRN]               INT          NOT NULL,
    [LearnRefNumber]      VARCHAR (12) NOT NULL,
    [AimSeqNumber]        INT          NOT NULL,
    [ProvSpecDelMonOccur] VARCHAR (1)  NOT NULL,
    [ProvSpecDelMon]      VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [ProvSpecDelMonOccur] ASC)
);
GO

ALTER TABLE [Valid].[ProviderSpecDeliveryMonitoring] ADD CONSTRAINT [FK_ProviderSpecDeliveryMonitoring_LearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Valid].[LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber])
GO

ALTER TABLE [Valid].[ProviderSpecDeliveryMonitoring] CHECK CONSTRAINT [FK_ProviderSpecDeliveryMonitoring_LearningDelivery]
GO
