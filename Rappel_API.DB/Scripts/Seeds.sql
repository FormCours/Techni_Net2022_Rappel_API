
-- Pizza Type
INSERT INTO [PizzaType]([Id], [Name])
 VALUES (1, 'Base Tomate'),
		(2, 'Base Crème'),
		(3, 'Calzone');


-- Pizza
INSERT INTO [Pizza]([Name], [PizzaType_Id], [Price])
 VALUES ('Margherita', 1, 6.95),
		('Regina', 1, 8.13),
		('Pizza quatre fromages', 1, 7.50),
		('Pizza au fruit de mer', 2, 9.95);