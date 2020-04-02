CREATE TABLE [Valid].[Source] (
    [ProtectiveMarking]   VARCHAR (30)  NULL,
    [UKPRN]               INT           NOT NULL,
    [SoftwareSupplier]    VARCHAR (40)  NULL,
    [SoftwarePackage]     VARCHAR (30)  NULL,
    [Release]             VARCHAR (20)  NULL,
    [SerialNo]            VARCHAR (2)   NULL,
    [DateTime]            DATETIME      NULL,
    [ReferenceData]       VARCHAR (100) NULL,
    [ComponentSetVersion] VARCHAR (20)  NULL, 
    CONSTRAINT [PK_Source] PRIMARY KEY ([UKPRN])
);

