CREATE TABLE [User] (
    [ID] int PRIMARY KEY IDENTITY(1,1),
    [Username] nvarchar(30) NOT NULL
);

CREATE TABLE [Media] (
    [ID] int PRIMARY KEY,
    [Title] nvarchar(50) NOT NULL
);

CREATE TABLE [UserMedia] (
    [ID] int PRIMARY KEY,
    [BlockageLevel] int NOT NULL,
    [UserID] int NOT NULL,
    [MediaID] int NOT NULL
);

ALTER TABLE [UserMedia] ADD CONSTRAINT [Fk_UserMedia_User_ID]
    FOREIGN KEY ([UserID]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [UserMedia] ADD CONSTRAINT [Fk_UserMedia_Media_ID]
    FOREIGN KEY ([MediaID]) REFERENCES [Media] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;