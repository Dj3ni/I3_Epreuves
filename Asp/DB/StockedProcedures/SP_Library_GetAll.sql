CREATE PROCEDURE [dbo].[SP_Library_GetAll]

AS
Begin
	Select
		[Game_Copy_Id],
		[State],
		[Game_Id],
		[User_Id]

	From [Library]

End
