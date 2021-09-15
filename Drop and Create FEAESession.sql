USE [dal11]
GO

/****** Object:  Table [dbo].[FEAESession]    Script Date: 27/08/2021 11:22:16 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FEAESession]') AND type in (N'U'))
DROP TABLE [dbo].[FEAESession]
GO

/****** Object:  Table [dbo].[FEAESession]    Script Date: 27/08/2021 11:22:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FEAESession](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TimeStart] [datetime2](7) NULL,
	[TimeFinish] [datetime2](7) NULL,
	[UserHostAddress] [nvarchar](255) NULL,
	[UserHostName] [nvarchar](255) NULL,
	[UserAgent] [nvarchar](1024) NULL,
	[Processed] [int] NOT NULL DEFAULT 0,
	[IsDebug] [bit] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_FEAESession] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


