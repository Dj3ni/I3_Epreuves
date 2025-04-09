CREATE PROCEDURE [dbo].[SP_Library_GetById]
	@game_copy_id int
AS
Begin
	Select
		[Game_Copy_Id],
		[State],
		[Game_Id],
		[User_Id]

	From [Library]

	Where [Game_Copy_Id] = @game_copy_id

End
