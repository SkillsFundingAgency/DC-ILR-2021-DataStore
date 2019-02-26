CREATE TABLE [Invalid].[LearningDeliveryHE] (
    [LearningDeliveryHE_Id] INT            NOT NULL,
    [UKPRN]                 INT            NOT NULL,
    [LearningDelivery_Id]   INT            NULL,
    [LearnRefNumber]        VARCHAR (100)  NULL,
    [AimSeqNumber]          BIGINT         NULL,
    [NUMHUS]                VARCHAR (1000) NULL,
    [SSN]                   VARCHAR (1000) NULL,
    [QUALENT3]              VARCHAR (1000) NULL,
    [SOC2000]               BIGINT         NULL,
    [SEC]                   BIGINT         NULL,
    [UCASAPPID]             VARCHAR (1000) NULL,
    [TYPEYR]                BIGINT         NULL,
    [MODESTUD]              BIGINT         NULL,
    [FUNDLEV]               BIGINT         NULL,
    [FUNDCOMP]              BIGINT         NULL,
    [STULOAD]               FLOAT (53)     NULL,
    [YEARSTU]               BIGINT         NULL,
    [MSTUFEE]               BIGINT         NULL,
    [PCOLAB]                FLOAT (53)     NULL,
    [PCFLDCS]               FLOAT (53)     NULL,
    [PCSLDCS]               FLOAT (53)     NULL,
    [PCTLDCS]               FLOAT (53)     NULL,
    [SPECFEE]               BIGINT         NULL,
    [NETFEE]                BIGINT         NULL,
    [GROSSFEE]              BIGINT         NULL,
    [DOMICILE]              VARCHAR (1000) NULL,
    [ELQ]                   BIGINT         NULL,
    [HEPostCode]            VARCHAR (1000) NULL, 
    CONSTRAINT [PK_LearningDeliveryHE] PRIMARY KEY ([UKPRN] ASC, [LearningDeliveryHE_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LearningDeliveryHE]
    ON [Invalid].[LearningDeliveryHE]([LearningDelivery_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearningDeliveryHE]
    ON [Invalid].[LearningDeliveryHE]([LearnRefNumber] ASC, [AimSeqNumber] ASC);

