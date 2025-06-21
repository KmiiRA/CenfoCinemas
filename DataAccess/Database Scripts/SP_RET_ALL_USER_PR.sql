/****** Object:  StoredProcedure [dbo].[RET_ALL_USER_PR]    Script Date: 21/6/2025 04:34:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RET_ALL_USER_PR]
AS
BEGIN
    SELECT Id, Created, Updated, UserCode, Name, Email, Password, BirthDate, Status
	FROM TBL_User;
END
GO

