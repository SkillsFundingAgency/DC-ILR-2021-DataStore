﻿CREATE TABLE [dbo].[FileDetails] (
    [ID]                            BIGINT           IDENTITY (1, 1) NOT NULL,
    [UKPRN]                         INT           NOT NULL,
    [Filename]                      NVARCHAR (50) NULL,
    [FileSizeKb]                    BIGINT        NULL,
    [TotalLearnersSubmitted]        INT           NULL,
    [TotalValidLearnersSubmitted]   INT           NULL,
    [TotalInvalidLearnersSubmitted] INT           NULL,
    [TotalErrorCount]               INT           NULL,
    [TotalWarningCount]             INT           NULL,
    [SubmittedTime]                 DATETIME      NULL,
    [Success]                       BIT           NULL,
	[OrgName]                       NVARCHAR (255) NULL,
	[OrgVersion]                    NVARCHAR (50) NULL,
	[LarsVersion]                   NVARCHAR (50) NULL,
	[EmployersVersion]              NVARCHAR (50) NULL,
	[PostcodesVersion]              NVARCHAR (50) NULL,
	[CampusIdentifierVersion]       NVARCHAR (50) NULL,
	[EasUploadDateTime]             DATETIME      NULL,
    CONSTRAINT [PK_dbo.FileDetails] UNIQUE NONCLUSTERED ([UKPRN] ASC, [Filename] ASC, [Success] ASC), 
    CONSTRAINT [PK_FileDetails] PRIMARY KEY ([ID])
);

