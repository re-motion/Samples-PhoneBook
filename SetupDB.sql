USE PhoneBook
GO

-- Drop all views that will be created below
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.Views WHERE TABLE_NAME = 'LocationView' AND TABLE_SCHEMA = 'dbo')
  DROP VIEW [dbo].[LocationView]

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.Views WHERE TABLE_NAME = 'PersonView' AND TABLE_SCHEMA = 'dbo')
  DROP VIEW [dbo].[PersonView]

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.Views WHERE TABLE_NAME = 'PhoneNumberView' AND TABLE_SCHEMA = 'dbo')
  DROP VIEW [dbo].[PhoneNumberView]
GO

-- Drop foreign keys of all tables that will be created below
DECLARE @statement nvarchar (4000)
SET @statement = ''
SELECT @statement = @statement + 'ALTER TABLE [dbo].[' + t.name + '] DROP CONSTRAINT [' + fk.name + ']; ' 
    FROM sysobjects fk INNER JOIN sysobjects t ON fk.parent_obj = t.id 
    WHERE fk.xtype = 'F' AND t.name IN ('Location', 'Person', 'PhoneNumber')
    ORDER BY t.name, fk.name
exec sp_executesql @statement
GO

-- Drop all tables that will be created below
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.Tables WHERE TABLE_NAME = 'Location' AND TABLE_SCHEMA = 'dbo')
  DROP TABLE [dbo].[Location]

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.Tables WHERE TABLE_NAME = 'Person' AND TABLE_SCHEMA = 'dbo')
  DROP TABLE [dbo].[Person]

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.Tables WHERE TABLE_NAME = 'PhoneNumber' AND TABLE_SCHEMA = 'dbo')
  DROP TABLE [dbo].[PhoneNumber]
GO

-- Create all tables
CREATE TABLE [dbo].[Location]
(
  [ID] uniqueidentifier NOT NULL,
  [ClassID] varchar (100) NOT NULL,
  [Timestamp] rowversion NOT NULL,

  -- Location columns
  [Street] nvarchar (60) NOT NULL,
  [LocationNumber] nvarchar (12) NULL,
  [City] nvarchar (60) NULL,
  [Country] int NULL,
  [ZipCode] int NOT NULL,

  CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([ID])
)

CREATE TABLE [dbo].[Person]
(
  [ID] uniqueidentifier NOT NULL,
  [ClassID] varchar (100) NOT NULL,
  [Timestamp] rowversion NOT NULL,

  -- Person columns
  [FirstName] nvarchar (60) NULL,
  [Surname] nvarchar (60) NOT NULL,
  [LocationID] uniqueidentifier NULL,

  CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([ID])
)

CREATE TABLE [dbo].[PhoneNumber]
(
  [ID] uniqueidentifier NOT NULL,
  [ClassID] varchar (100) NOT NULL,
  [Timestamp] rowversion NOT NULL,

  -- PhoneNumber columns
  [CountryCode] nvarchar (8) NULL,
  [AreaCode] nvarchar (8) NULL,
  [Number] nvarchar (12) NOT NULL,
  [Extension] nvarchar (8) NULL,
  [PersonID] uniqueidentifier NULL,

  CONSTRAINT [PK_PhoneNumber] PRIMARY KEY CLUSTERED ([ID])
)
GO

-- Create constraints for tables that were created above
ALTER TABLE [dbo].[Person] ADD
  CONSTRAINT [FK_Person_LocationID] FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Location] ([ID])

ALTER TABLE [dbo].[PhoneNumber] ADD
  CONSTRAINT [FK_PhoneNumber_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([ID])
GO

-- Create a view for every class
CREATE VIEW [dbo].[LocationView] ([ID], [ClassID], [Timestamp], [Street], [LocationNumber], [City], [Country], [ZipCode])
  WITH SCHEMABINDING AS
  SELECT [ID], [ClassID], [Timestamp], [Street], [LocationNumber], [City], [Country], [ZipCode]
    FROM [dbo].[Location]
    WHERE [ClassID] IN ('Location')
  WITH CHECK OPTION
GO

CREATE VIEW [dbo].[PersonView] ([ID], [ClassID], [Timestamp], [FirstName], [Surname], [LocationID])
  WITH SCHEMABINDING AS
  SELECT [ID], [ClassID], [Timestamp], [FirstName], [Surname], [LocationID]
    FROM [dbo].[Person]
    WHERE [ClassID] IN ('Person')
  WITH CHECK OPTION
GO

CREATE VIEW [dbo].[PhoneNumberView] ([ID], [ClassID], [Timestamp], [CountryCode], [AreaCode], [Number], [Extension], [PersonID])
  WITH SCHEMABINDING AS
  SELECT [ID], [ClassID], [Timestamp], [CountryCode], [AreaCode], [Number], [Extension], [PersonID]
    FROM [dbo].[PhoneNumber]
    WHERE [ClassID] IN ('PhoneNumber')
  WITH CHECK OPTION
GO
