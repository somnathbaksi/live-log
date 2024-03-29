/****** Object:  Table [dbo].[tbl_Article]    Script Date: 11/15/2006 17:56:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Article]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Article]
GO
/****** Object:  Table [dbo].[tbl_Article]    Script Date: 11/15/2006 17:56:04 ******/
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
