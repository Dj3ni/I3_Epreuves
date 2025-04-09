CREATE PROCEDURE [dbo].[SP_Lending_Insert]
	@game_copy_id int,
	@owner_id uniqueidentifier,
	@borrower_id uniqueidentifier,
	@lending_date datetime
AS
Begin

	Insert into [Lending]
			([Game_Copy_Id],
			[Lending_Date],
			[Owner_Id],
			[Borrower_Id])
	
	Output [inserted].[Lending_Id]

	Values (@game_copy_id,
			@lending_date,
			@owner_id,
			@borrower_id)
End
