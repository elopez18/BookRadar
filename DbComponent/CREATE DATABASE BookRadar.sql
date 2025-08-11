USE master
GO
-- DROP DATABASE BookRadar
IF NOT EXISTS(SELECT [name] FROM sys.databases WHERE [name] = 'BookRadar')
BEGIN 
	CREATE DATABASE BookRadar
END

GO

USE BookRadar
GO

IF OBJECT_ID(N'dbo.Books', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Books (
		Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
		Titulo VARCHAR(255) NOT NULL,
		AnioPublicacion VARCHAR(15) NOT NULL,
		Editorial VARCHAR(255) NOT NULL,
        AutorBuscado VARCHAR(255) NOT NULL,
        FechaConsulta DATETIME NOT NULL
    );
END

IF OBJECT_ID(N'dbo.HistorialBusquedas', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HistorialBusquedas (
		Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
		Autor VARCHAR(255) NOT NULL,
		Titulo VARCHAR(255) NOT NULL,
		AnioPublicacion VARCHAR(15) NOT NULL,		
		Editorial VARCHAR(255) NOT NULL,        
        FechaConsulta DATETIME NOT NULL
    );
END
GO

IF OBJECT_ID('ConsultarHistorico','P')> 0
BEGIN
	DROP PROCEDURE ConsultarHistorico
END
GO

CREATE PROCEDURE ConsultarHistorico
AS
BEGIN
	SELECT 
		Id
		,Autor
		,Titulo
		,AnioPublicacion
		,Editorial
		,FechaConsulta
	FROM dbo.HistorialBusquedas WITH(NOLOCK)
END

