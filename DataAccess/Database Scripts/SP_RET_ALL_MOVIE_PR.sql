/****** Object:  StoredProcedure [dbo].[RET_ALL_MOVIE_PR]    Script Date: 21/6/2025 04:34:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RET_ALL_MOVIE_PR]
AS
BEGIN
    SELECT Id, Created, Updated, Title, Description, RealiseDate, Genre, Director
    FROM TBL_Movie;
END
GO

