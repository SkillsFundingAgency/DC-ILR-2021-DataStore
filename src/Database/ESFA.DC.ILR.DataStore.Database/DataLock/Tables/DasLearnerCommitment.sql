CREATE TABLE [DataLock].[DasLearnerCommitment] (
    [Ukprn]          BIGINT        NOT NULL,
    [LearnRefNumber] VARCHAR (100) NOT NULL,
    [AimSeqNumber]   BIGINT        NOT NULL,
    [CommitmentId]   VARCHAR (50)  NOT NULL, 
    CONSTRAINT [PK_DasLearnerCommitment] PRIMARY KEY ([Ukprn], [AimSeqNumber], [LearnRefNumber])
);

