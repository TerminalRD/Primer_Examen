CREATE PROCEDURE [dbo].[DeparmentsEliminar]
@Id_Departamento INT

AS
	BEGIN
		SET NOCOUNT ON
		BEGIN TRANSACTION Trasa
			BEGIN TRY
				DELETE FROM Departments
				WHERE Id_Departamento=@Id_Departamento

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