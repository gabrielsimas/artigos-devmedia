/*
SCRIPT DE CRIAÇÃO DE BASE DE DADOS
DO ARTIGO Seguranças em Aplicações ASP.NET
Edição: 112
AUTOR: Luís Gabriel Nascimento Simas
DATA: 20/01/2014 - Feriado de São Sebastião, Padroeiro da Cidade do Rio de Janeiro
*/
-- CRIAÇÃO DO BANCO DE DADOS
CREATE DATABASE MVCSeguranca112
GO

USE MVCSeguranca112
GO

-- TABELA Contato
CREATE TABLE Contato(
	id				INT IDENTITY,
	nomeCompleto	VARCHAR(100) NOT NULL,
	apelido			VARCHAR(100) NOT NULL
)
GO

ALTER TABLE Contato ADD CONSTRAINT PK_Contato PRIMARY KEY(id)
GO

-- TABELA E-mail
CREATE TABLE Email(
	id			INT IDENTITY,
	idContato	INT,
	endereco	VARCHAR(100)
)
GO

ALTER TABLE Email ADD CONSTRAINT PK_Email PRIMARY KEY(id)
ALTER TABLE Email ADD CONSTRAINT FK_Email_Contato_id FOREIGN KEY(idContato)
	REFERENCES Contato(id)
GO

-- Tabela Rede Social
CREATE TABLE RedeSocial(
	id				INT IDENTITY,
	idContato		INT,
	urlPerfil		VARCHAR(100) NOT NULL,
	nomeRedeSocial	VARCHAR(100) NOT NULL
)
GO

ALTER TABLE RedeSocial ADD CONSTRAINT PK_RedeSocial PRIMARY KEY(id)
ALTER TABLE RedeSocial ADD CONSTRAINT FK_RedeSocial_Contato_id FOREIGN KEY(idContato)
	REFERENCES Contato(id)
GO

-- Tabela Telefone
CREATE TABLE Telefone(
	id			INT IDENTITY,
	idContato	INT,
	ddd			INT	NOT NULL,
	ddi			INT NOT NULL,
	numero		INT NOT NULL,
	tipoTelefne	INT	NOT NULL
)
GO

ALTER TABLE Telefone ADD CONSTRAINT PK_Telefone PRIMARY KEY(id)
ALTER TABLE Telefone ADD CONSTRAINT FK_Telefone_Contato FOREIGN KEY(idContato)
	REFERENCES Contato(id)
GO

use MVCSEGURANCA112
GO

-- # CONTROLE DE USUÁRIOS
CREATE TABLE Usuario(
	id		INT IDENTITY,
	idResponsabilidade	INT,
	nome	VARCHAR(30) NOT NULL,
	email	VARCHAR(30) NOT NULL,
	conta	VARCHAR(30) NOT NULL,
	senha	VARCHAR(100) NOT NULL,
	salt	VARCHAR(100) NOT NULL,
	estado	VARCHAR(1)
)
GO

ALTER TABLE Usuario ADD CONSTRAINT PK_Usuario PRIMARY KEY(id)
GO
ALTER TABLE Usuario ADD CONSTRAINT FK_ResponsaUsuario FOREIGN KEY(idResponsabilidade) 
	REFERENCES Responsabilidade(id)
GO

--# CONTROLE DE PAPÉIS
CREATE TABLE Responsabilidade(
	id		INT IDENTITY,
	nome	VARCHAR(100),
	estado	VARCHAR(1)
)
GO

ALTER TABLE Responsabilidade ADD CONSTRAINT PK_Responsabilidade PRIMARY KEY(id)
GO



