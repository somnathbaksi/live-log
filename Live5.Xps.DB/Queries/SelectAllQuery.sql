SELECT QueryId, ServiceType, QueryContent
FROM tbl_Query 

BEGIN
	--SET NOCOUNT ON
	
	SELECT QueryId,ServiceType,QueryContent 
	FROM tbl_Query WHERE QueryId='cbc98a8d-9824-4893-8d8b-b4a39c360bef'
	
	IF (@@ROWCOUNT = 0)
	BEGIN
	SELECT QueryId,ServiceType,QueryContent 
	FROM tbl_TempQuery WHERE QueryId='cbc98a8d-9824-4893-8d8b-b4a39c360bef'
	END
	
END