
create view Valid.TrailblazerApprenticeshipFinancialRecord
as
	select
		UKPRN
		,LearnRefNumber
		,AimSeqNumber
		,AFinType as TBFinType
		,AFinCode as TBFinCode
		,AFinAmount as TBFinAmount
		,AFinDate as TBFinDate
	from
		Valid.AppFinRecord
