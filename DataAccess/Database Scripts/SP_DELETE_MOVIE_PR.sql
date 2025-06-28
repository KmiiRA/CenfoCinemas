--SP para Eliminar Usuario
CREATE PROCEDURE DELETE_MOVIE_PR
(
	@P_Id int
)
AS
BEGIN
	DELETE FROM TBL_Movie
	Where Id =@P_Id


END
GO
