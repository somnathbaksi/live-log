/****** Object:  Table [dbo].[tbl_Query]    Script Date: 01/28/2007 16:56:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Query]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Query]
GO
/****** Object:  Table [dbo].[tbl_Query]    Script Date: 01/28/2007 16:56:21 ******/
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
