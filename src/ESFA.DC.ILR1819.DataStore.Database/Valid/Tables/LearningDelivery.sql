CREATE TABLE [Valid].[LearningDelivery] (
    [UKPRN]              INT          NOT NULL,
    [LearnRefNumber]     VARCHAR (12) NOT NULL,
    [LearnAimRef]        VARCHAR (8)  NOT NULL,
    [AimType]            INT          NOT NULL,
    [AimSeqNumber]       INT          NOT NULL,
    [LearnStartDate]     DATE         NOT NULL,
    [OrigLearnStartDate] DATE         NULL,
    [LearnPlanEndDate]   DATE         NOT NULL,
    [FundModel]          INT          NOT NULL,
    [ProgType]           INT          NULL,
    [FworkCode]          INT          NULL,
    [PwayCode]           INT          NULL,
    [StdCode]            INT          NULL,
    [PartnerUKPRN]       INT          NULL,
    [DelLocPostCode]     VARCHAR (8)  NULL,
    [AddHours]           INT          NULL,
    [PriorLearnFundAdj]  INT          NULL,
    [OtherFundAdj]       INT          NULL,
    [ConRefNumber]       VARCHAR (20) NULL,
    [EPAOrgID]           VARCHAR (7)  NULL,
    [EmpOutcome]         INT          NULL,
    [CompStatus]         INT          NOT NULL,
    [LearnActEndDate]    DATE         NULL,
    [WithdrawReason]     INT          NULL,
    [Outcome]            INT          NULL,
    [AchDate]            DATE         NULL,
    [OutGrade]           VARCHAR (6)  NULL,
    [SWSupAimId]         VARCHAR (36) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC)
);
GO

ALTER TABLE [Valid].[LearningDelivery] ADD CONSTRAINT [FK_LearningDelivery_Learner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber])
GO

ALTER TABLE [Valid].[LearningDelivery] CHECK CONSTRAINT [FK_LearningDelivery_Learner]
GO