Create PROCEDURE Valid.GetLearnerAndDeliveryDetails 
	@LastUpdatedDateTime datetime,
	@Ukprn INT = null,
	@AimTypeIsOne bit = null,
	@StdCodeIsNotNull bit = null,
	@PageNumber INT = 1,
	@PageSize   INT = 1000

WITH RECOMPILE
AS
BEGIN
  SET NOCOUNT ON;
	
	IF OBJECT_ID('tempdb..##dasapiukprns') IS NOT NULL
		DROP TABLE ##dasapiukprns;

	SELECT 
		DISTINCT UKPRN
	INTO 
		##dasapiukprns
	FROM 
		FileDetails fd
	WHERE
		fd.SubmittedTime >= @LastUpdatedDateTime

	SELECT 
		NEWID() as Id
		,l.[UKPRN]
		, l.[LearnRefNumber]
		, l.[ULN]
		, l.[FamilyName]
		, l.[GivenNames]
		, l.[DateOfBirth]
		, l.[NINumber]
		, ld.[AimType]
		, ld.[LearnStartDate]
		, ld.[LearnPlanEndDate]
		, ld.[FundModel]
		, ld.[StdCode]
		, ld.[DelLocPostCode]
		, ld.[EPAOrgID]
		, ld.[CompStatus]
		, ld.[LearnActEndDate]
		, ld.[WithdrawReason]
		, ld.[Outcome]
		, ld.[AchDate]
		, ld.[OutGrade]
	FROM 
		[Valid].[Learner] l
	RIGHT JOIN
		[Valid].[LearningDelivery] ld
	ON
		l.UKPRN = ld.UKPRN
	AND
		l.LearnRefNumber = ld.LearnRefNumber
	WHERE
		@Ukprn is null OR (l.UKPRN in (SELECT UKPRN FROM ##dasapiukprns) AND l.UKPRN = @Ukprn)
	AND
		(@AimTypeIsOne is null OR @AimTypeIsOne = 0 OR (ld.AimType = 1))
	AND
		(@StdCodeIsNotNull is null OR @StdCodeIsNotNull = 0 OR (ld.StdCode is not null))
	ORDER BY
			l.UKPRN, l.LearnRefNumber
		OFFSET @PageSize * (@PageNumber -1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
END
GO

GRANT EXECUTE ON Valid.GetLearnerAndDeliveryDetails TO DataViewing;