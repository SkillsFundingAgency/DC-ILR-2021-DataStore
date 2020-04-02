CREATE PROCEDURE Valid.GetLearnerDetails 
	@ukprn INT,
	@fundModel INT,
	@conRefNumbers VARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
		0 AS Id,
		l.Ukprn,
		l.Uln,
		l.LearnRefNumber,
		l.CampId,
		l.Pmukprn,
		ld.ConRefNumber,
		ld.LearnAimRef,
		ld.AimSeqNumber,
		ld.FundModel,
		ld.LearnStartDate,
		ld.LearnPlanEndDate,
		ld.LearnActEndDate,
		ld.CompStatus,
		ld.DelLocPostCode,
		ld.Outcome,
		ld.AddHours,
		ld.PartnerUkprn,
		ld.SwsupAimId
	FROM Valid.Learner l
	INNER JOIN Valid.LearningDelivery ld 
		ON l.UKPRN = ld.UKPRN AND l.LearnRefNumber = ld.LearnRefNumber
	INNER JOIN (SELECT Value as ConRefNumber FROM OPENJSON(@conRefNumbers,'$') ) as c
		ON c.ConRefNumber = ld.ConRefNumber
	WHERE l.UKPRN = @ukprn
	AND ld.FundModel = @fundModel
	AND ld.ConRefNumber IS NOT NULL
END
GO

GRANT EXECUTE ON Valid.GetLearnerDetails TO DataViewing;
