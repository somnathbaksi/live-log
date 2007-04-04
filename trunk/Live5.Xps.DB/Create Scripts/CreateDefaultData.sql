
/*Create a built in system user*/
DECLARE @SYSTEM_USER_ID UNIQUEIDENTIFIER

SET @SYSTEM_USER_ID=NEWID()

INSERT INTO tbl_User (UserId,UserName) values (@SYSTEM_USER_ID,N'System')

/* Create Default Menu Label */
INSERT INTO tbl_Label (LabelName,Description,Owner) values(N'DefaultMenuQuery',N'',@SYSTEM_USER_ID)


