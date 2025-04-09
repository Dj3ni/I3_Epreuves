CREATE PROCEDURE [dbo].[SP_User_Insert]
	@email NVARCHAR(320),
	@pseudo Nvarchar(150),
	--@subscription_date dateTime null ,
	@password Nvarchar(150)
AS
BEGIN
	DECLARE @salt UNIQUEIDENTIFIER
	Declare @subscription_date DateTime
	SET @salt = NEWID()
	Set @subscription_date = getDate()
	INSERT INTO [User] ([Email],[Pseudo],[Subscription_Date],[Password],[Salt])
	OUTPUT [inserted].[User_Id]
	VALUES (@email,@pseudo,@subscription_date,[dbo].[SF_SaltAndHash](@password, @salt), @salt)
END
