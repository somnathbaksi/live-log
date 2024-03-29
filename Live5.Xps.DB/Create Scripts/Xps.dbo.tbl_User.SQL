/****** Object:  Table [dbo].[tbl_User]    Script Date: 01/28/2007 15:15:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_User]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_User]
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 01/28/2007 15:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_User](
	[UserId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_tbl_User_UserId]  DEFAULT (newid()),
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
