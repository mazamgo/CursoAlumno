USE [master]
GO
/****** Object:  Database [Test]    Script Date: 10/12/2017 12:09:30 ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Test.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Test_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Adjunto]    Script Date: 10/12/2017 12:09:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adjunto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Alumno_id] [int] NOT NULL,
	[Archivo] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Adjunto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 10/12/2017 12:09:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Sexo] [int] NOT NULL,
	[FechaNacimiento] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AlumnoCurso]    Script Date: 10/12/2017 12:09:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnoCurso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Alumno_id] [int] NOT NULL,
	[Curso_id] [int] NOT NULL,
	[Nota] [decimal](18, 2) NOT NULL CONSTRAINT [DF_AlumnoCurso_Nota]  DEFAULT ((0)),
 CONSTRAINT [PK_AlumnoCurso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Curso]    Script Date: 10/12/2017 12:09:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Curso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/12/2017 12:09:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Foto] [nvarchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Adjunto] ON 

GO
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (1, 2004, N'abc.jpg')
GO
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (2, 2004, N'20150707185512.xlsx')
GO
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (3, 2004, N'20150707190840.xlsx')
GO
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (4, 2004, N'20150707190844.xlsx')
GO
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (5, 2004, N'20150707190844.xlsx')
GO
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (6, 2004, N'20150707190845.xlsx')
GO
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (7, 2004, N'20150707190845.xlsx')
GO
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (8, 2004, N'20150707190845.xlsx')
GO
SET IDENTITY_INSERT [dbo].[Adjunto] OFF
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

GO
INSERT [dbo].[Alumno] ([id], [Nombre], [Apellido], [Sexo], [FechaNacimiento]) VALUES (2004, N'Eduardo x', N'Rodriguez Patiño x', 1, N'1989-02-11')
GO
INSERT [dbo].[Alumno] ([id], [Nombre], [Apellido], [Sexo], [FechaNacimiento]) VALUES (3009, N'Nombre 1', N'Apellido ', 1, N'1989-15-02')
GO
INSERT [dbo].[Alumno] ([id], [Nombre], [Apellido], [Sexo], [FechaNacimiento]) VALUES (3010, N'Nombre2', N'Apellido2', 2, N'01/01/01')
GO
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[AlumnoCurso] ON 

GO
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (1, 2004, 1, CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (2, 2004, 2, CAST(17.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (3, 2004, 3, CAST(16.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (4, 2004, 4, CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (5, 3009, 1, CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (6, 3010, 1, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (7, 3010, 2, CAST(11.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[AlumnoCurso] OFF
GO
SET IDENTITY_INSERT [dbo].[Curso] ON 

GO
INSERT [dbo].[Curso] ([id], [Nombre]) VALUES (1, N'ASP.NET MVC')
GO
INSERT [dbo].[Curso] ([id], [Nombre]) VALUES (2, N'Angular JS')
GO
INSERT [dbo].[Curso] ([id], [Nombre]) VALUES (3, N'jQuery')
GO
INSERT [dbo].[Curso] ([id], [Nombre]) VALUES (4, N'Laravel')
GO
SET IDENTITY_INSERT [dbo].[Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([UsuarioID], [Nombre], [Apellido], [Email], [Password], [Foto]) VALUES (1, N'admin', N'Supervisor', N'admin@go.com.ni', N'e10adc3949ba59abbe56e057f20f883e', NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Adjunto]  WITH CHECK ADD  CONSTRAINT [FK_Adjunto_Alumno] FOREIGN KEY([Alumno_id])
REFERENCES [dbo].[Alumno] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Adjunto] CHECK CONSTRAINT [FK_Adjunto_Alumno]
GO
ALTER TABLE [dbo].[AlumnoCurso]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoCurso_Alumno] FOREIGN KEY([Alumno_id])
REFERENCES [dbo].[Alumno] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlumnoCurso] CHECK CONSTRAINT [FK_AlumnoCurso_Alumno]
GO
ALTER TABLE [dbo].[AlumnoCurso]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoCurso_Curso] FOREIGN KEY([Curso_id])
REFERENCES [dbo].[Curso] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlumnoCurso] CHECK CONSTRAINT [FK_AlumnoCurso_Curso]
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
