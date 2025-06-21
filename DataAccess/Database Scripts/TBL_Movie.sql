/****** Object:  Table [dbo].[TBL_Movie]    Script Date: 12/6/2025 16:27:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBL_Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Title] [nvarchar](75) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[RealiseDate] [datetime] NOT NULL,
	[Genre] [nvarchar](20) NOT NULL,
	[Director] [nvarchar](30) NOT NULL
) ON [PRIMARY]
GO
