USE volvo;

IF OBJECT_ID('[dbo].[truck]', 'U') IS NULL
EXEC('
CREATE Table [dbo].[truck] (
	[id] [int] IDENTITY(1,1),
	[modelId] [int] NOT NULL,
	[name] varchar(100) NULL,
	[value] decimal(19,4) NULL,	
	[date] [datetime] NOT NULL,
	[yearModel] [int] NOT NULL
 CONSTRAINT [PK_truck_id] PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
');
GO

IF (OBJECT_ID('[FK_truck(modelId)@model(id)]', 'F') IS NULL)
BEGIN
    ALTER TABLE truck 
	ADD CONSTRAINT [FK_truck(model_id)@model(id)]
	FOREIGN KEY (modelId) REFERENCES model(id);
END