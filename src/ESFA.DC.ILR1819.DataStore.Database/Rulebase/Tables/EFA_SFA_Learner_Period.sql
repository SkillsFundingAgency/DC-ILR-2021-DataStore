CREATE TABLE [Rulebase].[EFA_SFA_Learner_Period] (
    [UKPRN]          INT             NOT NULL,
    [LearnRefNumber] VARCHAR (12)    NOT NULL,
    [Period]         INT             NOT NULL,
    [LnrOnProgPay]   DECIMAL (10, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [Period] ASC)
);

