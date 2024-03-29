﻿CREATE PROCEDURE [dbo].[JobsInsertar]
	@Nombre VARCHAR (250),
	@Salario INT,
	@Estado BIT
AS
	BEGIN
	SET NOCOUNT ON
		BEGIN TRANSACTION Trasa
			BEGIN TRY
				INSERT INTO Jobs
				(
					Nombre
					,Salario
					,Estado
				)
				VALUES
				(
				@Nombre
				,@Salario
				,@Estado
				)
				COMMIT TRANSACTION Trasa
					SELECT 0 AS CodeError, '' AS MsgError
				END TRY

				BEGIN CATCH
					SELECT
						ERROR_NUMBER() AS CodeError
						, ERROR_MESSAGE() AS MsgError
						ROLLBACK TRANSACTION Trasa
			END CATCH
	END
