CREATE PROCEDURE [dbo].[GetACTCounts]
AS	
BEGIN

DECLARE @Aims TABLE(
      UKPRN Varchar(50)
      ,LearnRefNumber   Varchar(50)
      ,LearnAimRef   Varchar(50)
      ,FundModel   Varchar(50)
      ,ContractType Varchar(50)
      ,LearnDelFAMDateFrom   date);
DECLARE @AimsNoDups TABLE(
      UKPRN Varchar(50)
      ,LearnRefNumber   Varchar(50)
      ,LearnAimRef   Varchar(50)
      ,ContractType Varchar(50)
      ,LearnDelFAMDateFrom   date);
DECLARE @MaxDate TABLE(
      UKPRN Varchar(50)
      ,LearnRefNumber   Varchar(50)
      ,LearnAimRef   Varchar(50)
      ,LearnDelFAMDateFrom   date);

INSERT INTO @Aims
SELECT ld.UKPRN
		,ld.LearnRefNumber
		,ld.LearnAimRef
		,FundModel
		,concat(ldf.LearnDelFAMType
		,cast(ldf.LearnDelFAMCode as varchar(10))) as [ContractType]
		,ldf.LearnDelFAMDateFrom
FROM [Valid].[LearningDelivery] as ld WITH (NOLOCK)
	join [Valid].[LearningDeliveryFAM] as ldf WITH (NOLOCK)
	 on ldf.AimSeqNumber = ld.AimSeqNumber and ldf.LearnRefNumber = ld.LearnRefNumber and ld.UKPRN = ldf.UKPRN
	 inner join [dbo].[FileDetails] fd
	 on ldf.ukprn = fd.ukprn and success = 1
WHERE	
		FundModel=36 and 
		ldf.LearnDelFAMType = 'ACT' and
		 ld.LearnAimRef = 'ZPROG001'
INSERT INTO @MaxDate
	SELECT DISTINCT UKPRN, LearnRefNumber, LearnAimRef, MAX(LearnDelFAMDateFrom) from @Aims
	GROUP BY UKPRN, LearnRefNumber, LearnAimRef
INSERT INTO @AimsNoDups
SELECT
		a.UKPRN,
		a.LearnRefNumber,
		a.LearnAimRef,
		a.ContractType, 
		b.LearnDelFAMDateFrom 
FROM @Aims A
INNER JOIN @MaxDate B on
			a.UKPRN = b.UKPRN and
			a.LearnRefNumber = b.LearnRefNumber and
			a.LearnAimRef = b.LearnAimRef and
			a.LearnDelFAMDateFrom = b.LearnDelFAMDateFrom
 SELECT 
	 ROW_NUMBER() over (ORDER BY del.[UKPRN]) AS Id,   
	 del.[UKPRN] 
     ,count(distinct act1.[LearnRefNumber]) [LearnersAct1]
     ,count(distinct act2.[LearnRefNumber]) [LearnersAct2]
 FROM [Valid].[LearningDelivery] del
 INNER JOIN [dbo].[FileDetails] fd on 
			del.ukprn = fd.ukprn and success = 1
 LEFT JOIN @AimsNoDups act1 on 
			del.ukprn = act1.ukprn and
			del.LearnRefNumber = act1.LearnRefNumber and 
			act1.LearnAimRef = del.LearnAimRef and 
			act1.contracttype = 'ACT1'
 LEFT JOIN @AimsNoDups act2 on 
			del.ukprn = act2.ukprn and
			 del.LearnRefNumber = act2.LearnRefNumber and 
			 act2.LearnAimRef = del.LearnAimRef and 
			 act2.contracttype = 'ACT2'
 WHERE del.LearnAimRef = 'ZPROG001' and FundModel = 36
 GROUP BY del.UKPRN
 ORDER BY del.ukprn

 END
GO

GRANT EXECUTE ON dbo.GetACTCounts TO DataViewing;

