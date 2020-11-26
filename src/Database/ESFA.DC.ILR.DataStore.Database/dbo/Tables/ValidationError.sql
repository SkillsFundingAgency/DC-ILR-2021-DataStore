CREATE TABLE [dbo].[ValidationError] (
    [Id]             BIGINT          IDENTITY (1, 1) NOT NULL,
    [UKPRN]          INT             NULL,
    [Source]         VARCHAR (50)    NULL,
    [LearnAimRef]    VARCHAR (1000)  NULL,
    [AimSeqNum]      BIGINT          NULL,
    [SWSupAimID]     VARCHAR (1000)  NULL,
    [ErrorMessage]   NVARCHAR (MAX)  NULL,
    [FieldValues]    NVARCHAR (2000) NULL,
    [LearnRefNumber] VARCHAR (100)   NULL,
    [RuleName]       VARCHAR (50)    NULL,
    [Severity]       VARCHAR (2)     NULL,
    [FileLevelError] INT             NULL, 
    CONSTRAINT [PK_ValidationError] PRIMARY KEY ([Id])
);
GO
CREATE NONCLUSTERED INDEX [IX_ValidationError] ON [dbo].[ValidationError]
(
[UKPRN] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
