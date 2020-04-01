
CREATE VIEW Valid.ApprenticeshipFinancialRecord
AS
	SELECT
		UKPRN
		,LearnRefNumber
		,AimSeqNumber
		,AFinType
		,AFinCode
		,AFinAmount
		,AFinDate
	FROM
		Valid.AppFinRecord