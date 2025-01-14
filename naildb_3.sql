USE [master]
GO
/****** Object:  Database [NailDB]    Script Date: 27.12.2023 1:39:48 ******/
CREATE DATABASE [NailDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NailDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NailDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NailDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NailDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NailDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NailDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NailDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NailDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NailDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NailDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NailDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NailDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NailDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NailDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NailDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NailDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NailDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NailDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NailDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NailDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NailDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NailDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NailDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NailDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NailDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NailDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NailDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NailDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NailDB] SET RECOVERY FULL 
GO
ALTER DATABASE [NailDB] SET  MULTI_USER 
GO
ALTER DATABASE [NailDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NailDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NailDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NailDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NailDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NailDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NailDB', N'ON'
GO
ALTER DATABASE [NailDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [NailDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NailDB]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[RoleId] [int] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[BornDate] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Master]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AccountId] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterHasClient]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterHasClient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MasterId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_MasterHasClient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ClientList]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ClientList]
AS
SELECT        dbo.[User].FirstName, dbo.[User].LastName, dbo.[User].MiddleName, dbo.MasterHasClient.Date, dbo.Service.Value AS Service, dbo.Service.Price, dbo.Client.Id AS ClientId, dbo.Master.Id AS MasterId, 
                         dbo.Service.Id AS ServiceId, dbo.[User].Id AS UserId, dbo.MasterHasClient.Id
FROM            dbo.Client INNER JOIN
                         dbo.[User] ON dbo.Client.UserId = dbo.[User].Id INNER JOIN
                         dbo.Service INNER JOIN
                         dbo.MasterHasClient ON dbo.Service.Id = dbo.MasterHasClient.ServiceId INNER JOIN
                         dbo.Master ON dbo.MasterHasClient.MasterId = dbo.Master.Id ON dbo.Client.Id = dbo.MasterHasClient.ClientId
