CREATE PROCEDURE [dbo].[SP_User_GetAllActive]

AS
BEGIN
	Select 
		[User_Id],
		[Pseudo],
		[Email],
		[Password],
		[Deactivation_Date]

	FROM [User]
	Where [Deactivation_Date] is null
END
