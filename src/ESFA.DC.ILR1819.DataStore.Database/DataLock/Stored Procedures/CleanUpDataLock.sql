

CREATE PROCEDURE [DataLock].[CleanUpDataLock] (@ukprn int) AS
BEGIN 
	
DELETE FROM [DataLock].[ValidationError]
    WHERE [Ukprn] = @ukprn

DELETE FROM [DataLock].[PriceEpisodeMatch]
    WHERE [Ukprn] = @ukprn

DELETE FROM [DataLock].[PriceEpisodePeriodMatch]
    WHERE [Ukprn] = @ukprn


END 


