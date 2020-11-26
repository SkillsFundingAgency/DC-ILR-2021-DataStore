﻿CREATE PROCEDURE [dbo].[GetACTCounts]
AS	
BEGIN

WITH cte(UKPRN, LearnDelFamCode, ActCount)
AS
(
	SELECT UKPRN, LearnDelFamCode, COUNT(*) AS ActCount
	FROM
		(SELECT DISTINCT ld.UKPRN, ld.LearnRefNumber, ld.LearnAimRef, ldf.LearnDelFamCode
		FROM Valid.LearningDelivery ld
		INNER JOIN Valid.LearningDeliveryFAM ldf
		ON	ld.UKPRN = ldf.UKPRN 
			AND ld.LearnRefNumber = ldf.LearnRefNumber
			AND ld.AimSeqNumber = ldf.AimSeqNumber
			AND ld.FundModel = 36
			AND ld.LearnAimRef = 'ZPROG001'
			AND ldf.LearnDelFAMType = 'ACT'
		INNER JOIN 
			(SELECT DISTINCT ldf.UKPRN, ldf.LearnRefNumber, ldf.AimSeqNumber, MAX(ldf.LearnDelFAMDateFrom) AS MaxLearnDelFAMDateFrom
			FROM Valid.LearningDeliveryFAM ldf
			WHERE ldf.LearnDelFAMType = 'ACT'
			GROUP BY ldf.UKPRN, ldf.LearnRefNumber, ldf.AimSeqNumber) maxLdfs
		ON ld.UKPRN = maxLdfs.UKPRN
				AND ld.LearnRefNumber = maxLdfs.LearnRefNumber
				AND ld.AimSeqNumber = maxLdfs.AimSeqNumber
				AND ldf.LearnDelFAMDateFrom = MaxLearnDelFAMDateFrom) sub
	GROUP BY UKPRN, LearnDelFamCode
)


SELECT
	ROW_NUMBER() OVER (ORDER BY UKPRN) AS Id,
	Ukprn,
	COALESCE(LearnersAct1, 0) AS LearnersAct1,
	COALESCE(LearnersAct2, 0) AS LearnersAct2
FROM
(		
	SELECT 
		DISTINCT(fd.UKPRN) as UKPRN,
		act1.ActCount AS LearnersAct1,
		act2.ActCount AS LearnersAct2
	FROM FileDetails fd
	LEFT JOIN (SELECT * FROM cte WHERE LearnDelFAMCode = 1) act1 ON fd.UKPRN = act1.UKPRN
	LEFT JOIN (SELECT * FROM cte WHERE LearnDelFAMCode = 2) act2 ON fd.UKPRN = act2.UKPRN	
) sub
WHERE LearnersAct1 != 0 OR LearnersAct2 != 0
ORDER BY UKPRN

END
GO

GRANT EXECUTE ON dbo.GetACTCounts TO DataViewing;

