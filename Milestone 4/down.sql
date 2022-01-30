ALTER TABLE [UserMedia] DROP CONSTRAINT [Fk_UserMedia_User_ID];
ALTER TABLE [UserMedia] DROP CONSTRAINT [Fk_UserMedia_Media_ID];

DROP TABLE [User];
DROP TABLE [Media];
DROP TABLE [UserMedia];