/****** Object:  StoredProcedure [dbo].[sp_ApplyLabel]    Script Date: 01/28/2007 16:13:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ApplyLabel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_ApplyLabel]
GO
/****** Object:  StoredProcedure [dbo].[sp_ApplyLabel]    Script Date: 01/28/2007 16:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE dbo.sp_ApplyLabel
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
GO
