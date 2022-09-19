USE master;
GO
IF DB_ID(N'TestDb') IS NOT NULL
	DROP DATABASE TestDb;
GO
CREATE DATABASE TestDb
ON
(
	NAME = storehouse_data,
	FILENAME = 'G:\repos\storehouse\databases\MSSQL_DATA\storehouse.mdf',
	SIZE = 16MB,
	MAXSIZE = 256MB,
	FILEGROWTH = 8MB
)
LOG ON
(
	NAME = storehouse_log,
	FILENAME = 'G:\repos\storehouse\databases\MSSQL_DATA\storehouse.ldf',
	SIZE = 16MB,
	MAXSIZE = 128MB,
	FILEGROWTH = 8MB
);
