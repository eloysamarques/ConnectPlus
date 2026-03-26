CREATE DATABASE ConnectPlus;
GO

USE ConnectPlus;

CREATE TABLE TipoContato
(
    IdTipoContato UNIQUEIDENTIFIER PRIMARY KEY DEFAULT ((NEWID())),
    Titulo        VARCHAR(100)     NOT NULL
);
SELECT * FROM TipoContato
GO

CREATE TABLE Contato
(
    IdContato      UNIQUEIDENTIFIER PRIMARY KEY DEFAULT ((NEWID())),
    Nome           VARCHAR(150) NOT NULL,
    FormaContato   VARCHAR(150) NOT NULL,
    Imagem         VARCHAR(255),
   
    IdTipoContato  UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES TipoContato(IdTipoContato)
);
SELECT * FROM TipoContato
GO