CREATE PROCEDURE [dbo].[SP_Lending_Update]
	@lending_id int,
	@return_date datetime null,
	@owner_note tinyint null,
	@borrower_note tinyint null
AS
Begin
	Update [Lending]
		Set [Return_Date] = @return_date,
			[Owner_Note] = @owner_note,
			[Borrower_Note] = Borrower_Note
		Where [Lending_Id] = @lending_id
End
