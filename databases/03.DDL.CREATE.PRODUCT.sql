USE TestDb;
GO
BEGIN TRANSACTION;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID(N'PRODUCT') IS NOT NULL
	DROP TABLE [STOREHOUSE].[PRODUCT];
GO
CREATE TABLE [STOREHOUSE].[PRODUCT]
(
	[ID] UNIQUEIDENTIFIER NOT NULL,
	[NAME] VARCHAR(255) NOT NULL,
	[DESCRITION] VARCHAR(MAX) DEFAULT NULL 
) ON [PRIMARY];
GO
ALTER TABLE [STOREHOUSE].[PRODUCT] ADD CONSTRAINT STOREHOUSE_PRODUCT_ID_PK PRIMARY KEY("ID" ASC);
GO
CREATE UNIQUE NONCLUSTERED INDEX STOREHOUSE_PRODUCT_NAME_NIX ON [STOREHOUSE].[PRODUCT]("NAME" ASC)
WITH
(
	ALLOW_ROW_LOCKS = ON,
	ALLOW_PAGE_LOCKS = ON
);
GO
COMMIT TRANSACTION;