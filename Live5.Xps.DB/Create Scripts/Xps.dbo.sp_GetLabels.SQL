/****** Object:  StoredProcedure [dbo].[sp_GetLabels]    Script Date: 01/28/2007 16:13:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetLabels]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetLabels]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLabels]    Script Date: 01/28/2007 16:13:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetLabels]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_GetLabels

AS
BEGIN
SET NOCOUNT ON

SELECT LabelId,LabelName,Description FROM tbl_Label


	RETURN
	
END
	
' 
END
GO
