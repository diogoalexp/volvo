USE volvo;

IF OBJECT_ID('[dbo].[model]', 'U') IS NULL
EXEC('
CREATE Table [dbo].[model] (
	[id] [int] IDENTITY(1,1),
	[name] [nvarchar](100) NOT NULL,

 CONSTRAINT [PK_model_id] PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
');
GO
