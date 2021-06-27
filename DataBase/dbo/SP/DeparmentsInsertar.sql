CREATE PROCEDURE [dbo].[DeparmentsInsertar]
	@Id_Departamento INT,
	@Descripcion VARCHAR (250),
	@Ubicacion VARCHAR (250),
	@Estado BIT
AS
	BEGIN
	SET NOCOUNT ON
		BEGIN TRANSACTION Trasa
			BEGIN TRY
				INSERT INTO Departments
				(
					Id_Departamento
					,Descripcion
					,Ubicacion
					,Estado
				)
				VALUES
				(
				@Id_Departamento,
				@Descripcion,
				@Ubicacion,
				@Estado
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
