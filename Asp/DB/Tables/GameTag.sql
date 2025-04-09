CREATE TABLE [dbo].[GameTag]
(
	[Tag_Id] nvarchar(150) NOT NULL,
	[Game_Id] Int Not null,
	Constraint PK_Game_Tag Primary Key ([Tag_Id],[Game_Id]),
	Constraint [FK_Tag] Foreign key ([Tag_Id]) References [Tag]([Tag_Id]) On Delete Cascade,
	Constraint [FK_Game] Foreign key ([Game_Id]) References [Boardgame]([Game_Id]) On delete Cascade
)
