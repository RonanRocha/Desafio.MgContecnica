/*
 Navicat Premium Data Transfer

 Source Server         : sql server docker
 Source Server Type    : SQL Server
 Source Server Version : 15004440
 Source Host           : localhost:1433
 Source Catalog        : mgcontecnica
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15004440
 File Encoding         : 65001

 Date: 20/08/2025 00:11:13
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Categorias
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Categorias]') AND type IN ('U'))
	DROP TABLE [dbo].[Categorias]
GO

CREATE TABLE [dbo].[Categorias] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Nome] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Status] int  NOT NULL,
  [Tipo] int  NOT NULL,
  [DataCriacao] datetime2(7)  NOT NULL,
  [DataUltimaAtualizacao] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Categorias] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Transacoes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Transacoes]') AND type IN ('U'))
	DROP TABLE [dbo].[Transacoes]
GO

CREATE TABLE [dbo].[Transacoes] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Descricao] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Valor] decimal(18,2)  NOT NULL,
  [Data] datetime2(7)  NOT NULL,
  [CategoriaId] int  NOT NULL,
  [Observacoes] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DataCriacao] datetime2(7)  NOT NULL,
  [DataUltimaAtualizacao] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[Transacoes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Categorias
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Categorias]', RESEED, 1002)
GO


-- ----------------------------
-- Primary Key structure for table Categorias
-- ----------------------------
ALTER TABLE [dbo].[Categorias] ADD CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Transacoes
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Transacoes]', RESEED, 1001)
GO


-- ----------------------------
-- Indexes structure for table Transacoes
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_Transacoes_CategoriaId]
ON [dbo].[Transacoes] (
  [CategoriaId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table Transacoes
-- ----------------------------
ALTER TABLE [dbo].[Transacoes] ADD CONSTRAINT [PK_Transacoes] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Transacoes
-- ----------------------------
ALTER TABLE [dbo].[Transacoes] ADD CONSTRAINT [FK_Transacoes_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[Categorias] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

