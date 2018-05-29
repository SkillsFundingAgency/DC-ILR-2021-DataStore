CREATE TABLE [Invalid].[ContactPreference] (
    [ContactPreference_Id] INT           NOT NULL,
    [Learner_Id]           INT           NULL,
    [UKPRN]                INT           NOT NULL,
    [LearnRefNumber]       VARCHAR (100) NULL,
    [ContPrefType]         VARCHAR (100) NULL,
    [ContPrefCode]         BIGINT        NULL, 
    CONSTRAINT [PK_ContactPreference] PRIMARY KEY ([UKPRN] ASC, [ContactPreference_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_ContactPreference]
    ON [Invalid].[ContactPreference]([Learner_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_ContactPreference]
    ON [Invalid].[ContactPreference]([LearnRefNumber] ASC, [ContPrefType] ASC);

