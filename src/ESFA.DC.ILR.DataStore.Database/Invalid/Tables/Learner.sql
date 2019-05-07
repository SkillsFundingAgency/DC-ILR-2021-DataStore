CREATE TABLE [Invalid].[Learner] (
    [Learner_Id]         INT            NOT NULL,
    [LearnRefNumber]     VARCHAR (100)  NULL,
    [UKPRN]              INT            NOT NULL,
    [PrevLearnRefNumber] VARCHAR (1000) NULL,
    [PrevUKPRN]          BIGINT         NULL,
    [PMUKPRN]            BIGINT         NULL,
    [ULN]                BIGINT         NULL,
    [FamilyName]         VARCHAR (1000) NULL,
    [GivenNames]         VARCHAR (1000) NULL,
    [DateOfBirth]        DATE           NULL,
    [Ethnicity]          BIGINT         NULL,
    [Sex]                VARCHAR (1000) NULL,
    [LLDDHealthProb]     BIGINT         NULL,
    [NINumber]           VARCHAR (1000) NULL,
    [PriorAttain]        BIGINT         NULL,
    [Accom]              BIGINT         NULL,
    [ALSCost]            BIGINT         NULL,
    [PlanLearnHours]     BIGINT         NULL,
    [PlanEEPHours]       BIGINT         NULL,
    [MathGrade]          VARCHAR (1000) NULL,
    [EngGrade]           VARCHAR (1000) NULL,
    [PostcodePrior]      VARCHAR (1000) NULL,
    [Postcode]           VARCHAR (1000) NULL,
    [AddLine1]           VARCHAR (1000) NULL,
    [AddLine2]           VARCHAR (1000) NULL,
    [AddLine3]           VARCHAR (1000) NULL,
    [AddLine4]           VARCHAR (1000) NULL,
    [TelNo]              VARCHAR (1000) NULL,
    [Email]              VARCHAR (1000) NULL,
    [CampId]             VARCHAR (1000) NULL,
    [OTJHours]           BIGINT         NULL, 
    CONSTRAINT [PK_Learner] PRIMARY KEY ([UKPRN] ASC, [Learner_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_Learner]
    ON [Invalid].[Learner]([LearnRefNumber] ASC);

