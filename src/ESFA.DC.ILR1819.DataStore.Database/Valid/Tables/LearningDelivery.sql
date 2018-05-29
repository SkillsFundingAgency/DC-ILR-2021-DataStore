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
CREATE NONCLUSTERED INDEX [ix_Valid_LearningDelivery]
    ON [Valid].[LearningDelivery]([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC);

