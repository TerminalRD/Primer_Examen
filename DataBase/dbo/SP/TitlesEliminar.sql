﻿CREATE PROCEDURE [dbo].[TitlesEliminar]
	@Id_Titulo INT

AS
	BEGIN
		SET NOCOUNT ON
		BEGIN TRANSACTION Trasa
			BEGIN TRY
				DELETE FROM Titles
				WHERE Id_Titulo=@Id_Titulo

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