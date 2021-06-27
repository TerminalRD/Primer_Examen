CREATE PROCEDURE [dbo].[DeparmentsActualizar]
	@Id_Departamento INT,
	@Descripcion VARCHAR (250),
	@Ubicacion VARCHAR (250),
	@Estado BIT
AS
	BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION Trasa
		BEGIN TRY
			UPDATE Departments
				SET
				Descripcion=@Descripcion,
				Ubicacion=@Ubicacion,
				Estado=@Estado
				WHERE
					Id_Departamento=@Id_Departamento
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
