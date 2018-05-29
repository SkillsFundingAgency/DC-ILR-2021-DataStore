CREATE TABLE [Rulebase].[ALB_Learner_Period] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [Period]         INT          NOT NULL,
    [ALBSeqNum]      INT          NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [Period] ASC)
);

