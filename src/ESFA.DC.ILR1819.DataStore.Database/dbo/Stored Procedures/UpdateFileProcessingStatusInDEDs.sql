
Create procedure [dbo].[UpdateFileProcessingStatusInDEDs] (@ukprn int, @fileName NVARCHAR(100)) as
 
BEGIN 
UPDATE DEDS_FD
SET  [Success]='1'
FROM [dbo].[FileDetails]   DEDS_FD
WHERE [UKPRN] = @ukprn AND [Filename] = @fileName
END 

