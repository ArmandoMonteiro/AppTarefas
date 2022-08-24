USE [DbTarefas]
GO

/****** Object:  Table [dbo].[TbStatus]    Script Date: 24/08/2022 15:50:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TbStatus](
	[IdStatus] [int] IDENTITY(1,1) NOT NULL,
	[DescStatus] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [DbTarefas]
GO

/****** Object:  Table [dbo].[TbTarefas]    Script Date: 24/08/2022 15:51:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TbTarefas](
	[IdTarefa] [int] IDENTITY(1,1) NOT NULL,
	[DescTarefa] [varchar](50) NULL,
	[IdStatus] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



