CREATE PROCEDURE [dbo].[SP_Tag_Insert]
	@tag_id nvarchar(150)
AS
Begin
	Insert into [Tag]
		(Tag_Id) Values (@tag_id)
End
