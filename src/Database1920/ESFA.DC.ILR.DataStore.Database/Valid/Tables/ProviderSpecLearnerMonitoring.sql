CREATE TABLE [Valid].[ProviderSpecLearnerMonitoring] (
    [UKPRN]                 INT          NOT NULL,
    [LearnRefNumber]        VARCHAR (12) NOT NULL,
    [ProvSpecLearnMonOccur] VARCHAR (1)  NOT NULL,
    [ProvSpecLearnMon]      VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [ProvSpecLearnMonOccur] ASC)
);
GO

ALTER TABLE [Valid].[ProviderSpecLearnerMonitoring] ADD CONSTRAINT [FK_ProviderSpecLearnerMonitoring_Learner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber])
GO

ALTER TABLE [Valid].[ProviderSpecLearnerMonitoring] CHECK CONSTRAINT [FK_ProviderSpecLearnerMonitoring_Learner]
GO