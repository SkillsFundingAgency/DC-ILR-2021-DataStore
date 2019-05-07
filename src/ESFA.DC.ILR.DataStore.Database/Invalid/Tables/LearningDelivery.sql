CREATE TABLE [Invalid].[LearningDelivery] (
    [LearningDelivery_Id] INT            NOT NULL,
    [Learner_Id]          INT            NULL,
    [UKPRN]               INT            NOT NULL,
    [LearnRefNumber]      VARCHAR (100)  NULL,
    [LearnAimRef]         VARCHAR (1000) NULL,
    [AimType]             BIGINT         NULL,
    [AimSeqNumber]        BIGINT         NULL,
    [LearnStartDate]      DATE           NULL,
    [OrigLearnStartDate]  DATE           NULL,
    [LearnPlanEndDate]    DATE           NULL,
    [FundModel]           BIGINT         NULL,
    [ProgType]            BIGINT         NULL,
    [FworkCode]           BIGINT         NULL,
    [PwayCode]            BIGINT         NULL,
    [StdCode]             BIGINT         NULL,
    [PartnerUKPRN]        BIGINT         NULL,
    [DelLocPostCode]      VARCHAR (1000) NULL,
    [AddHours]            BIGINT         NULL,
    [PriorLearnFundAdj]   BIGINT         NULL,
    [OtherFundAdj]        BIGINT         NULL,
    [ConRefNumber]        VARCHAR (1000) NULL,
    [EPAOrgID]            VARCHAR (1000) NULL,
    [EmpOutcome]          BIGINT         NULL,
    [CompStatus]          BIGINT         NULL,
    [LearnActEndDate]     DATE           NULL,
    [WithdrawReason]      BIGINT         NULL,
    [Outcome]             BIGINT         NULL,
    [AchDate]             DATE           NULL,
    [OutGrade]            VARCHAR (1000) NULL,
    [SWSupAimId]          VARCHAR (1000) NULL, 
    CONSTRAINT [PK_LearningDelivery] PRIMARY KEY ([UKPRN] ASC,[LearningDelivery_Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LearningDelivery]
    ON [Invalid].[LearningDelivery]([Learner_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearningDelivery]
    ON [Invalid].[LearningDelivery]([LearnRefNumber] ASC, [AimSeqNumber] ASC);

