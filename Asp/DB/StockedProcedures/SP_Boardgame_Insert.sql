CREATE PROCEDURE [dbo].[SP_Boardgame_Insert]
	@game_title nvarchar(200),
	@description nvarchar(MAX),
	@minAge int,
	@maxAge int,
	@minPlayers int,
	@maxPlayers int,
	@duration int null,
	@registerer uniqueidentifier
AS
BEGIN
	Declare @registration_date datetime;
	Set @registration_date = getDate();

	Insert Into [Boardgame]
		([Game_Title],
		[Description],
		[MinAge],
		[MaxAge],
		[MinPlayers],
		[MaxPlayers],
		[Duration],
		[Registration_Date],
		[Registerer])

	Output [Inserted].[Game_Id]

	Values
		(@game_title,
		@description,
		@minAge,
		@maxAge,
		@minPlayers,
		@maxPlayers,
		@duration,
		@registration_date,
		@registerer)
END
