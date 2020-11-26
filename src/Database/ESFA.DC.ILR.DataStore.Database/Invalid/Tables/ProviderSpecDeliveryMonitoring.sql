CREATE TABLE [Invalid].[ProviderSpecDeliveryMonitoring] (
    [ProviderSpecDeliveryMonitoring_Id] INT            NOT NULL,
    [UKPRN]                             INT            NOT NULL,
    [LearningDelivery_Id]               INT            NULL,
    [LearnRefNumber]                    VARCHAR (100)  NULL,
    [AimSeqNumber]                      BIGINT         NULL,
    [ProvSpecDelMonOccur]               VARCHAR (100)  NULL,
    [ProvSpecDelMon]                    VARCHAR (1000) NULL, 
    CONSTRAINT [PK_ProviderSpecDeliveryMonitoring] PRIMARY KEY ([UKPRN] ASC, [ProviderSpecDeliveryMonitoring_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_ProviderSpecDeliveryMonitoring]
    ON [Invalid].[ProviderSpecDeliveryMonitoring]([LearningDelivery_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_ProviderSpecDeliveryMonitoring]
    ON [Invalid].[ProviderSpecDeliveryMonitoring]([LearnRefNumber] ASC, [AimSeqNumber] ASC, [ProvSpecDelMonOccur] ASC);

