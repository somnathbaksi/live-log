/****** Object:  Table [dbo].[tbl_Users]    Script Date: 01/28/2007 14:34:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_User]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_User]
GO
/****** Object:  Table [dbo].[tbl_Users]    Script Date: 01/28/2007 14:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_User](
	[UserId] [uniqueidentifier] NULL,
	[UserName] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
