USE [master]
GO
/****** Object:  Database [aspnet-MvcMovie-5ae3798a]    Script Date: 20/01/2020 18:41:46 ******/
CREATE DATABASE [aspnet-MvcMovie-5ae3798a]

 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'aspnet-MvcMovie-5ae3798a', FILENAME = N'C:\aspnet-MvcMovie-5ae3798a.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'aspnet-MvcMovie-5ae3798a_log', FILENAME = N'C:\aspnet-MvcMovie-5ae3798a_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [aspnet-MvcMovie-5ae3798a].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET ARITHABORT OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET  ENABLE_BROKER 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET  MULTI_USER 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET DB_CHAINING OFF 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET QUERY_STORE = OFF
GO
USE [aspnet-MvcMovie-5ae3798a]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [aspnet-MvcMovie-5ae3798a]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20/01/2020 18:41:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 20/01/2020 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[FornecedorId] [int] IDENTITY(1,1) NOT NULL,
	[RazaoSocial] [nvarchar](300) NULL,
	[Fantasia] [nvarchar](300) NULL,
	[CNPJ] [nvarchar](50) NULL,
 CONSTRAINT [PK_Fornecedor] PRIMARY KEY CLUSTERED 
(
	[FornecedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 20/01/2020 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[ProdutoId] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](300) NULL,
	[Valor] [decimal](18, 2) NULL,
	[FornecedorId] [int] NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[ProdutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Produto_FornecedorId]    Script Date: 20/01/2020 18:41:47 ******/
CREATE NONCLUSTERED INDEX [IX_Produto_FornecedorId] ON [dbo].[Produto]
(
	[FornecedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_Fornecedor_FornecedorId] FOREIGN KEY([FornecedorId])
REFERENCES [dbo].[Fornecedor] ([FornecedorId])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_Fornecedor_FornecedorId]
GO
/****** Object:  StoredProcedure [dbo].[RelatorioProdutos]    Script Date: 20/01/2020 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelatorioProdutos]
AS

DECLARE @server varchar(100)	= '(localdb)\mssqllocaldb'
DECLARE @database varchar(100)	= 'aspnet-MvcMovie-5ae3798a'
DECLARE @header varchar(1000)	= 'SELECT ''ProdutoId'', ''Descricao'', ''Valor'', ''FornecedorId'', ''RazaoSocial'', ''Fantasia'', ''CNPJ'';'
DECLARE @query varchar(4000)	= 'SELECT p.ProdutoId, p.Descricao, p.Valor, f.FornecedorId, f.RazaoSocial, f.Fantasia, f.CNPJ FROM Produto p INNER JOIN Fornecedor f ON p.FornecedorId = f.FornecedorId'
DECLARE @file varchar(1000)		= '"C:\Relatorio.csv"'
DECLARE @command varchar(4000)	= 'SQLCMD -S ' + @server + ' -d ' + @database + ' -Q "SET NOCOUNT ON;' + @header + @query + '" -s ";" -W -R -h-1 -o ' + @file

--PRINT @command

EXEC xp_cmdshell @command;

GO
USE [master]
GO
ALTER DATABASE [aspnet-MvcMovie-5ae3798a] SET  READ_WRITE 
GO
