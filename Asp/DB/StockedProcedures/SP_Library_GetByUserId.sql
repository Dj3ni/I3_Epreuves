CREATE PROCEDURE [dbo].[SP_Library_GetByUserId]
	@user_id uniqueidentifier
AS
Begin
	Select
	[Game_Copy_Id],
	[State],
	[Game_Id],
	[User_Id]

	FROM [Library]

	Where [User_Id] = @user_id
End
