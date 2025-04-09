CREATE TABLE [dbo].[Boardgame]
(
	[Game_Id] INT NOT NULL Identity(1,1),
	[Game_Title] nvarchar(200) Not Null,
	[Description] nvarchar(Max) Not Null,
	[MinAge] Int Not Null,
	[MaxAge] int Not null,
	[MinPlayers] int NOT NULL,
	[MaxPlayers] int Not Null,
	[Duration] int null,
	[Registration_Date] datetime not null Default GetDate(),
	[Registerer] UniqueIdentifier not null
	Constraint PK_Game_Id Primary Key([Game_Id]),
	Constraint Uk_Title Unique([Game_Title]),
	Constraint Ck_Age_Values Check([MinAge] <= [MaxAge]),
	Constraint Ck_Nbr_Players Check([MinPlayers] <= [MaxPlayers]),
	Constraint FK_User_Register Foreign Key([Registerer]) references [User]([User_Id])
)
