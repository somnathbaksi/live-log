/****** Object:  Table [dbo].[tbl_Label]    Script Date: 01/28/2007 15:15:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Label]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Label]
GO
/****** Object:  Table [dbo].[tbl_Label]    Script Date: 01/28/2007 15:15:20 ******/
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
