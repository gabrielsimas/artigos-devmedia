﻿CREATE TABLE Pessoa(

	id			int	IDENTITY,
	nome		VARCHAR(100) NOT NULL,
	sobrenome	VARCHAR(100) NOT NULL,
	email		VARCHAR(100) NOT NULL
)

ALTER TABLE Pessoa ADD CONSTRAINT PK_Pessoa PRIMARY KEY(id)
GO

SELECT * FROM Pessoa
GO