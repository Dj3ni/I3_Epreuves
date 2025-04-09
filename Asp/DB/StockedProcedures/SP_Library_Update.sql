CREATE PROCEDURE [dbo].[SP_Library_Update]
	@game_copy_id int,
	@state nvarchar(50)

AS
Begin

Update [Library]
		SET 
		[State] = @state

		Where [Game_Copy_Id] = @game_copy_id

End
