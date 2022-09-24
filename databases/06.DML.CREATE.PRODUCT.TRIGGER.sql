
CREATE OR ALTER TRIGGER [PRODUCT_INSERT] ON [STOREHOUSE].[PRODUCT]
   AFTER INSERT
AS 
BEGIN
	SET ANSI_NULLS ON;
	SET QUOTED_IDENTIFIER ON;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for trigger here
	IF (ROWCOUNT_BIG() = 0) RETURN;
	
	INSERT INTO EVENTLOG
	SELECT
		INSERTED.[ID],
		sysdatetimeoffset() as EVENTDATE,
		'INSERTED:' + INSERTED.[DESCRIPTION] as [DESCRIPTION]
	FROM INSERTED;

END
GO
CREATE OR ALTER TRIGGER [PRODUCT_DELETE] ON [STOREHOUSE].[PRODUCT]
   AFTER DELETE
AS 
BEGIN
	SET ANSI_NULLS ON;
	SET QUOTED_IDENTIFIER ON;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for trigger here
	IF (ROWCOUNT_BIG() = 0) RETURN;
	
	INSERT INTO EVENTLOG
	SELECT
		deleted.[ID],
		sysdatetimeoffset() as EVENTDATE,
		'DELETED:' + deleted.[DESCRIPTION] as [DESCRIPTION]
	FROM deleted;

END
GO
GO
CREATE OR ALTER TRIGGER [PRODUCT_UPDATE] ON [STOREHOUSE].[PRODUCT]
   AFTER UPDATE
AS 
BEGIN
	SET ANSI_NULLS ON;
	SET QUOTED_IDENTIFIER ON;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for trigger here
	IF (ROWCOUNT_BIG() = 0) RETURN;
	
	INSERT INTO EVENTLOG
	SELECT
		inserted.[ID],
		sysdatetimeoffset() as EVENTDATE,
		'UPDATED:' + inserted.[DESCRIPTION] as [DESCRIPTION]
	FROM inserted;

END
