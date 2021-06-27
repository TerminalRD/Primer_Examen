CREATE PROCEDURE [dbo].[DeparmentsObtener]
	@Id_Departamento INT = NULL

AS
	BEGIN
	SET NOCOUNT ON
		SELECT 
		Id_Departamento,
		Descripcion,
		Ubicacion,
		Estado			
		FROM Departments
		WHERE (@Id_Departamento IS NULL OR Id_Departamento=@Id_Departamento)
	END