USE TestDb;
BEGIN TRANSACTION;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID(N'EVENTLOG') IS NOT NULL
	DROP TABLE [STOREHOUSE].[EVENTLOG];
GO
CREATE TABLE [STOREHOUSE].[EVENTLOG]
(
	[ID]			UNIQUEIDENTIFIER	NOT NULL,
	[EVENTDATE]		DATETIMEOFFSET		NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	[DESCRITION]	VARCHAR(MAX)		DEFAULT NULL ,
) ON [PRIMARY];
GO
ALTER TABLE [STOREHOUSE].[EVENTLOG] ADD CONSTRAINT
	STOREHOUSE_EVENTLOG_ID_PK PRIMARY KEY([ID] ASC);
GO
CREATE NONCLUSTERED INDEX STOREHOUSE_EVENTLOG_EVENTDATE_NIX ON [STOREHOUSE].[EVENTLOG]([EVENTDATE] ASC)
WITH
(
	ALLOW_ROW_LOCKS = ON,
	ALLOW_PAGE_LOCKS = ON
);
GO
COMMIT TRANSACTION;