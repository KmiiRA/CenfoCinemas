CREATE PROCEDURE SP_RET_MOVIE_BY_ID_PR
(
	@P_Id int
)
AS
BEGIN
SELECT Id,Created,Updated,Title,Description,RealiseDate,Genre,Director
	FROM TBL_Movie
	WHERE Id = @P_Id;
END
GO