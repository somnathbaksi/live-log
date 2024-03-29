/****** Object:  Table [dbo].[tbl_Category]    Script Date: 12/09/2006 21:36:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Category]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Category]
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 12/09/2006 21:36:09 ******/
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
