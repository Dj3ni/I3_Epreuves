CREATE PROCEDURE [dbo].[SP_Boardgame_GetAll]
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

End
