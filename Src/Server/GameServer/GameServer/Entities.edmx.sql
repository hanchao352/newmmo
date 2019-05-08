
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/04/2019 18:33:56
-- Generated from EDMX file: E:\newmmo\Src\Server\GameServer\GameServer\Entities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ExtremeWorld];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TUserTPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TUser] DROP CONSTRAINT [FK_TUserTPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_TPlayerTCharacter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TCharacters] DROP CONSTRAINT [FK_TPlayerTCharacter];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TUser];
GO
IF OBJECT_ID(N'[dbo].[TPlayer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TPlayer];
GO
IF OBJECT_ID(N'[dbo].[TCharacters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TCharacters];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [PassWord] nvarchar(max)  NOT NULL,
    [RegisterDate] nvarchar(max)  NOT NULL,
    [TPlayer_ID] int  NOT NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Characters'
CREATE TABLE [dbo].[Characters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TID] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Class] int  NOT NULL,
    [MapID] int  NOT NULL,
    [MapPosX] int  NOT NULL,
    [MapPosY] int  NOT NULL,
    [MapPosZ] int  NOT NULL,
    [Gold] int  NOT NULL,
    [Level] int  NOT NULL,
    [TPlayerID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Characters'
ALTER TABLE [dbo].[Characters]
ADD CONSTRAINT [PK_Characters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TPlayer_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_TUserTPlayer]
    FOREIGN KEY ([TPlayer_ID])
    REFERENCES [dbo].[Players]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TUserTPlayer'
CREATE INDEX [IX_FK_TUserTPlayer]
ON [dbo].[Users]
    ([TPlayer_ID]);
GO

-- Creating foreign key on [TPlayerID] in table 'Characters'
ALTER TABLE [dbo].[Characters]
ADD CONSTRAINT [FK_TPlayerTCharacter]
    FOREIGN KEY ([TPlayerID])
    REFERENCES [dbo].[Players]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TPlayerTCharacter'
CREATE INDEX [IX_FK_TPlayerTCharacter]
ON [dbo].[Characters]
    ([TPlayerID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------