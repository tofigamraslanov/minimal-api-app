IF NOT EXISTS (SELECT 1 FROM [dbo].[User])
BEGIN
	INSERT INTO [dbo].[User] (FirstName, LastName)
	VALUES ('Tofig', 'Amraslanov'),
	('Ulvi', 'Aliyev'),
	('Ravi', 'Valiyev'),
	('Raul', 'Vugarov');
END