GO
/****** Object:  View [dbo].[MasterList]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MasterList]
AS
SELECT        dbo.Client.Id AS ClientId, dbo.[User].FirstName, dbo.[User].LastName, dbo.[User].MiddleName, dbo.Service.Value, dbo.Service.Price, dbo.Service.Id AS ServiceId, 
                         dbo.MasterHasClient.Date, dbo.Master.Id AS MasterId
FROM            dbo.Master INNER JOIN
                         dbo.[User] ON dbo.Master.UserId = dbo.[User].Id INNER JOIN
                         dbo.Client INNER JOIN
                         dbo.MasterHasClient ON dbo.Client.Id = dbo.MasterHasClient.ClientId ON dbo.Master.Id = dbo.MasterHasClient.MasterId INNER JOIN
                         dbo.Service ON dbo.MasterHasClient.ServiceId = dbo.Service.Id
GO
/****** Object:  Table [dbo].[Account]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 27.12.2023 1:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [Login], [Password]) VALUES (1, N'master', N'master')
INSERT [dbo].[Account] ([Id], [Login], [Password]) VALUES (2, N'sama', N'sama')
INSERT [dbo].[Account] ([Id], [Login], [Password]) VALUES (3, N'g', N'g')
INSERT [dbo].[Account] ([Id], [Login], [Password]) VALUES (4, N'oo', N'o')
INSERT [dbo].[Account] ([Id], [Login], [Password]) VALUES (5, N'i', N'i')
INSERT [dbo].[Account] ([Id], [Login], [Password]) VALUES (6, N'i', N'i')
INSERT [dbo].[Account] ([Id], [Login], [Password]) VALUES (7, N'dd', N'dd')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [UserId]) VALUES (1, 1)
INSERT [dbo].[Client] ([Id], [UserId]) VALUES (2, 8)
INSERT [dbo].[Client] ([Id], [UserId]) VALUES (3, 9)
INSERT [dbo].[Client] ([Id], [UserId]) VALUES (4, 10)
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Master] ON 

INSERT [dbo].[Master] ([Id], [UserId], [AccountId]) VALUES (1, 2, 1)
INSERT [dbo].[Master] ([Id], [UserId], [AccountId]) VALUES (2, 3, 2)
INSERT [dbo].[Master] ([Id], [UserId], [AccountId]) VALUES (1005, 7, 6)
INSERT [dbo].[Master] ([Id], [UserId], [AccountId]) VALUES (1006, 11, 7)
SET IDENTITY_INSERT [dbo].[Master] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterHasClient] ON 

INSERT [dbo].[MasterHasClient] ([Id], [MasterId], [ClientId], [ServiceId], [Date]) VALUES (1, 1, 1, 2, CAST(N'2023-10-10T10:10:00.000' AS DateTime))
INSERT [dbo].[MasterHasClient] ([Id], [MasterId], [ClientId], [ServiceId], [Date]) VALUES (3, 1, 1, 2, CAST(N'2023-10-11T10:10:00.000' AS DateTime))
INSERT [dbo].[MasterHasClient] ([Id], [MasterId], [ClientId], [ServiceId], [Date]) VALUES (4, 1, 2, 2, CAST(N'2023-10-11T12:10:00.000' AS DateTime))
INSERT [dbo].[MasterHasClient] ([Id], [MasterId], [ClientId], [ServiceId], [Date]) VALUES (5, 1, 3, 3, CAST(N'2023-10-10T14:10:00.000' AS DateTime))
INSERT [dbo].[MasterHasClient] ([Id], [MasterId], [ClientId], [ServiceId], [Date]) VALUES (10, 1, 3, 2, CAST(N'2023-12-27T12:30:00.000' AS DateTime))
INSERT [dbo].[MasterHasClient] ([Id], [MasterId], [ClientId], [ServiceId], [Date]) VALUES (11, 1, 2, 2, CAST(N'2023-12-27T23:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[MasterHasClient] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Value]) VALUES (1, N'Клиент')
INSERT [dbo].[Role] ([Id], [Value]) VALUES (2, N'Мастер')
INSERT [dbo].[Role] ([Id], [Value]) VALUES (3, N'Админ')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [Value], [Price]) VALUES (1, N'Маникюр', 500.0000)
INSERT [dbo].[Service] ([Id], [Value], [Price]) VALUES (2, N'Наращивание', 1000.0000)
INSERT [dbo].[Service] ([Id], [Value], [Price]) VALUES (3, N'Педикюр', 500.0000)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [RoleId], [Phone], [BornDate]) VALUES (1, N'Вероника', N'Мажарина', N'Александровна', 1, N'45544554', CAST(N'2010-10-10' AS Date))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [RoleId], [Phone], [BornDate]) VALUES (2, N'Екатерина', N'Швец', N'Алексеевна', 2, N'345345', CAST(N'2006-11-20' AS Date))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [RoleId], [Phone], [BornDate]) VALUES (3, N'Самира', N'Тугуз', N'Сальбиевна', 3, N'56556', CAST(N'2005-10-14' AS Date))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [RoleId], [Phone], [BornDate]) VALUES (7, N'Анна', N'Кленова', N'Васильева', 2, N'855547582111', CAST(N'2010-01-01' AS Date))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [RoleId], [Phone], [BornDate]) VALUES (8, N'Мария', N'Иванова', N'Ивановна', 1, N'89964005878', CAST(N'2023-12-24' AS Date))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [RoleId], [Phone], [BornDate]) VALUES (9, N'Ольга', N'Красноухова', N'Игоревна', 1, N'85559687444', CAST(N'2023-12-24' AS Date))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [RoleId], [Phone], [BornDate]) VALUES (10, N'Александра', N'Смирнова', N'Алексеевна', 1, N'83369685441', CAST(N'2023-12-24' AS Date))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [RoleId], [Phone], [BornDate]) VALUES (11, N'Алина', N'Смирнова', N'Викторовна', 2, N'84455741256', CAST(N'2023-12-24' AS Date))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
ALTER TABLE [dbo].[Master]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Master] CHECK CONSTRAINT [FK_Employee_User]
GO
ALTER TABLE [dbo].[Master]  WITH CHECK ADD  CONSTRAINT [FK_Master_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Master] CHECK CONSTRAINT [FK_Master_Account]
GO
ALTER TABLE [dbo].[MasterHasClient]  WITH CHECK ADD  CONSTRAINT [FK_MasterHasClient_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MasterHasClient] CHECK CONSTRAINT [FK_MasterHasClient_Client]
GO
ALTER TABLE [dbo].[MasterHasClient]  WITH CHECK ADD  CONSTRAINT [FK_MasterHasClient_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MasterHasClient] CHECK CONSTRAINT [FK_MasterHasClient_Service]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Client"
            Begin Extent = 
               Top = 102
               Left = 662
               Bottom = 197
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Service"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 118
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MasterHasClient"
            Begin Extent = 
               Top = 123
               Left = 300
               Bottom = 252
               Right = 470
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Master"
            Begin Extent = 
               Top = 162
               Left = 64
               Bottom = 257
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Service"
            Begin Extent = 
               Top = 102
               Left = 38
               Bottom = 214
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Client"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 101
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Master"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 101
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MasterHasClient"
            Begin Extent = 
               Top = 119
               Left = 459
               Bottom = 248
               Right = 629
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 135' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MasterList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'0
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MasterList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MasterList'
GO
USE [master]
GO
ALTER DATABASE [NailDB] SET  READ_WRITE 
GO
