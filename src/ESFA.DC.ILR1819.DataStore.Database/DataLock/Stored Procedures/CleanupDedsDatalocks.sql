
CREATE PROCEDURE DataLock.[CleanupDedsDatalocks]
	@Ukprn bigint = NULL	
AS

DECLARE @UkprnsToDelete TABLE (UKPRN bigint)

IF @Ukprn Is NULL
BEGIN
	INSERT INTO @UkprnsToDelete
	SELECT DISTINCT lp.[UKPRN] FROM [Valid].[LearningProvider] lp
END
ELSE
BEGIN
	INSERT INTO @UkprnsToDelete (UKPRN) values (@ukprn)
END

DELETE FROM [DataLock].[ValidationError]
    WHERE [Ukprn] IN (SELECT UKPRN from @UkprnsToDelete)

DELETE FROM [DataLock].[PriceEpisodeMatch]
    WHERE [Ukprn] IN (SELECT UKPRN from @UkprnsToDelete)

DELETE FROM [DataLock].[PriceEpisodePeriodMatch]
    WHERE [Ukprn] IN (SELECT UKPRN from @UkprnsToDelete)

