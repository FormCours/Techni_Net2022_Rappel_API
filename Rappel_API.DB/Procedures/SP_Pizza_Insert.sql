CREATE PROCEDURE [dbo].[SP_Pizza_Insert]
	@Name NVARCHAR(50),
	@Price DECIMAL,
	@PizzaType NVARCHAR(50)
AS
BEGIN
	DECLARE @PizzaType_Id INT;
	SET @PizzaType_Id = (SELECT [Id] FROM [PizzaType] WHERE [Name] = @PizzaType);

	IF (@PizzaType_Id IS NOT NULL)
	 BEGIN
		RAISERROR ('Type de Pizza non connu :o', 16, 1);  
	 END;

	INSERT INTO [Pizza] ([Name], [PizzaType_Id], [Price])
	 OUTPUT [inserted].[id]
	 VALUES (@Name, @PizzaType_Id, @Price)
END;
