/****** Object:  Table [dbo].[tbl_Entry]    Script Date: 11/18/2006 15:46:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Entry]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Entry]
GO
/****** Object:  Table [dbo].[tbl_Entry]    Script Date: 11/18/2006 15:46:52 ******/
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
 CONSTRAINT [PK_tbl_Entry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Index [IX_tbl_Entry_1]    Script Date: 11/18/2006 15:46:52 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Entry]') AND name = N'IX_tbl_Entry_1')
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_Entry_1] ON [dbo].[tbl_Entry] 
(
	[Published] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
