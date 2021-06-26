CREATE PROCEDURE [dbo].[JobsObtener]
	@Id_Puesto INT= NULL
AS
	BEGIN
	SET NOCOUNT ON --Optimizar las consulta, usar siempre

	SELECT
		Id_Puesto
		,Nombre
		,Salario
		,Estado

	FROM Jobs
	WHERE (@Id_Puesto IS NULL OR Id_Puesto=@Id_Puesto)
	END
