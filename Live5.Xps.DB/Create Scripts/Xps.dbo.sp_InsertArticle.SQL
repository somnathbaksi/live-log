/****** Object:  StoredProcedure [dbo].[sp_InsertArticle]    Script Date: 11/15/2006 19:16:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertArticle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_InsertArticle]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertArticle]    Script Date: 11/15/2006 19:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertArticle]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_InsertArticle 
	(
	@Id uniqueidentifier,
	@Title nvarchar(100),
	@Summary nvarchar(200),
	@ServiceType nvarchar(100),
	@Author uniqueidentifier,
	@Content ntext
	)
AS
DECLARE @TranName VARCHAR(20);
SELECT @TranName = ''InsertArticleTransaction'';

	BEGIN
	BEGIN TRANSACTION @TranName;
	Insert Into tbl_Entry( Id, Title,Summary,ServiceType,Author) values(
	@Id,@Title,@Summary,@ServiceType,@Author)
	Insert Into tbl_Article (EntryId, Content) values(@Id,@Content)
	
	COMMIT TRANSACTION MyTransaction;
	END
	RETURN
' 
END
GO
