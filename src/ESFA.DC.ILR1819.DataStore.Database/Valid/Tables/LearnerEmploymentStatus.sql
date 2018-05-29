CREATE TABLE [Valid].[LearnerEmploymentStatus] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [EmpStat]        INT          NULL,
    [DateEmpStatApp] DATE         NOT NULL,
    [EmpId]          INT          NULL,
    [AgreeId]        VARCHAR (6)  NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [DateEmpStatApp] ASC)
);

