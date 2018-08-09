
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/09/2018 15:29:48
-- Generated from EDMX file: F:\csharpProj\EF-ModelFirst\EF-ModelFirst\ModelTest.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserOrderDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetailSet] DROP CONSTRAINT [FK_UserOrderDetail];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[OrderDetailSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetailSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sex] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Weight] nvarchar(max)  NOT NULL,
    [Height] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderDetailSet'
CREATE TABLE [dbo].[OrderDetailSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoginTime] nvarchar(max)  NOT NULL,
    [LogoutTime] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderDetailSet'
ALTER TABLE [dbo].[OrderDetailSet]
ADD CONSTRAINT [PK_OrderDetailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'OrderDetailSet'
ALTER TABLE [dbo].[OrderDetailSet]
ADD CONSTRAINT [FK_UserOrderDetail]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOrderDetail'
CREATE INDEX [IX_FK_UserOrderDetail]
ON [dbo].[OrderDetailSet]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------