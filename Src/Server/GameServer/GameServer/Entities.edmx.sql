
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/15/2019 22:11:51
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
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_TUserTPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_TPlayerTCharacter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Characters] DROP CONSTRAINT [FK_TPlayerTCharacter];
GO
IF OBJECT_ID(N'[dbo].[FK_CharacterItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CharacterItems] DROP CONSTRAINT [FK_CharacterItem];
GO
IF OBJECT_ID(N'[dbo].[FK_TCharactersTCharacterBag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Characters] DROP CONSTRAINT [FK_TCharactersTCharacterBag];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Players]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Players];
GO
IF OBJECT_ID(N'[dbo].[Characters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Characters];
GO
IF OBJECT_ID(N'[dbo].[CharacterItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CharacterItems];
GO
IF OBJECT_ID(N'[dbo].[CharacterBags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CharacterBags];
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
    [Gold] bigint  NOT NULL,
    [Level] int  NOT NULL,
    [TPlayerID] int  NOT NULL,
    [Equips] binary(28)  NOT NULL,
    [Bag_Id] int  NOT NULL
);
GO

-- Creating table 'CharacterItems'
CREATE TABLE [dbo].[CharacterItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ItemID] int  NOT NULL,
    [ItemCount] int  NOT NULL,
    [CharactersID] int  NOT NULL
);
GO

-- Creating table 'CharacterBags'
CREATE TABLE [dbo].[CharacterBags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Items] varbinary(max)  NOT NULL,
    [Unlocked] int  NOT NULL
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

-- Creating primary key on [Id] in table 'CharacterItems'
ALTER TABLE [dbo].[CharacterItems]
ADD CONSTRAINT [PK_CharacterItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CharacterBags'
ALTER TABLE [dbo].[CharacterBags]
ADD CONSTRAINT [PK_CharacterBags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating foreign key on [CharactersID] in table 'CharacterItems'
ALTER TABLE [dbo].[CharacterItems]
ADD CONSTRAINT [FK_CharacterItem]
    FOREIGN KEY ([CharactersID])
    REFERENCES [dbo].[Characters]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CharacterItem'
CREATE INDEX [IX_FK_CharacterItem]
ON [dbo].[CharacterItems]
    ([CharactersID]);
GO

-- Creating foreign key on [Bag_Id] in table 'Characters'
ALTER TABLE [dbo].[Characters]
ADD CONSTRAINT [FK_TCharactersTCharacterBag]
    FOREIGN KEY ([Bag_Id])
    REFERENCES [dbo].[CharacterBags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TCharactersTCharacterBag'
CREATE INDEX [IX_FK_TCharactersTCharacterBag]
ON [dbo].[Characters]
    ([Bag_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------