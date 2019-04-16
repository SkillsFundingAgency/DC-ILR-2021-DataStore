CREATE TABLE [Invalid].[LearningDeliveryFAM] (
    [LearningDeliveryFAM_Id] INT            NOT NULL,
    [LearningDelivery_Id]    INT            NULL,
    [UKPRN]                  INT            NOT NULL,
    [LearnRefNumber]         VARCHAR (100)  NULL,
    [AimSeqNumber]           BIGINT         NULL,
    [LearnDelFAMType]        VARCHAR (100)  NULL,
    [LearnDelFAMCode]        VARCHAR (1000) NULL,
    [LearnDelFAMDateFrom]    DATE           NULL,
    [LearnDelFAMDateTo]      DATE           NULL, 
    CONSTRAINT [PK_LearningDeliveryFAM] PRIMARY KEY ([UKPRN] ASC,[LearningDeliveryFAM_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LearningDeliveryFAM]
    ON [Invalid].[LearningDeliveryFAM]([LearningDelivery_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearningDeliveryFAM]
    ON [Invalid].[LearningDeliveryFAM]([LearnRefNumber] ASC, [AimSeqNumber] ASC, [LearnDelFAMType] ASC, [LearnDelFAMDateFrom] ASC);

