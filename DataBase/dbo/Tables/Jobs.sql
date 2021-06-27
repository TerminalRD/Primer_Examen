﻿CREATE TABLE [dbo].[Jobs]
(
	Id_Puesto INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Puesto PRIMARY KEY CLUSTERED(Id_Puesto)
	,Nombre VARCHAR(250) NOT NULL
	,Salario INT
	,Estado BIT NOT NULL
)
WITH (DATA_COMPRESSION=PAGE) -- TODAS LAS TABLAS TIENEN QUE IR COMPRIMIDAS
GO 