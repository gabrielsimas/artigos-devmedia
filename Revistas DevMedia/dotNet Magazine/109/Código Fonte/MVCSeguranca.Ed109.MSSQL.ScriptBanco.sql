/*SCRIPT DE BANCO DE DADOS DO ARTIGO LINQ TO SQL DA EASY .NET MAGAZINE EDIÇÃO 31 - Julho 2013
Autor: Luís Gabriel N. Simas
Data/Hora Início: 06/07/2013 - 23:00
Data/Hora Término: 07/07/2013 - 04:30
*/
/*Criação e uso do Banco de Dados*/
CREATE DATABASE MVCSeguranca
GO

USE MVCSeguranca
GO

/* Criação das Tabelas */
CREATE TABLE Usuario(
	Id			INT	IDENTITY,
	IdPerfil	INT,
	IdCliente	INT,
	Login		VARCHAR(200) NOT NULL,
	Senha		VARCHAR(20) NOT NULL,
)
GO

ALTER TABLE Usuario ADD CONSTRAINT PK_Usuario PRIMARY KEY(Id)
ALTER TABLE Usuario ADD CONSTRAINT FK_USUARIO_PERFIL FOREIGN KEY(IdPerfil) REFERENCES Perfil(Id)
ALTER TABLE Usuario ADD CONSTRAINT FK_USUARIO_CLIENTE FOREIGN KEY(IdCliente) REFERENCES Cliente(Id)
GO

ALTER TABLE Usuario ADD MD5 VARCHAR(40)
ALTER TABLE Usuario ADD PBKDF2 VARCHAR(40)

ALTER TABLE Usuario ADD SenhaCrypto VARCHAR(100)
GO

ALTER TABLE Usuario ADD Algoritmo VARCHAR(100)
GO

ALTER TABLE Usuario ALTER COLUMN PBKDF2 VARCHAR(100)
GO

ALTER TABLE Usuario DROP COLUMN MD5
GO

ALTER TABLE Usuario DROP COLUMN PBKDF2
GO

SELECT * FROM Usuario
GO

DROP TABLE Usuario
GO

CREATE TABLE Perfil(
	Id		INT IDENTITY,
	Nome	VARCHAR(200) NOT NULL
)
GO

ALTER TABLE Perfil ADD CONSTRAINT PK_Perfil PRIMARY KEY(Id)
GO

CREATE TABLE Cliente(
	Id		INT IDENTITY,
	Nome	VARCHAR(200),
	Email	VARCHAR(200)
)
GO

ALTER TABLE Cliente ADD CONSTRAINT PK_Cliente PRIMARY KEY(Id)
GO

CREATE TABLE Compras( 
	Id	INT IDENTITY,
	IdCliente INT,
	Total FLOAT
)
GO

ALTER TABLE Compras ADD CONSTRAINT PK_Compras PRIMARY KEY(Id)
ALTER TABLE Compras ADD CONSTRAINT FK_Compras_Cliente FOREIGN KEY(IdCliente) REFERENCES Cliente(Id)
GO

USE MVCSeguranca
GO

SELECT * FROM Cliente
GO

DELETE FROM Cliente
GO

/*Criação da Base de Teste*/
CREATE DATABASE MVCSegurancaDSV
GO

USE MVCSegurancaDSV
GO

SELECT cliente0_.Id as Id1_1_, cliente0_.Nome as Nome1_1_, cliente0_. Email as column3_1_1_, compras1_.Id as Id3_, compras1_.Id as Id0_0_, compras1_.Total as Total0_0_, compras1_.IdCliente as IdCliente0_0_ FROM Cliente cliente0_ left outer join Compras compras1_ on cliente0_.Id=compras1_.Id WHERE cliente0_.Id=10

INSERT INTO Cliente
VALUES
('Jane Simas','janesimas@gmail.com')

INSERT INTO Cliente
VALUES
('Lívia Helena Barcia Simas','liviasimas@gmail.com')

INSERT INTO Cliente
VALUES
('Carlos Alexandre Magno Barcia Simas','carlosambsimas@gmail.com')
GO

SELECT * FROM Cliente
GO


SELECT * FROM Compras
GO

INSERT INTO Compras 
VALUES
(10,15000)
GO

INSERT INTO Compras
VALUES
(35,1000)

INSERT INTO Compras
VALUES
(35,500)

INSERT INTO Compras
VALUES
(35,10)

INSERT INTO Compras
VALUES
(35,500)

INSERT INTO Compras
VALUES
(36,500)

INSERT INTO Compras
VALUES
(36,10)

INSERT INTO Compras
VALUES
(36,500)

INSERT INTO Compras
VALUES
(37,500)

INSERT INTO Compras
VALUES
(37,10)

INSERT INTO Compras
VALUES
(37,500)
GO

SELECT * FROM 
Compras

INSERT INTO Perfil
VALUES ('Usuário')

INSERT INTO Perfil
VALUES ('Administrador')

INSERT INTO Perfil
VALUES ('Moderador')

INSERT INTO Perfil
VALUES ('Criador')
GO

SELECT * FROM Perfil
GO

INSERT INTO 

/*EXTRAÇÕES*/

/*CLIENTE
Id	Nome								Email
10	Luís Gabriel Nascimento Simas		gabrielsimas@gmail.com
35	Jane Simas							janesimas@gmail.com
36	Lívia Helena Barcia Simas			liviasimas@gmail.com
37	Carlos Alexandre Magno Barcia Simas	carlosambsimas@gmail.com
*/

/*COMPRAS
Id	IdCliente	Total
2	10			15000
3	35			1000
4	35			500
5	35			10
6	35			500
7	36			500
8	36			10
9	36			500
10	37			500
11	37			10
12	37			500
*/

/*PERFIL
Id	Nome
1	Usuário
2	Administrador
3	Moderador
4	Criador
*/
SELECT * FROM Usuario
GO

INSERT INTO Usuario
VALUES
(1,10,'gabrielsimas','J4n3c4554n1')

INSERT INTO Usuario
VALUES
(1,35,'janesimas','J4n3c4554n1')

INSERT INTO Usuario
VALUES
(1,36,'liviahsimas','J4n3c4554n1')

INSERT INTO Usuario
VALUES
(1,37,'camagnosimas','J4n3c4554n1')
GO

UPDATE Usuario
SET Senha = HashBytes('SHA2','J4n3c4554n1')
WHERE Id = 1

SELECT Senha, HashBytes('MD5',Senha) MD5, HashBytes('SHA1',Senha) SHA1
FROM Usuario

SELECT HashBytes('MD5',Senha),* FROM Usuario
WHERE HashBytes('MD5',Senha) = Hashbytes('MD5','J4n3c4554n1')

UPDATE Usuario
SET PBKDF2='1000:6hbjktsdWMq18YRmVpjpUC4IYjtE8CEc:097I8/jiLIbAaDaHhD4C/SVC6QwxFfPb'
WHERE Senha='J4n3c4554n1'

SELECT LEN('1000:6hbjktsdWMq18YRmVpjpUC4IYjtE8CEc:097I8/jiLIbAaDaHhD4C/SVC6QwxFfPb')

UPDATE Usuario
SET MD5 = '0x544CFB03D86A18828546DD48E17A4BDC'
WHERE Senha = 'J4n3c4554n1'

SELECT * FROM Usuario
GO