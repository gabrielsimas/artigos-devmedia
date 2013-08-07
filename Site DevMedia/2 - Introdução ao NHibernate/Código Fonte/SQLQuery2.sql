CREATE DATABASE RevistaArtigo02
GO

CREATE TABLE Carro(
	id	INT	IDENTITY,
	Modelo	VARCHAR(100) NOT NULL,
	Motor	VARCHAR(100) NOT NULL
)

ALTER TABLE Carro ADD CONSTRAINT PK_Carro PRIMARY KEY(id)
GO

INSERT INTO Carro(Modelo, Motor) 
VALUES
('J2','Motor de 4 Cilindros em Linha')

INSERT INTO Carro(Modelo, Motor) 
VALUES
('J3','Motor de 4 Cilindros em Linha')

INSERT INTO Carro(Modelo, Motor) 
VALUES
('Gol Track 1.6','Motor 1.6 | VHT')

INSERT INTO Carro(Modelo, Motor) 
VALUES
('Voyage Sedan 1.0','Motor 1.0 TEC')

INSERT INTO Carro(Modelo, Motor) 
VALUES
('Fusca','Motor 1.4')

INSERT INTO Carro(Modelo, Motor) 
VALUES
('Fusca','Motor 1.6')
GO

SELECT * FROM Carro
GO