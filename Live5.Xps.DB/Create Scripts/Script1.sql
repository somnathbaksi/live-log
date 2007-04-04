 	

 	CREATE PROCEDURE [dbo].[sp_ApplyLabel]
		(
		@LabelId UNIQUEIDENTIFIER,
		@QueryId UNIQUEIDENTIFIER
		)
	AS
	BEGIN

	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM tbl_LabelQueryAssociation where LabelId=@LabelId AND QueryId=@QueryId)
	     
	     RETURN 2
	     
	INSERT INTO tbl_LabelQueryAssociation (LabelId,QueryId) VALUES (@LabelId,@QueryId)
		RETURN 1
	END
