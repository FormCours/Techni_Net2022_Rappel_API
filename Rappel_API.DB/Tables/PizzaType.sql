CREATE TABLE [dbo].[PizzaType]
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_PizzaType] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_PizzaType_Name] UNIQUE ([Name])
);
