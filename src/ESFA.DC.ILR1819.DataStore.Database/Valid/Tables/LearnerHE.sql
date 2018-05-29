CREATE TABLE [Valid].[LearnerHE] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [UCASPERID]      VARCHAR (10) NULL,
    [TTACCOM]        INT          NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);

