---SP para crear una pelicula
CREATE PROCEDURE CRE_MOVIE_PR
    @P_Title nvarchar(75),
    @P_Description nvarchar(250),
    @P_RealiseDate datetime,
    @P_Genre nvarchar(20),
    @P_Director nvarchar(30)
AS
BEGIN
    INSERT INTO TBL_Movie(Created, Title, Description, RealiseDate, Genre, Director)
    VALUES(GETDATE(), @P_Title, @P_Description, @P_RealiseDate, @P_Genre, @P_Director);
END
GO