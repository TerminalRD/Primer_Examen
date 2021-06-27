CREATE PROCEDURE [dbo].[TitlesActualizar]
	@Id_Titulo INT,
	@Descripcion VARCHAR(250),
	@Estado BIT
AS
	BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION Trasa
		BEGIN TRY
			UPDATE Titles
				SET
				Descripcion=@Descripcion,
				Estado=@Estado
				WHERE
					Id_Titulo=@Id_Titulo
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
