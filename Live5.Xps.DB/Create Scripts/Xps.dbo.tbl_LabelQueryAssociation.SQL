/****** Object:  Table [dbo].[tbl_LabelQueryAssociation]    Script Date: 01/28/2007 15:15:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_LabelQueryAssociation]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_LabelQueryAssociation]
GO
/****** Object:  Table [dbo].[tbl_LabelQueryAssociation]    Script Date: 01/28/2007 15:15:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_LabelQueryAssociation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_LabelQueryAssociation](
	[LabelId] [uniqueidentifier] NOT NULL,
	[QueryId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_tbl_LabelQueryAssociation_CreateDate]  DEFAULT (getdate())
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
