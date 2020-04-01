CREATE TABLE [Invalid].[CollectionDetails] (
    [CollectionDetails_Id] INT         NOT NULL,
    [UKPRN]                INT         NOT NULL,
    [Collection]           VARCHAR (3) NULL,
    [Year]                 VARCHAR (4) NULL,
    [FilePreparationDate]  DATE        NULL, 
    CONSTRAINT [PK_CollectionDetails] PRIMARY KEY ([UKPRN] ASC, [CollectionDetails_Id] ASC)
);

