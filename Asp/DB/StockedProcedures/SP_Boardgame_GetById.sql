CREATE PROCEDURE [dbo].[SP_Boardgame_GetById]
	@game_id int
AS
Begin
	Select
		[Game_Id],
		[Game_Title],
		[Description],
		[MinAge],
		[MaxAge],
		[MinPlayers],
		[MaxPlayers],
		[Duration],
		[Registerer],
		[Registration_Date]

	FROM [Boardgame]

	Where [Game_Id] = @game_id

End
