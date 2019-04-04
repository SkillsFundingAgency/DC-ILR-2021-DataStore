CREATE PROCEDURE Valid.GetLearnerDetails 
	@ukprn INT,
	@ConRefNumbers VARCHAR(MAX)
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
		ld.SwsupAimId,
		ldf.LearnDelFamtype,
		ldf.LearnDelFamcode,
		psdm.ProvSpecDelMonOccur,
		psdm.ProvSpecDelMon,
		pslm.ProvSpecLearnMonOccur,
		pslm.ProvSpecLearnMon
	FROM Valid.Learner l
	INNER JOIN Valid.LearningDelivery ld 
		ON l.UKPRN = ld.UKPRN AND l.LearnRefNumber = ld.LearnRefNumber
	INNER JOIN (SELECT Value as ConRefNumber FROM OPENJSON(@ConRefNumbers,'$') ) as c
		ON c.ConRefNumber = ld.ConRefNumber
	LEFT OUTER JOIN Valid.LearningDeliveryFAM ldf 
		ON ldf.UKPRN = ld.UKPRN AND ldf.LearnRefNumber = ld.LearnRefNumber AND ldf.AimSeqNumber = ld.AimSeqNumber
	LEFT OUTER JOIN Valid.ProviderSpecDeliveryMonitoring psdm
		ON psdm.UKPRN = ld.UKPRN AND psdm.LearnRefNumber = ld.LearnRefNumber AND psdm.AimSeqNumber = ld.AimSeqNumber
	LEFT OUTER JOIN Valid.ProviderSpecLearnerMonitoring pslm
		ON pslm.UKPRN = l.UKPRN AND pslm.LearnRefNumber = l.LearnRefNumber
	WHERE l.UKPRN = @ukprn
	AND ld.ConRefNumber IS NOT NULL
END
GO

GRANT EXECUTE ON Valid.GetLearnerDetails TO DataViewing;
