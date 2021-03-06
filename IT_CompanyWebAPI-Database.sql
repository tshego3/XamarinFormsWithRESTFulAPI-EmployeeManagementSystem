USE [master]
GO
/****** Object:  Database [IT_CompanyWebAPI]    Script Date: 2020/09/27 14:31:06 ******/
CREATE DATABASE [IT_CompanyWebAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'iT_CompanyWebAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\iT_CompanyWebAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'iT_CompanyWebAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\iT_CompanyWebAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IT_CompanyWebAPI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IT_CompanyWebAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IT_CompanyWebAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET RECOVERY FULL 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET  MULTI_USER 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IT_CompanyWebAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IT_CompanyWebAPI] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'IT_CompanyWebAPI', N'ON'
GO
ALTER DATABASE [IT_CompanyWebAPI] SET QUERY_STORE = OFF
GO
USE [IT_CompanyWebAPI]
GO
/****** Object:  User [root]    Script Date: 2020/09/27 14:31:07 ******/
CREATE USER [root] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [admin]    Script Date: 2020/09/27 14:31:07 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [root]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [root]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2020/09/27 14:31:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[employeeID] [int] IDENTITY(1,1) NOT NULL,
	[tbFirstName] [varchar](25) NULL,
	[tbSurname] [varchar](255) NULL,
	[tbTellNo] [varchar](50) NULL,
	[tbEmail] [varchar](255) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[employeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2020/09/27 14:31:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tbUname] [varchar](255) NULL,
	[tbPass] [varchar](255) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (1, N'Logan', N'Glover', N'0812345676', N'loganglover@itc.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (2, N'Lacey', N'Boehm', N'0812345675', N'laceyboehm@itc.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (3, N'Jack', N'Batz', N'0812345674', N'jackbatz@itc.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (4, N'Verla', N'Emard', N'0812345673', N'verlaemard@itc.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (5, N'Anna', N'Smith', N'0812345673', N'annasmith@itc.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (6, N'Joe', N'Jackson', N'0812345678', N'joejackson@itc.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (7, N'Sam', N'Block', N'0812345679', N'samblock@itc.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (8, N'User', N'user', N'0123456789', N'janesam@itc.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (9, N'jon', N'smith', N'yuggyuu', N'jiioio')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (10, N'Peter', N'Paul', N'0987654321', N'peter@paul.co.za')
INSERT [dbo].[Employees] ([employeeID], [tbFirstName], [tbSurname], [tbTellNo], [tbEmail]) VALUES (1002, N'Peter', N'Paul', N'0987654391', N'peter@paul.co.za')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [tbUname], [tbPass]) VALUES (1, N'Admin', N'Pass')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [IT_CompanyWebAPI] SET  READ_WRITE 
GO
