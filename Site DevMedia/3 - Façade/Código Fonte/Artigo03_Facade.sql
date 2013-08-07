/*
SCRIPT DE BANCO DE DADOS 
PARA O ARTIGO 03 - FAÇADE
*/

/*Criação do Banco de Dados*/
CREATE DATABASE Artigo03Facade
GO

USE Artigo03Facade
GO

/*Tabela Posição*/
CREATE TABLE Posicao(
	id		INT IDENTITY,
	nome	VARCHAR(100)
)

ALTER TABLE Posicao ADD CONSTRAINT PK_POSICAO PRIMARY KEY(id)
GO

CREATE TABLE Clube(
	id				INT IDENTITY,
	nomecompleto	VARCHAR(100),
	apelido			VARCHAR(100),
	datafundacao	DATE
)

ALTER TABLE Clube ADD distintivo VARCHAR(100)
ALTER TABLE Clube ADD cidade VARCHAR(100)
ALTER TABLE Clube ADD estado VARCHAR(100)
GO

ALTER TABLE Clube ADD CONSTRAINT PK_CLUBE PRIMARY KEY(id)
GO

CREATE TABLE Jogador(
	id				INT IDENTITY,
	idClube			INT,
	idPosicao		INT,
	nomecompleto	VARCHAR(100),
	apelido			VARCHAR(100),
	datanascimento	DATE,
	estadonatal		VARCHAR(100),
	paisnatal		VARCHAR(100),	
)

ALTER TABLE Jogador ADD idConf INT
GO

ALTER TABLE Jogador ADD CONSTRAINT PK_JOGADOR PRIMARY KEY(id)
ALTER TABLE Jogador ADD CONSTRAINT FK_JOGADOR_CLUBE	FOREIGN KEY(idClube) REFERENCES Clube(id)
ALTER TABLE Jogador ADD CONSTRAINT FK_JOGADOR_POSICAO FOREIGN KEY(idPosicao) REFERENCES Posicao(id)
GO

SELECT * FROM Clube
GO

SELECT * FROM Posicao
GO

SELECT * FROM Jogador
GO

DELETE FROM Jogador
WHERE id >= 5
GO

SELECT * FROM Jogador
WHERE idClube = 1