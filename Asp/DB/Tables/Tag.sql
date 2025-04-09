CREATE TABLE [dbo].[Tag]
(
	[Tag_Id] nvarchar(150) NOT NULL,
	Constraint Fk_Tag_Id Primary Key([Tag_Id]),
	Constraint Uk_Tag_Id Unique ([Tag_Id])
)
