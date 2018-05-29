CREATE TABLE [Valid].[Learner] (
    [UKPRN]              INT           NOT NULL,
    [LearnRefNumber]     VARCHAR (12)  NOT NULL,
    [PrevLearnRefNumber] VARCHAR (12)  NULL,
    [PrevUKPRN]          INT           NULL,
    [PMUKPRN]            INT           NULL,
    [ULN]                BIGINT        NOT NULL,
    [FamilyName]         VARCHAR (100) NULL,
    [GivenNames]         VARCHAR (100) NULL,
    [DateOfBirth]        DATE          NULL,
    [Ethnicity]          INT           NOT NULL,
    [Sex]                VARCHAR (1)   NOT NULL,
    [LLDDHealthProb]     INT           NOT NULL,
    [NINumber]           VARCHAR (9)   NULL,
    [PriorAttain]        INT           NULL,
    [Accom]              INT           NULL,
    [ALSCost]            INT           NULL,
    [PlanLearnHours]     INT           NULL,
    [PlanEEPHours]       INT           NULL,
    [MathGrade]          VARCHAR (4)   NULL,
    [EngGrade]           VARCHAR (4)   NULL,
    [PostcodePrior]      VARCHAR (8)   NULL,
    [Postcode]           VARCHAR (8)   NULL,
    [AddLine1]           VARCHAR (50)  NULL,
    [AddLine2]           VARCHAR (50)  NULL,
    [AddLine3]           VARCHAR (50)  NULL,
    [AddLine4]           VARCHAR (50)  NULL,
    [TelNo]              VARCHAR (18)  NULL,
    [Email]              VARCHAR (100) NULL,
    [CampId]             VARCHAR (8)   NULL,
    [OTJHours]           BIGINT        NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);


GO
CREATE NONCLUSTERED INDEX [ix_Valid_Learner]
    ON [Valid].[Learner]([UKPRN] ASC, [LearnRefNumber] ASC);

