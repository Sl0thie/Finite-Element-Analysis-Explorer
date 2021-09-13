USE [dal11]
GO

/****** Object:  Table [dbo].[FEAESessionStart]    Script Date: 27/08/2021 11:23:36 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FEAESessionStart]') AND type in (N'U'))
DROP TABLE [dbo].[FEAESessionStart]
GO

/****** Object:  Table [dbo].[FEAESessionStart]    Script Date: 27/08/2021 11:23:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FEAESessionStart](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime2](7) NULL,
	[UserHostAddress] [nvarchar](255) NULL,
	[UserHostName] [nvarchar](255) NULL,
	[UserAgent] [nvarchar](1024) NULL,
	[Processed] [int] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_FEAESessionStart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


