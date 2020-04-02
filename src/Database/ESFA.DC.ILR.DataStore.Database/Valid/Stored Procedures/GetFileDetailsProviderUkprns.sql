Create PROCEDURE Valid.GetFileDetailsProviderUkprns
	@LastId bigint,
	@PageNumber INT = 1,
	@PageSize   INT = 1000,
	@MaxId bigint = null output

WITH RECOMPILE
AS
BEGIN
  SET NOCOUNT ON;
	
	IF @MaxId IS NULL
	BEGIN
		SELECT 
			@MaxId = MAX(fd.ID)
		FROM
			FileDetails fd
	END
	
	SELECT 
		DISTINCT fd.UKPRN
	FROM 
		FileDetails fd
	WHERE
		fd.ID > @LastId AND fd.ID <= @MaxId
	ORDER BY 
		fd.UKPRN
	OFFSET @PageSize * (@PageNumber - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY

select @MaxId
END
GO

GRANT EXECUTE ON Valid.GetFileDetailsProviderUkprns TO DataViewing;