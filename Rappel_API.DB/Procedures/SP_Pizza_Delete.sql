CREATE PROCEDURE [dbo].[SP_Pizza_Delete]
	@Pizza_Id int
AS
BEGIN
	DELETE FROM [Pizza]
	WHERE [Id] = @Pizza_Id;
END