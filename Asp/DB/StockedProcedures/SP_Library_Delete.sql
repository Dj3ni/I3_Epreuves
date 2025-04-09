CREATE PROCEDURE [dbo].[SP_Library_Delete]
	@game_copy_id int
AS
Begin
	Delete from [Library]
	Where [Game_Copy_Id] = @game_copy_id
End
