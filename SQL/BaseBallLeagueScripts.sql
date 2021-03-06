USE [master]
GO
/****** Object:  Database [BaseballLeague]    Script Date: 8/19/2016 4:46:36 PM ******/
CREATE DATABASE [BaseballLeague]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseballLeague', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BaseballLeague.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BaseballLeague_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BaseballLeague_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BaseballLeague] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseballLeague].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseballLeague] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseballLeague] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseballLeague] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseballLeague] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseballLeague] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseballLeague] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseballLeague] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseballLeague] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseballLeague] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseballLeague] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseballLeague] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseballLeague] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseballLeague] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseballLeague] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseballLeague] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseballLeague] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BaseballLeague] SET  MULTI_USER 
GO
ALTER DATABASE [BaseballLeague] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseballLeague] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseballLeague] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseballLeague] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BaseballLeague] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BaseballLeague]
GO
/****** Object:  Table [dbo].[HittingStats]    Script Date: 8/19/2016 4:46:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HittingStats](
	[PlayerId] [int] NOT NULL,
	[GP] [int] NOT NULL,
	[AB] [int] NOT NULL,
	[Hits] [int] NOT NULL,
	[Doubles] [int] NOT NULL,
	[Triples] [int] NOT NULL,
	[R] [int] NOT NULL,
	[HR] [int] NOT NULL,
	[RBI] [int] NOT NULL,
	[BB] [int] NOT NULL,
	[SO] [int] NOT NULL,
	[SB] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Leagues]    Script Date: 8/19/2016 4:46:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leagues](
	[LeagueId] [int] NOT NULL,
	[LeagueName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PitchingStats]    Script Date: 8/19/2016 4:46:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PitchingStats](
	[PlayerId] [int] NOT NULL,
	[GP] [int] NOT NULL,
	[GS] [int] NOT NULL,
	[W] [int] NOT NULL,
	[L] [int] NOT NULL,
	[HLD] [int] NOT NULL,
	[SV] [int] NOT NULL,
	[IP] [decimal](5, 2) NOT NULL,
	[HitsAllowed] [int] NOT NULL,
	[ER] [int] NOT NULL,
	[K] [int] NOT NULL,
	[Walks] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Players]    Script Date: 8/19/2016 4:46:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[PlayerFirstName] [nvarchar](50) NOT NULL,
	[PlayerLastName] [nvarchar](50) NOT NULL,
	[PositionId] [int] NOT NULL,
	[JerseyNumber] [int] NOT NULL,
	[YearsPlayed] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 8/19/2016 4:46:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionId] [int] NOT NULL,
	[PositionTitle] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 8/19/2016 4:46:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [int] NOT NULL,
	[LeagueId] [int] NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
	[TeamCity] [nvarchar](50) NOT NULL,
	[Wins] [int] NOT NULL,
	[Losses] [int] NOT NULL
) ON [PRIMARY]

GO
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (2, 10, 36, 12, 1, 0, 4, 0, 8, 6, 12, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (3, 10, 40, 25, 1, 1, 13, 1, 9, 5, 10, 2)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (4, 10, 39, 11, 3, 0, 5, 3, 10, 1, 20, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (5, 10, 40, 18, 2, 1, 10, 1, 13, 4, 8, 1)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (6, 10, 38, 8, 0, 0, 6, 0, 3, 10, 2, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (7, 10, 43, 11, 2, 0, 8, 1, 3, 6, 10, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (8, 10, 39, 15, 2, 0, 12, 0, 10, 5, 6, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (9, 10, 38, 5, 0, 0, 1, 4, 17, 0, 21, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (11, 10, 39, 10, 2, 0, 6, 1, 2, 6, 11, 2)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (12, 10, 37, 18, 4, 0, 14, 3, 7, 11, 8, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (13, 10, 41, 12, 0, 0, 8, 0, 7, 4, 9, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (20, 10, 45, 17, 2, 1, 10, 1, 7, 8, 13, 2)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (21, 10, 44, 15, 2, 0, 10, 0, 11, 8, 9, 1)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (22, 10, 40, 11, 0, 0, 8, 0, 8, 10, 15, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (23, 10, 41, 13, 1, 0, 10, 5, 15, 4, 19, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (24, 10, 39, 8, 0, 0, 5, 2, 7, 9, 12, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (25, 10, 39, 9, 2, 0, 11, 0, 4, 12, 7, 1)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (26, 10, 36, 14, 1, 1, 8, 1, 10, 7, 9, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (27, 10, 38, 9, 0, 0, 6, 0, 9, 6, 8, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (29, 10, 38, 5, 0, 0, 2, 0, 1, 6, 16, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (30, 10, 39, 13, 1, 0, 10, 2, 9, 8, 11, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (31, 10, 36, 8, 1, 0, 6, 1, 3, 11, 4, 1)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (32, 10, 38, 15, 3, 0, 7, 1, 10, 8, 12, 1)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (33, 10, 40, 19, 1, 1, 12, 3, 15, 8, 5, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (34, 10, 39, 12, 2, 0, 5, 2, 11, 9, 12, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (35, 10, 39, 9, 0, 0, 6, 0, 4, 7, 11, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (36, 10, 37, 13, 2, 0, 11, 0, 8, 9, 9, 1)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (14, 10, 39, 14, 2, 0, 9, 2, 10, 10, 15, 1)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (15, 10, 42, 9, 1, 0, 3, 0, 2, 9, 11, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (16, 10, 40, 14, 5, 0, 7, 1, 12, 10, 8, 0)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (17, 10, 37, 10, 2, 0, 6, 0, 6, 10, 3, 1)
INSERT [dbo].[HittingStats] ([PlayerId], [GP], [AB], [Hits], [Doubles], [Triples], [R], [HR], [RBI], [BB], [SO], [SB]) VALUES (18, 10, 38, 17, 1, 0, 7, 2, 10, 6, 16, 0)
INSERT [dbo].[Leagues] ([LeagueId], [LeagueName]) VALUES (1, N'Eastern')
INSERT [dbo].[Leagues] ([LeagueId], [LeagueName]) VALUES (2, N'Western')
INSERT [dbo].[PitchingStats] ([PlayerId], [GP], [GS], [W], [L], [HLD], [SV], [IP], [HitsAllowed], [ER], [K], [Walks]) VALUES (1, 5, 5, 3, 1, 0, 0, CAST(30.33 AS Decimal(5, 2)), 20, 10, 28, 14)
INSERT [dbo].[PitchingStats] ([PlayerId], [GP], [GS], [W], [L], [HLD], [SV], [IP], [HitsAllowed], [ER], [K], [Walks]) VALUES (10, 7, 2, 3, 4, 0, 0, CAST(24.67 AS Decimal(5, 2)), 19, 15, 25, 23)
INSERT [dbo].[PitchingStats] ([PlayerId], [GP], [GS], [W], [L], [HLD], [SV], [IP], [HitsAllowed], [ER], [K], [Walks]) VALUES (19, 6, 6, 5, 0, 0, 0, CAST(36.00 AS Decimal(5, 2)), 21, 8, 39, 10)
INSERT [dbo].[PitchingStats] ([PlayerId], [GP], [GS], [W], [L], [HLD], [SV], [IP], [HitsAllowed], [ER], [K], [Walks]) VALUES (28, 6, 5, 1, 3, 0, 0, CAST(25.00 AS Decimal(5, 2)), 30, 21, 26, 21)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (1, 1, N'Sammy', N'Serverside', 1, 11, 27)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (2, 1, N'Billy', N'Bitflag', 9, 99, 1)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (3, 1, N'Jonny', N'Javascript', 8, 33, 3)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (4, 1, N'Andy', N'Angular', 7, 8, 1)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (5, 1, N'Ronnie', N'Roids', 6, 17, 9)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (6, 1, N'Dylan', N'Deadlock', 5, 5, 5)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (7, 1, N'Henry', N'Hypertext', 4, 19, 2)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (8, 1, N'Olli', N'Object', 3, 43, 12)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (9, 1, N'Desmond', N'Database', 2, 23, 5)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (10, 2, N'John', N'Davidson', 1, 23, 1)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (11, 2, N'David', N'Johnson', 9, 14, NULL)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (12, 2, N'Bob', N'McRoberts', 8, 22, 15)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (13, 2, N'Robert', N'McBob', 7, 3, NULL)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (14, 2, N'George', N'Red', 6, 7, 6)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (19, 3, N'Brent', N'Broccoli', 1, 33, 2)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (20, 3, N'Chris', N'Cauliflowerr', 2, 28, 2)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (21, 3, N'Edwin', N'Eggplant', 3, 19, 3)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (22, 3, N'Pauly', N'Pepper', 4, 21, 15)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (23, 3, N'Curtis', N'Cucumber', 5, 30, 9)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (24, 3, N'Zach', N'Zucchini', 6, 31, 3)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (25, 3, N'Lance', N'Lettuce', 7, 18, NULL)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (26, 3, N'Cedric', N'Celery', 8, 17, 2)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (27, 3, N'Connor ', N'Carrot', 9, 40, 5)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (28, 4, N'Mario', N'McDonalds', 1, 15, 4)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (29, 4, N'Bubba', N'Burgerking', 2, 23, 1)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (30, 4, N'Antoine', N'Arbys', 3, 12, 15)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (31, 4, N'Sandoval', N'Sonic', 4, 7, 3)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (32, 4, N'Trevor', N'Tacobell', 5, 13, 5)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (33, 4, N'Larry', N'Longjohnsilvers', 6, 10, NULL)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (34, 4, N'Pedro', N'Pizzahut', 7, 51, 3)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (35, 4, N'Chester', N'Chickfillet', 8, 9, 4)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (36, 4, N'Saul', N'Subway', 9, 21, 9)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (15, 2, N'Ali', N'Green', 5, 31, 10)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (16, 2, N'Scott', N'White', 4, 6, 1)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (17, 2, N'Gregory', N'Black', 3, 24, 6)
INSERT [dbo].[Players] ([PlayerId], [TeamId], [PlayerFirstName], [PlayerLastName], [PositionId], [JerseyNumber], [YearsPlayed]) VALUES (18, 2, N'Patrick', N'Grey', 2, 13, 2)
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (1, N'Pitcher')
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (2, N'Catcher')
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (3, N'First Base')
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (4, N'Second Base')
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (5, N'Short Stop')
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (6, N'Third Base')
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (7, N'Left Field')
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (8, N'Center Field')
INSERT [dbo].[Positions] ([PositionId], [PositionTitle]) VALUES (9, N'Right Field')
INSERT [dbo].[Teams] ([TeamId], [LeagueId], [TeamName], [TeamCity], [Wins], [Losses]) VALUES (1, 1, N'Alliterations', N'Avon Lake', 5, 5)
INSERT [dbo].[Teams] ([TeamId], [LeagueId], [TeamName], [TeamCity], [Wins], [Losses]) VALUES (2, 1, N'Zebras', N'Akron', 6, 4)
INSERT [dbo].[Teams] ([TeamId], [LeagueId], [TeamName], [TeamCity], [Wins], [Losses]) VALUES (3, 2, N'Hummingbirds', N'Hudson', 4, 6)
INSERT [dbo].[Teams] ([TeamId], [LeagueId], [TeamName], [TeamCity], [Wins], [Losses]) VALUES (4, 2, N'Guitarists', N'Cleveland ', 5, 5)
/****** Object:  StoredProcedure [dbo].[GetAllPlayersStatsFromATeam]    Script Date: 8/19/2016 4:46:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--creating a stored procedure to take in a team name and display all the players stats
CREATE procedure [dbo].[GetAllPlayersStatsFromATeam]
(
	@TeamName nvarchar(50)
)as

select *
from HittingStats
	right outer join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId
					left outer join PitchingStats
						on Players.PlayerId = PitchingStats.PlayerId
where Teams.TeamName = @TeamName

GO
USE [master]
GO
ALTER DATABASE [BaseballLeague] SET  READ_WRITE 
GO
