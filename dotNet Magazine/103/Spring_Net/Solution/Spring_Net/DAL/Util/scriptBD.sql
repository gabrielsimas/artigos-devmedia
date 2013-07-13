USE master
GO

CREATE TABLE contato(
	id int IDENTITY(1,1) NOT NULL,
	NomeCompleto nvarchar(100) NOT NULL,
	Email nvarchar(100) NULL,
	linkedin nvarchar(100) NULL,
	twitter nvarchar(100) NULL,
	facebook nvarchar(100) NULL)
 
GO

ALTER TABLE contato ADD CONSTRAINT PK_contato PRIMARY KEY(id)
GO