/****** Object:  StoredProcedure [dbo].[sp_ApplyLabel]    Script Date: 05/22/2007 01:45:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ApplyLabel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_ApplyLabel]
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectQuery]    Script Date: 05/22/2007 01:45:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectQuery]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectQuery]
GO
/****** Object:  StoredProcedure [dbo].[sp_ArticleSearch]    Script Date: 05/22/2007 01:45:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ArticleSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_ArticleSearch]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateUser]    Script Date: 05/22/2007 01:45:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_CreateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_CreateUser]
GO
/****** Object:  StoredProcedure [dbo].[sp_EntrySearch]    Script Date: 05/22/2007 01:45:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_EntrySearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_EntrySearch]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategories]    Script Date: 05/22/2007 01:45:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetCategories]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetCategories]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategory]    Script Date: 05/22/2007 01:45:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetCategory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetCategory]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLabels]    Script Date: 05/22/2007 01:45:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetLabels]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetLabels]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMostRecent]    Script Date: 05/22/2007 01:45:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetMostRecent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetMostRecent]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetQueryByLabel]    Script Date: 05/22/2007 01:45:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetQueryByLabel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetQueryByLabel]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserByUserName]    Script Date: 05/22/2007 01:45:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetUserByUserName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetUserByUserName]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserNameByEmail]    Script Date: 05/22/2007 01:45:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetUserNameByEmail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetUserNameByEmail]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertArticle]    Script Date: 05/22/2007 01:45:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertArticle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_InsertArticle]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertMedia]    Script Date: 05/22/2007 01:45:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertMedia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_InsertMedia]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertQuery]    Script Date: 05/22/2007 01:45:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertQuery]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_InsertQuery]
GO
/****** Object:  StoredProcedure [dbo].[sp_MediaSearch]    Script Date: 05/22/2007 01:45:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_MediaSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_MediaSearch]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveTempQuery]    Script Date: 05/22/2007 01:45:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SaveTempQuery]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SaveTempQuery]
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllQuery]    Script Date: 05/22/2007 01:45:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectAllQuery]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectAllQuery]
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectEntry]    Script Date: 05/22/2007 01:45:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectEntry]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectEntry]
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectEntryType]    Script Date: 05/22/2007 01:45:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectEntryType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectEntryType]
GO
/****** Object:  StoredProcedure [dbo].[sp_ApplyLabel]    Script Date: 05/22/2007 01:45:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ApplyLabel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	CREATE PROCEDURE dbo.sp_ApplyLabel
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectQuery]    Script Date: 05/22/2007 01:45:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectQuery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_SelectQuery 
(
	@QueryId uniqueidentifier
)
AS

BEGIN
	SET NOCOUNT ON
    DECLARE @QueryCount int
    
    SELECT @QueryCount=COUNT(QueryId) FROM tbl_Query WHERE QueryId=@QueryId
	
	IF (@QueryCount<>0)
		BEGIN
		SELECT QueryId,ServiceType,QueryContent 
		FROM tbl_Query WHERE QueryId=@QueryId
		END
	ELSE
		BEGIN
		SELECT QueryId,ServiceType,QueryContent 
		FROM tbl_TempQuery WHERE QueryId=@QueryId
		END
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ArticleSearch]    Script Date: 05/22/2007 01:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ArticleSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_ArticleSearch
	(
	@SearchKey nvarchar(200)
	)
AS

BEGIN

SET NOCOUNT ON

SELECT Id,EntryId,Title,Updated,ServiceType,Summary,
Published,Author,MediaType,Content
FROM tbl_Entry as o
INNER JOIN tbl_Article as t ON o.Id=t.EntryId
where (Title like ''%''+@SearchKey+''%'' 
OR Summary like ''%''+@SearchKey+''%'' 
Or t.Content like ''%''+@SearchKey+''%'')

	RETURN
END
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateUser]    Script Date: 05/22/2007 01:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_CreateUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_CreateUser 
	
	(
	@UserName nvarchar(128),
	@Password  nvarchar(128),
	@Email nvarchar(256),
	@PasswordQuestion nvarchar(256),
	@PasswordAnswer nvarchar(128),
	@IsApproved bit,
	@Comment ntext
	)

AS

BEGIN

   DECLARE @TransName VARCHAR(20)
   SET @TransName=''Trans_CreateUser''
   
   DECLARE @UserId uniqueidentifier
   SET @UserId=newid()
   
   BEGIN TRANSACTION @TransName
   
   INSERT InTo [tbl_User] (UserId, UserName,IsAnonymous,LastActivityDate) 
   values (@UserId,@UserName,0,getdate())
   
   IF (@@ERROR<>0)
	   BEGIN
		 ROLLBACK TRANSACTION @TransName
		 Return -1 --Insert user error.
	   END
   ELSE
       BEGIN
			INSERT INTO [tbl_Membership] (UserId, UserName, Password, Email, PasswordQuestion,
				 PasswordAnswer, IsApproved,
                  Comment, CreateDate, LastPasswordChangedDate,
                   IsLockedOut, LastLockOutDate,
                    FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, 
                    FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart)
                    Values(@UserId, @UserName, @Password, @Email, @PasswordQuestion, @PasswordAnswer,
                     @IsApproved, @Comment,getdate(),getdate(), 0, null, 0, null, 0, null)
            IF(@@ERROR<>0)
					BEGIN
						ROLLBACK TRANSACTION @TransName
						RETURN -2 --Insert membership error.
					END
			ELSE 
					BEGIN
					    COMMIT TRANSACTION @TransName
					    RETURN 1 --SUCCESS
					END
       END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EntrySearch]    Script Date: 05/22/2007 01:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_EntrySearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_EntrySearch 
	(
	@SearchKey nvarchar(200)
	)
AS
BEGIN

SET NOCOUNT ON

SELECT Id,Title,Updated,ServiceType,Summary,
Published,Author,MediaType,article.Content as Content,media.Content as Content
FROM tbl_Entry as entry
left JOIN tbl_Article as article ON entry.Id=article.EntryId
left join tbl_Media as media ON entry.Id=media.EntryId
where (Title like ''%''+@SearchKey+''%'' 
OR Summary like ''%''+@SearchKey+''%'' 
Or article.Content like ''%''+@SearchKey+''%'')

	RETURN
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategories]    Script Date: 05/22/2007 01:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetCategories]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CReate PROCEDURE dbo.sp_GetCategories

AS

	
	Select * from tbl_Category
	

	RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategory]    Script Date: 05/22/2007 01:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_GetCategory

	(
	@CategoryId uniqueidentifier =null
	)

AS
	if(@categoryId=null)
	BEGIN
	
	Select * from tbl_Category
	
	END
	
	else
	Begin
	
	Select * from tbl_Category where CategoryId=@CategoryId
	
	End
	RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLabels]    Script Date: 05/22/2007 01:45:33 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetMostRecent]    Script Date: 05/22/2007 01:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetMostRecent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_GetMostRecent 
	
	(
	@DatePoint datetime,
	@ServiceType nvarchar(100),
	@PageIndex int=1,
	@PageSize int=10
	)
	
AS
	SELECT Id,Title,Updated,ServiceType,Summary,
Published,Author,MediaType,article.Content as Content,media.Content as Content
FROM tbl_Entry as entry
left JOIN tbl_Article as article ON entry.Id=article.EntryId
left join tbl_Media as media ON entry.Id=media.EntryId
where Published>@DatePoint and ServiceType=@ServiceType
	RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetQueryByLabel]    Script Date: 05/22/2007 01:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetQueryByLabel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_GetQueryByLabel
	(
	@LabelId UNIQUEIDENTIFIER
	)
AS

BEGIN

SELECT o.QueryId,ServiceType,QueryContent 
	FROM tbl_LabelQueryAssociation AS o
	INNER JOIN tbl_Query AS t ON o.QueryId=t.QueryId
	WHERE LabelId=@LabelId
	
	RETURN
END
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserByUserName]    Script Date: 05/22/2007 01:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetUserByUserName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_GetUserByUserName
	
	(
	@UserName nvarchar(128)
	)

AS
	SELECT membership.UserId, membership.UserName, Email, PasswordQuestion, Comment, IsApproved, IsLockedOut, 
	CreateDate, LastLoginDate, LastActivityDate, LastPasswordChangedDate, LastLockOutDate
	 FROM tbl_Membership as membership 
	 inner join tbl_User as users on membership.UserId= users.UserId 
	 WHERE membership.UserName = @UserName

	RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserNameByEmail]    Script Date: 05/22/2007 01:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetUserNameByEmail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_GetUserNameByEmail

	(
	@Email nvarchar(256)
	)

AS
	Select UserName From tbl_Membership Where Email=@Email
	
	RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertArticle]    Script Date: 05/22/2007 01:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertArticle]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.sp_InsertArticle
	(
	@Id uniqueidentifier,
	@Title nvarchar(100),
	@Summary nvarchar(200),
	@ServiceType nvarchar(100),
	@Author uniqueidentifier,
	@Content ntext,
	@MediaType nvarchar(50)
	)
AS

BEGIN
	DECLARE @TransName VARCHAR(20)
	SET @TransName = ''InsertArticleTransaction''

	BEGIN TRANSACTION @TransName;
		Insert Into tbl_Entry( Id, Title,Summary,ServiceType,Author,MediaType) values(
		@Id,@Title,@Summary,@ServiceType,@Author,@MediaType)
		
		IF (@@ERROR<>0)
			BEGIN
				ROLLBACK TRANSACTION @TransName
				Return -1 --Insert into entry error.
			END
		ELSE 
			BEGIN
				Insert Into tbl_Article (EntryId, Content) values(@Id,@Content)
			
				IF(@@ERROR<>0)
					BEGIN
						ROLLBACK TRANSACTION @TransName
						RETURN -2 --Insert into article error.
					END
				ELSE 
					BEGIN
					    COMMIT TRANSACTION @TransName
					    RETURN 1 --SUCCESS
					END
			END
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertMedia]    Script Date: 05/22/2007 01:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertMedia]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_InsertMedia
	(
	@Id uniqueidentifier,
	@Title nvarchar(100),
	@Summary nvarchar(200),
	@ServiceType nvarchar(100),
	@Author uniqueidentifier,
	@Content nvarchar(MAX),
	@MediaType nvarchar(50)
	)
AS

BEGIN
	DECLARE @TransName VARCHAR(20)
	SET @TransName = ''InsertMediaTransaction''

	BEGIN TRANSACTION @TransName;
		Insert Into tbl_Entry( Id, Title,Summary,ServiceType,Author,MediaType) values(
		@Id,@Title,@Summary,@ServiceType,@Author,@MediaType)
		
		IF (@@ERROR<>0)
			BEGIN
				ROLLBACK TRANSACTION @TransName
				Return -1 --Insert into entry error.
			END
		ELSE 
			BEGIN
				Insert Into tbl_Media (EntryId, Content) values(@Id,@Content)
			
				IF(@@ERROR<>0)
					BEGIN
						ROLLBACK TRANSACTION @TransName
						RETURN -2 --Insert into video error.
					END
				ELSE 
					BEGIN
					    COMMIT TRANSACTION @TransName
					    RETURN 1 --SUCCESS
					END
			END
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertQuery]    Script Date: 05/22/2007 01:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertQuery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_InsertQuery 
	(
	@QueryId uniqueidentifier,
	@ServiceType nvarchar(100),
	@QueryContent xml
	)
AS

BEGIN
	SET NOCOUNT ON
	
	INSERT INTO tbl_Query
	(
	    QueryId,ServiceType,QueryContent
	) values
	(
	@QueryId,@ServiceType,@QueryContent
	)
	
	RETURN
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_MediaSearch]    Script Date: 05/22/2007 01:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_MediaSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_MediaSearch
	(
	@SearchKey nvarchar(200)
	)
AS

BEGIN

SET NOCOUNT ON

SELECT Id,EntryId,Title,Updated,ServiceType,Summary,
Published,Author,MediaType,Content
FROM tbl_Entry as o
INNER JOIN tbl_Media as t ON o.Id=t.EntryId
where (Title like ''%''+@SearchKey+''%'' 
OR Summary like ''%''+@SearchKey+''%'' 
)

	RETURN
END
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveTempQuery]    Script Date: 05/22/2007 01:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SaveTempQuery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_SaveTempQuery 
	(
	@QueryId uniqueidentifier,
	@ServiceType nvarchar(100),
	@QueryContent xml
	)
AS

BEGIN
	SET NOCOUNT ON
	
	INSERT INTO tbl_TempQuery
	(
	    QueryId,ServiceType,QueryContent
	) values
	(
	@QueryId,@ServiceType,@QueryContent
	)
	
	RETURN
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllQuery]    Script Date: 05/22/2007 01:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectAllQuery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_SelectAllQuery 

AS

BEGIN
	SET NOCOUNT ON
	
	SELECT QueryId,ServiceType,QueryContent 
	FROM tbl_Query
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectEntry]    Script Date: 05/22/2007 01:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectEntry]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_SelectEntry

	(
	@EntryId uniqueidentifier
	)

AS
	/* SET NOCOUNT ON */ 
	SELECT Id,Title,Updated,ServiceType,Summary,
Published,Author,MediaType,article.Content as Content,media.Content as Content
 from tbl_Entry as entry
left JOIN tbl_Article as article ON entry.Id=article.EntryId
left join tbl_Media as media ON entry.Id=media.EntryId
WHERE entry.Id=@EntryId
	
	RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectEntryType]    Script Date: 05/22/2007 01:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectEntryType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.sp_SelectEntryType 

	(
	@EntryId uniqueidentifier
	)

AS
	/* SET NOCOUNT ON */ 
	
	Select ServiceType from tbl_Entry where Id=@EntryId
	
	RETURN
' 
END
GO
