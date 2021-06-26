﻿CREATE PROCEDURE [dbo].[JobsEliminar]
@Id_Puesto INT

AS
	BEGIN
		SET NOCOUNT ON
		BEGIN TRANSACTION Trasa
			BEGIN TRY
				DELETE FROM Jobs
				WHERE Id_Puesto=@Id_Puesto

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