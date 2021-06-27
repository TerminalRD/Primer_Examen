CREATE PROCEDURE [dbo].[TitlesInsertar]
	@Descripcion VARCHAR (250),
	@Estado BIT
AS
	BEGIN
	SET NOCOUNT ON
		BEGIN TRANSACTION Trasa
			BEGIN TRY
				INSERT INTO Titles
				(
					Descripcion
					,Estado
				)
				VALUES
				(
				@Descripcion
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
