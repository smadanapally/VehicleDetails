USE [AutomobileDb]
GO

/****** Object:  Table [dbo].[AutomobileInfo]    Script Date: 11/14/2017 2:50:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AutomobileInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Make] [varchar](100) NOT NULL,
	[Model] [varchar](100) NOT NULL,
 CONSTRAINT [pkAutomobileInfoOnId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
