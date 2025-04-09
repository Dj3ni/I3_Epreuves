CREATE TABLE [dbo].[User]
(
	[User_Id] UNIQUEIDENTIFIER NOT NULL  DEFAULT NEWID(),
	[Email] nvarchar(320) NOT NULL,
	[Password] varbinary(150) NOT NULL,
	[Pseudo] nvarchar(150) NOT NULL,
	[Subscription_Date] dateTime NOT NULL default GetDate(),
	[Deactivation_Date] dateTime Null,
	[Salt] UNIQUEIDENTIFIER NOT NULL,
	Constraint Pk_User_Id Primary Key([User_Id]),
	Constraint Uk_Mail_Unique Unique([Email])
)
