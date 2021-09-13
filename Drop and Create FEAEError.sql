USE [dal11]
GO

/****** Object:  Table [dbo].[FEAEError]    Script Date: 27/08/2021 11:21:03 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FEAEError]') AND type in (N'U'))
DROP TABLE [dbo].[FEAEError]
GO

/****** Object:  Table [dbo].[FEAEError]    Script Date: 27/08/2021 11:21:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FEAEError](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime2](7) NULL,
	[UserHostAddress] [nvarchar](255) NULL,
	[UserHostName] [nvarchar](255) NULL,
	[UserAgent] [nvarchar](1024) NULL,
	[HResult] [int] NULL,
	[Message] [nvarchar](1024) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[TargetSite] [nvarchar](1024) NULL,
	[Source] [nvarchar](1024) NULL,
	[Processed] [int] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_FEAEError] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


