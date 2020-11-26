CREATE TABLE [Invalid].[ProviderSpecLearnerMonitoring] (
    [ProviderSpecLearnerMonitoring_Id] INT            NOT NULL,
    [Learner_Id]                       INT            NULL,
    [UKPRN]                            INT            NOT NULL,
    [LearnRefNumber]                   VARCHAR (100)  NULL,
    [ProvSpecLearnMonOccur]            VARCHAR (100)  NULL,
    [ProvSpecLearnMon]                 VARCHAR (1000) NULL, 
    CONSTRAINT [PK_ProviderSpecLearnerMonitoring] PRIMARY KEY ([UKPRN] ASC, [ProviderSpecLearnerMonitoring_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_ProviderSpecLearnerMonitoring]
    ON [Invalid].[ProviderSpecLearnerMonitoring]([Learner_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_ProviderSpecLearnerMonitoring]
    ON [Invalid].[ProviderSpecLearnerMonitoring]([LearnRefNumber] ASC, [ProvSpecLearnMonOccur] ASC);

