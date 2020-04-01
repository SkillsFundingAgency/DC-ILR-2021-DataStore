CREATE TABLE [Valid].[LearningDeliveryHE] (
    [UKPRN]          INT            NOT NULL,
    [LearnRefNumber] VARCHAR (12)   NOT NULL,
    [AimSeqNumber]   INT            NOT NULL,
    [NUMHUS]         VARCHAR (20)   NULL,
    [SSN]            VARCHAR (13)   NULL,
    [QUALENT3]       VARCHAR (3)    NULL,
    [SOC2000]        INT            NULL,
    [SEC]            INT            NULL,
    [UCASAPPID]      VARCHAR (9)    NULL,
    [TYPEYR]         INT            NOT NULL,
    [MODESTUD]       INT            NOT NULL,
    [FUNDLEV]        INT            NOT NULL,
    [FUNDCOMP]       INT            NOT NULL,
    [STULOAD]        DECIMAL (4, 1) NULL,
    [YEARSTU]        INT            NOT NULL,
    [MSTUFEE]        INT            NOT NULL,
    [PCOLAB]         DECIMAL (4, 1) NULL,
    [PCFLDCS]        DECIMAL (4, 1) NULL,
    [PCSLDCS]        DECIMAL (4, 1) NULL,
    [PCTLDCS]        DECIMAL (4, 1) NULL,
    [SPECFEE]        INT            NOT NULL,
    [NETFEE]         INT            NULL,
    [GROSSFEE]       INT            NULL,
    [DOMICILE]       VARCHAR (2)    NULL,
    [ELQ]            INT            NULL,
    [HEPostCode]     VARCHAR (8)    NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC)
);
GO

ALTER TABLE [Valid].[LearningDeliveryHE] ADD CONSTRAINT [FK_LearningDeliveryHE_LearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Valid].[LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber])
GO

ALTER TABLE [Valid].[LearningDeliveryHE] CHECK CONSTRAINT [FK_LearningDeliveryHE_LearningDelivery]
GO

