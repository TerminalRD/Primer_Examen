CREATE PROCEDURE [dbo].[TitlesObtener]
	@Id_Titulo INT= NULL
AS
	BEGIN
	SET NOCOUNT ON --Optimizar las consulta, usar siempre

	SELECT
		Id_Titulo
		,Descripcion
		,Estado

	FROM Titles
	WHERE (@Id_Titulo IS NULL OR Id_Titulo=@Id_Titulo)
	END
