/****** Object:  Table [dbo].[tbl_Query]    Script Date: 12/09/2006 21:36:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_TempQuery]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_TempQuery]
GO
/****** Object:  Table [dbo].[tbl_Query]    Script Date: 12/09/2006 21:36:49 ******/
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
