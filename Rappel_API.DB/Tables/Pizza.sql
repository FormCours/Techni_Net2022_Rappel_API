CREATE TABLE [dbo].[Pizza]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[PizzaType_Id] INT NOT NULL,
	[Price] DECIMAL NOT NULL,

	CONSTRAINT [PK_Pizza] PRIMARY KEY([Id]),
	CONSTRAINT [CK_Pizza__Price] CHECK ([Price] > 0),
	CONSTRAINT [UK_Pizza__Name] UNIQUE([Name]),

	CONSTRAINT [FK_Pizza_PizzaType] 
		FOREIGN KEY([PizzaType_Id]) 
		REFERENCES [PizzaType]([Id])
)
