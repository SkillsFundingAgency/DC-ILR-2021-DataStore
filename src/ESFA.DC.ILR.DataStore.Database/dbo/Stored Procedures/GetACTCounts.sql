CREATE PROCEDURE [dbo].[GetACTCounts]
AS	
BEGIN


DECLARE @Aims TABLE(
      UKPRN bigint
      ,LearnRefNumber   Varchar(50)
      ,LearnAimRef   Varchar(50)
      ,FundModel   Varchar(50)
      ,LearnDelFAMCode int
      ,LearnDelFAMDateFrom   date);

DECLARE @AimsNoDups TABLE(
       UKPRN bigint
      ,LearnDelFAMCode int
	  ,Learners   int)

DECLARE @MaxDate TABLE(
      UKPRN bigint
      ,LearnRefNumber   Varchar(50)
      ,LearnAimRef   Varchar(50)
      ,LearnDelFAMDateFrom   date);

INSERT INTO @Aims


SELECT ld.UKPRN
		,ld.LearnRefNumber
		,ld.LearnAimRef
		,FundModel
		,ldf.LearnDelFAMCode 
		,ldf.LearnDelFAMDateFrom
FROM [Valid].[LearningDelivery] as ld WITH (NOLOCK)
	join [Valid].[LearningDeliveryFAM] as ldf WITH (NOLOCK)
	 on ldf.AimSeqNumber = ld.AimSeqNumber and ldf.LearnRefNumber = ld.LearnRefNumber and ld.UKPRN = ldf.UKPRN
	 inner join [dbo].[FileDetails] fd
	 on ldf.ukprn = fd.ukprn and success = 1
WHERE	
		FundModel=36 and 
		ldf.LearnDelFAMType = 'ACT' 
		And		ld.LearnAimRef = 'ZPROG001'



INSERT INTO @MaxDate
	SELECT DISTINCT UKPRN, LearnRefNumber, LearnAimRef, MAX(LearnDelFAMDateFrom) from @Aims
	GROUP BY UKPRN, LearnRefNumber, LearnAimRef


INSERT INTO @AimsNoDups

SELECT
		x.UKPRN,
		x.LearnDelFAMCode, 
		Count(x.LearnRefNumber) Learners
FROM (
SELECT
		a.UKPRN,
		a.LearnRefNumber,
		a.LearnAimRef,
		a.LearnDelFAMCode, 
		b.LearnDelFAMDateFrom,
		ROW_NUMBER() OVER(PARTITION BY a.[UKPRN], a.LearnRefNumber order by a.[UKPRN], a.LearnRefNumber) AS rn
FROM @Aims A
INNER JOIN @MaxDate B on
			a.UKPRN = b.UKPRN and
			a.LearnRefNumber = b.LearnRefNumber and
			a.LearnAimRef = b.LearnAimRef and
			a.LearnDelFAMDateFrom = b.LearnDelFAMDateFrom
) x where x.rn =1

Group By ukprn, LearnDelFAMCode
order by ukprn

 Select 
	ROW_NUMBER() over (ORDER BY x.[UKPRN]) AS Id,   
	x.ukprn,
	x.[LearnersAct1],
	x.[LearnersAct2]
		FROM
		( SELECT 
			 distinct fd.[UKPRN]
			 ,IsNull(act1.Learners,0) AS [LearnersAct1]
			 ,IsNull(act2.Learners,0) AS [LearnersAct2]

		 FROM dbo.FileDetails fd
 
		 LEFT JOIN (Select * from @AimsNoDups Where LearnDelFAMCode = 1) act1 on 
					fd.ukprn = act1.ukprn and
					fd.Success = 1
			
		 LEFT JOIN (Select * from @AimsNoDups Where LearnDelFAMCode = 2)  act2 on 
					fd.ukprn = act2.ukprn 
					 and fd.Success = 1
		WHERE act1.Learners is not null or act2.Learners is not null
		) x
ORDER BY x.ukprn

END
GO

GRANT EXECUTE ON dbo.GetACTCounts TO DataViewing;

