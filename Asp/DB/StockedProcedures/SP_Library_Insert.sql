CREATE PROCEDURE [dbo].[SP_Library_Insert]
	@state nvarchar(50),
	@user_id uniqueidentifier,
	@game_id int
AS
Begin

Insert into [Library]
				([State],[Game_Id],[User_Id])

		Output [inserted].[Game_Copy_Id]
		Values (@state, @game_id, @user_id)

End
