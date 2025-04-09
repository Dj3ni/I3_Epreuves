CREATE PROCEDURE [dbo].[SP_Library_GetByGameId]
	@game_id int
AS
Begin
	Select
	[Game_Copy_Id],
	[State]
	[user_id]

	FROM [Library]

	Where [Game_Id] = @game_id

End
