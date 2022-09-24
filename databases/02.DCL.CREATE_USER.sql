USE [TestDb]
GO
CREATE SCHEMA [STOREHOUSE]
GO
USE master
CREATE LOGIN [TestDbLogin] WITH PASSWORD = 'TestDbDevelop1';
GO
USE [TestDb]
GO
CREATE USER [TestDbUser] FOR LOGIN [TestDbLogin] WITH DEFAULT_SCHEMA=[STOREHOUSE]
GO
ALTER AUTHORIZATION ON SCHEMA::[STOREHOUSE] TO [TestDbUser]
GO
USE [TestDb]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [TestDbUser]
GO
USE [TestDb]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [TestDbUser]
GO
USE [TestDb]
GO
ALTER ROLE [db_datareader] ADD MEMBER [TestDbUser]
GO
USE [TestDb]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [TestDbUser]
GO
USE [TestDb]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [TestDbUser]
GO
USE [TestDb]
GO
ALTER ROLE [db_owner] ADD MEMBER [TestDbUser]
GO
USE [TestDb]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [TestDbUser]