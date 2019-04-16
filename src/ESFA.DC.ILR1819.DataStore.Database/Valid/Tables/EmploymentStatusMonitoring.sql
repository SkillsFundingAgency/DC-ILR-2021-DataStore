CREATE TABLE [Valid].[EmploymentStatusMonitoring] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [DateEmpStatApp] DATE         NOT NULL,
    [ESMType]        VARCHAR (3)  NOT NULL,
    [ESMCode]        INT          NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [DateEmpStatApp] ASC, [ESMType] ASC)
);

