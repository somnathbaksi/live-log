IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_LabelQueryAssociation_tbl_Label]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_LabelQueryAssociation]'))
ALTER TABLE [dbo].[tbl_LabelQueryAssociation] DROP CONSTRAINT [FK_tbl_LabelQueryAssociation_tbl_Label]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_LabelQueryAssociation_tbl_Query]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_LabelQueryAssociation]'))
ALTER TABLE [dbo].[tbl_LabelQueryAssociation] DROP CONSTRAINT [FK_tbl_LabelQueryAssociation_tbl_Query]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Media_tbl_Entry]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Media]'))
ALTER TABLE [dbo].[tbl_Media] DROP CONSTRAINT [FK_tbl_Media_tbl_Entry]
GO
/****** Object:  Table [dbo].[tbl_Article]    Script Date: 05/22/2007 01:45:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Article]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Article]
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 05/22/2007 01:45:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_User]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_User]
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 05/22/2007 01:45:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Category]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Category]
GO
/****** Object:  Table [dbo].[tbl_Entry]    Script Date: 05/22/2007 01:45:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Entry]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Entry]
GO
/****** Object:  Table [dbo].[tbl_Label]    Script Date: 05/22/2007 01:45:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Label]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Label]
GO
/****** Object:  Table [dbo].[tbl_LabelQueryAssociation]    Script Date: 05/22/2007 01:45:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_LabelQueryAssociation]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_LabelQueryAssociation]
GO
/****** Object:  Table [dbo].[tbl_Media]    Script Date: 05/22/2007 01:45:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Media]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Media]
GO
/****** Object:  Table [dbo].[tbl_Membership]    Script Date: 05/22/2007 01:45:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Membership]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Membership]
GO
/****** Object:  Table [dbo].[tbl_Query]    Script Date: 05/22/2007 01:45:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Query]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Query]
GO
/****** Object:  Table [dbo].[tbl_Statistic]    Script Date: 05/22/2007 01:45:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Statistic]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Statistic]
GO
/****** Object:  Table [dbo].[tbl_TempQuery]    Script Date: 05/22/2007 01:45:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_TempQuery]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_TempQuery]
GO
/****** Object:  Table [dbo].[tbl_Article]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Article]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Article](
	[EntryId] [uniqueidentifier] NOT NULL,
	[Content] [ntext] NOT NULL,
 CONSTRAINT [PK_tbl_Article] PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_User](
	[UserId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_tbl_User_UserId]  DEFAULT (newid()),
	[UserName] [nvarchar](256) NULL,
	[IsAnonymous] [bit] NULL,
	[LastActivityDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Category](
	[CategoryId] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_tbl_Category_CategoryId]  DEFAULT (newid()),
	[CategoryName] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[GroupId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_tbl_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Entry]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Entry]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Entry](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Updated] [datetime] NULL,
	[ServiceType] [nvarchar](100) NULL,
	[Summary] [nvarchar](200) NULL,
	[Published] [datetime] NOT NULL CONSTRAINT [DF_tbl_Entry_Published]  DEFAULT (getdate()),
	[Author] [uniqueidentifier] NULL,
	[MediaType] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Entry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Index [IX_tbl_Entry_1]    Script Date: 05/22/2007 01:45:17 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Entry]') AND name = N'IX_tbl_Entry_1')
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_Entry_1] ON [dbo].[tbl_Entry] 
(
	[Published] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Label]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Label]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Label](
	[LabelId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_tbl_Label_LabelId]  DEFAULT (newid()),
	[LabelName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Owner] [uniqueidentifier] NULL,
	[Type] [uniqueidentifier] NULL,
 CONSTRAINT [PK_tbl_Label] PRIMARY KEY CLUSTERED 
(
	[LabelId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_LabelQueryAssociation]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_LabelQueryAssociation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_LabelQueryAssociation](
	[LabelId] [uniqueidentifier] NOT NULL,
	[QueryId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_tbl_LabelQueryAssociation_CreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbl_LabelQueryAssociation] PRIMARY KEY CLUSTERED 
(
	[LabelId] ASC,
	[QueryId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Media]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Media]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Media](
	[EntryId] [uniqueidentifier] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Media] PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Membership]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Membership]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Membership](
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL CONSTRAINT [DF__tbl_Membe__Passw__2D27B809]  DEFAULT ((0)),
	[PasswordSalt] [nvarchar](128) NULL,
	[MobilePIN] [nvarchar](16) NULL,
	[Email] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NULL CONSTRAINT [DF_tbl_Membership_LastLoginDate]  DEFAULT (getdate()),
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NULL,
	[Comment] [ntext] NULL,
	[UserName] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK__tbl_Membership__2B3F6F97] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Query]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Query]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Query](
	[QueryId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[ServiceType] [nvarchar](100) NULL,
	[QueryContent] [xml] NULL,
 CONSTRAINT [tbl_Query_PK] PRIMARY KEY NONCLUSTERED 
(
	[QueryId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Statistic]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Statistic]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Statistic](
	[Viewed] [int] NULL,
	[RatedTimes] [int] NULL,
	[Favorited] [int] NULL,
	[EntryId] [uniqueidentifier] NOT NULL,
	[Discussed] [int] NULL,
	[Linked] [int] NULL,
	[Rate] [int] NULL,
	[AverageRate]  AS ([Rate]/([RatedTimes]*(5))),
 CONSTRAINT [PK_tbl_Statistic] PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_TempQuery]    Script Date: 05/22/2007 01:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_TempQuery]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_TempQuery](
	[QueryId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[ServiceType] [nvarchar](100) NULL,
	[QueryContent] [xml] NULL,
 CONSTRAINT [tbl_TempQuery_PK] PRIMARY KEY NONCLUSTERED 
(
	[QueryId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_LabelQueryAssociation_tbl_Label]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_LabelQueryAssociation]'))
ALTER TABLE [dbo].[tbl_LabelQueryAssociation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_LabelQueryAssociation_tbl_Label] FOREIGN KEY([LabelId])
REFERENCES [dbo].[tbl_Label] ([LabelId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_LabelQueryAssociation_tbl_Query]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_LabelQueryAssociation]'))
ALTER TABLE [dbo].[tbl_LabelQueryAssociation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_LabelQueryAssociation_tbl_Query] FOREIGN KEY([QueryId])
REFERENCES [dbo].[tbl_Query] ([QueryId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Media_tbl_Entry]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Media]'))
ALTER TABLE [dbo].[tbl_Media]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Media_tbl_Entry] FOREIGN KEY([EntryId])
REFERENCES [dbo].[tbl_Entry] ([Id])
GO
