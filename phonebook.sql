USE [master]
GO
/****** Object:  Database [phonebook]    Script Date: 05/04/2014 12:11:59 ******/
CREATE DATABASE [phonebook] ON  PRIMARY 
( NAME = N'phonebook', FILENAME = N'E:\新建文件夹 (3)\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\phonebook.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'phonebook_log', FILENAME = N'E:\新建文件夹 (3)\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\phonebook_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [phonebook] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [phonebook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [phonebook] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [phonebook] SET ANSI_NULLS OFF
GO
ALTER DATABASE [phonebook] SET ANSI_PADDING OFF
GO
ALTER DATABASE [phonebook] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [phonebook] SET ARITHABORT OFF
GO
ALTER DATABASE [phonebook] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [phonebook] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [phonebook] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [phonebook] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [phonebook] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [phonebook] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [phonebook] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [phonebook] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [phonebook] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [phonebook] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [phonebook] SET  DISABLE_BROKER
GO
ALTER DATABASE [phonebook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [phonebook] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [phonebook] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [phonebook] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [phonebook] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [phonebook] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [phonebook] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [phonebook] SET  READ_WRITE
GO
ALTER DATABASE [phonebook] SET RECOVERY FULL
GO
ALTER DATABASE [phonebook] SET  MULTI_USER
GO
ALTER DATABASE [phonebook] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [phonebook] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'phonebook', N'ON'
GO
USE [phonebook]
GO
/****** Object:  Role [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess]    Script Date: 05/04/2014 12:11:59 ******/
CREATE ROLE [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess]    Script Date: 05/04/2014 12:11:59 ******/
CREATE SCHEMA [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess] AUTHORIZATION [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess]
GO
/****** Object:  Table [dbo].[GroupInfo]    Script Date: 05/04/2014 12:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupInfo](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_GroupInfo] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GroupInfo] ON
INSERT [dbo].[GroupInfo] ([GroupId], [GroupName]) VALUES (1, N'老板')
INSERT [dbo].[GroupInfo] ([GroupId], [GroupName]) VALUES (2, N'朋友')
INSERT [dbo].[GroupInfo] ([GroupId], [GroupName]) VALUES (3, N'亲人')
INSERT [dbo].[GroupInfo] ([GroupId], [GroupName]) VALUES (4, N'同事')
INSERT [dbo].[GroupInfo] ([GroupId], [GroupName]) VALUES (5, N'其他')
INSERT [dbo].[GroupInfo] ([GroupId], [GroupName]) VALUES (209, N'八戒')
SET IDENTITY_INSERT [dbo].[GroupInfo] OFF
/****** Object:  Table [dbo].[AccountInfo]    Script Date: 05/04/2014 12:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](64) NULL,
	[AccountName] [nvarchar](50) NULL,
	[Pwd] [nvarchar](50) NULL,
 CONSTRAINT [PK_AccountInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountInfo] ON
INSERT [dbo].[AccountInfo] ([ID], [Account], [AccountName], [Pwd]) VALUES (1, N'wl', N'王林', N'E10ADC3949BA59ABBE56E057F20F883E')
SET IDENTITY_INSERT [dbo].[AccountInfo] OFF
/****** Object:  Table [dbo].[AspNet_SqlCacheTablesForChangeNotification]    Script Date: 05/04/2014 12:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNet_SqlCacheTablesForChangeNotification](
	[tableName] [nvarchar](450) NOT NULL,
	[notificationCreated] [datetime] NOT NULL,
	[changeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tableName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNet_SqlCacheTablesForChangeNotification] ([tableName], [notificationCreated], [changeId]) VALUES (N'ContactInfo', CAST(0x0000A23A0016AE97 AS DateTime), 112)
/****** Object:  Table [dbo].[ContactInGroup]    Script Date: 05/04/2014 12:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactInGroup](
	[Id] [varchar](128) NOT NULL,
	[Account] [nvarchar](64) NOT NULL,
	[GroupNumber] [nvarchar](16) NOT NULL,
	[ContactId] [varchar](128) NOT NULL,
	[IsDelete] [int] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_ContactInGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_ContactInGroup] ON [dbo].[ContactInGroup] 
(
	[GroupNumber] ASC,
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ContactInGroup_IsDelete] ON [dbo].[ContactInGroup] 
(
	[IsDelete] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[ContactInGroup] ([Id], [Account], [GroupNumber], [ContactId], [IsDelete], [UpdateTime]) VALUES (N'1', N'json', N'A001', N'1', 0, NULL)
INSERT [dbo].[ContactInGroup] ([Id], [Account], [GroupNumber], [ContactId], [IsDelete], [UpdateTime]) VALUES (N'2', N'json', N'A001', N'2', 0, NULL)
/****** Object:  Table [dbo].[ContactInfo]    Script Date: 05/04/2014 12:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [nvarchar](128) NOT NULL,
	[IsDelete] [int] NOT NULL,
	[Account] [nvarchar](64) NOT NULL,
	[ContactName] [nvarchar](50) NOT NULL,
	[CommonMobile] [nvarchar](50) NULL,
	[HeadPortrait] [nvarchar](256) NULL,
	[AttFile] [nvarchar](256) NULL,
	[GroupId] [int] NULL,
 CONSTRAINT [PK_ContactInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_GroupInfoId] ON [dbo].[ContactInfo] 
(
	[GroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ContactInfo] ON
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (1, N'11111111', 1, N'马云123456', N'aa', N'123123', NULL, NULL, 209)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (2, N'a0002', 1, N'wl', N'vvvvv', N'138999999983232', N'3a5abdda-3f64-4b22-8c0c-f7f649a83488.gif', N'1.AVI', 4)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (3, N'a0003', 1, N'wl', N'马化腾', N'13899999998', N'0bf05368-0078-448f-82f8-cd31a4e71cd2.jpg', N'shiyuzhu.txt', 2)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (4, N'a0003', 1, N'wl', N'aaaaaw', N'13899999998', N'20130903151439_a0003.png', N'shiyuzhu.txt', 3)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (5, N'a0003', 0, N'wl', N'潘石', N'13899999998', N'c6ce6306-ff16-4e39-a045-b696d44515f9.gif', N'shiyuzhu.txt', 1)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (6, N'a0003', 0, N'wl', N'小米老总', N'13899999998', N'13f028e0-b536-4159-8ed9-2ff41a1444a1.jpg', N'shiyuzhu.txt', 1)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (7, N'a0003', 0, N'wl', N'薛蛮子', N'13899999997', N'20130903151439_a0003.png', N'shiyuzhu.txt', 1)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (8, N'a0003', 0, N'wl', N'李天一1', N'13899999998', N'6e912458-6d59-4ad7-a68d-886d529c6b5a.jpg', N'', 5)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (9, N'a0003', 0, N'wl', N'李刚', N'13899999998', N'1bfdf6d4-75f3-4bf7-8c10-c0594d2c8580.jpg', N'mahuateng.txt', 1)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (10, N'a0003', 0, N'wl', N'csdn老总', N'13899999998', N'7f52b778-ac66-43a1-a50b-6b0e54524c1d.jpg', N'mahuateng.txt', 1)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (11, N'a00034', 0, N'wl', N'hh', N'13899999998', N'20130903151439_a0003.png', N'mahuateng.txt', 2)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (12, N'a0003', 0, N'wl', N'yy11', N'13899999998', N'20130903151439_a0003.png', N'mahuateng.txt', 1)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (13, N'a0003', 0, N'wl', N'kkeeeewwer', N'13899999998', N'20130903151439_a0003.png', N'mahuateng.txt', 1)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (16, N'a0001', 0, N'Wl', N'小蛮腰', N'13899999999', N'', N'', 5)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (17, N'0002', 0, N'wl', N'jkljlkjlkjlk', N'123123', NULL, NULL, 1)
INSERT [dbo].[ContactInfo] ([ID], [ContactId], [IsDelete], [Account], [ContactName], [CommonMobile], [HeadPortrait], [AttFile], [GroupId]) VALUES (18, N'0002', 1, N'wl', N'aa', N'1241241241', NULL, NULL, 209)
SET IDENTITY_INSERT [dbo].[ContactInfo] OFF
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheUpdateChangeIdStoredProcedure]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCacheUpdateChangeIdStoredProcedure] 
             @tableName NVARCHAR(450) 
         AS

         BEGIN 
             UPDATE dbo.AspNet_SqlCacheTablesForChangeNotification WITH (ROWLOCK) SET changeId = changeId + 1 
             WHERE tableName = @tableName
         END
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheUnRegisterTableStoredProcedure]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCacheUnRegisterTableStoredProcedure] 
             @tableName NVARCHAR(450) 
         AS
         BEGIN

         BEGIN TRAN
         DECLARE @triggerName AS NVARCHAR(3000) 
         DECLARE @fullTriggerName AS NVARCHAR(3000)
         SET @triggerName = REPLACE(@tableName, '[', '__o__') 
         SET @triggerName = REPLACE(@triggerName, ']', '__c__') 
         SET @triggerName = @triggerName + '_AspNet_SqlCacheNotification_Trigger' 
         SET @fullTriggerName = 'dbo.[' + @triggerName + ']' 

         /* Remove the table-row from the notification table */ 
         IF EXISTS (SELECT name FROM sysobjects WITH (NOLOCK) WHERE name = 'AspNet_SqlCacheTablesForChangeNotification' AND type = 'U') 
             IF EXISTS (SELECT name FROM sysobjects WITH (TABLOCKX) WHERE name = 'AspNet_SqlCacheTablesForChangeNotification' AND type = 'U') 
             DELETE FROM dbo.AspNet_SqlCacheTablesForChangeNotification WHERE tableName = @tableName 

         /* Remove the trigger */ 
         IF EXISTS (SELECT name FROM sysobjects WITH (NOLOCK) WHERE name = @triggerName AND type = 'TR') 
             IF EXISTS (SELECT name FROM sysobjects WITH (TABLOCKX) WHERE name = @triggerName AND type = 'TR') 
             EXEC('DROP TRIGGER ' + @fullTriggerName) 

         COMMIT TRAN
         END
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheRegisterTableStoredProcedure]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCacheRegisterTableStoredProcedure] 
             @tableName NVARCHAR(450) 
         AS
         BEGIN

         DECLARE @triggerName AS NVARCHAR(3000) 
         DECLARE @fullTriggerName AS NVARCHAR(3000)
         DECLARE @canonTableName NVARCHAR(3000) 
         DECLARE @quotedTableName NVARCHAR(3000) 

         /* Create the trigger name */ 
         SET @triggerName = REPLACE(@tableName, '[', '__o__') 
         SET @triggerName = REPLACE(@triggerName, ']', '__c__') 
         SET @triggerName = @triggerName + '_AspNet_SqlCacheNotification_Trigger' 
         SET @fullTriggerName = 'dbo.[' + @triggerName + ']' 

         /* Create the cannonicalized table name for trigger creation */ 
         /* Do not touch it if the name contains other delimiters */ 
         IF (CHARINDEX('.', @tableName) <> 0 OR 
             CHARINDEX('[', @tableName) <> 0 OR 
             CHARINDEX(']', @tableName) <> 0) 
             SET @canonTableName = @tableName 
         ELSE 
             SET @canonTableName = '[' + @tableName + ']' 

         /* First make sure the table exists */ 
         IF (SELECT OBJECT_ID(@tableName, 'U')) IS NULL 
         BEGIN 
             RAISERROR ('00000001', 16, 1) 
             RETURN 
         END 

         BEGIN TRAN
         /* Insert the value into the notification table */ 
         IF NOT EXISTS (SELECT tableName FROM dbo.AspNet_SqlCacheTablesForChangeNotification WITH (NOLOCK) WHERE tableName = @tableName) 
             IF NOT EXISTS (SELECT tableName FROM dbo.AspNet_SqlCacheTablesForChangeNotification WITH (TABLOCKX) WHERE tableName = @tableName) 
                 INSERT  dbo.AspNet_SqlCacheTablesForChangeNotification 
                 VALUES (@tableName, GETDATE(), 0)

         /* Create the trigger */ 
         SET @quotedTableName = QUOTENAME(@tableName, '''') 
         IF NOT EXISTS (SELECT name FROM sysobjects WITH (NOLOCK) WHERE name = @triggerName AND type = 'TR') 
             IF NOT EXISTS (SELECT name FROM sysobjects WITH (TABLOCKX) WHERE name = @triggerName AND type = 'TR') 
                 EXEC('CREATE TRIGGER ' + @fullTriggerName + ' ON ' + @canonTableName +'
                       FOR INSERT, UPDATE, DELETE AS BEGIN
                       SET NOCOUNT ON
                       EXEC dbo.AspNet_SqlCacheUpdateChangeIdStoredProcedure N' + @quotedTableName + '
                       END
                       ')
         COMMIT TRAN
         END
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheQueryRegisteredTablesStoredProcedure]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCacheQueryRegisteredTablesStoredProcedure] 
         AS
         SELECT tableName FROM dbo.AspNet_SqlCacheTablesForChangeNotification
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCachePollingStoredProcedure]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCachePollingStoredProcedure] AS
         SELECT tableName, changeId FROM dbo.AspNet_SqlCacheTablesForChangeNotification
         RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_AspNet_SqlCacheTablesForChangeNotificationEntity]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：IVAN
--时间：2013/9/15
-------------------------------------------------------------
--存储过程的功能：对表 AspNet_SqlCacheTablesForChangeNotification 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@tableName  
@notificationCreated   
@changeId   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_AspNet_SqlCacheTablesForChangeNotificationEntity]
	@DataAction int,
	@tableName nvarchar(450) = 0,
	@notificationCreated datetime,
	@changeId int
AS
 if @DataAction=0
begin
	insert into AspNet_SqlCacheTablesForChangeNotification
	(
		[notificationCreated],
		[changeId]
	) 
	values
	(
		@notificationCreated,
		@changeId
	)
	set 
		@tableName=scope_identity()
end
if @DataAction=1
begin
	UPDATE [AspNet_SqlCacheTablesForChangeNotification] SET
		[notificationCreated] = @notificationCreated,
		[changeId] = @changeId
	WHERE
		
		[tableName] = @tableName
end
if @DataAction=2
begin
	delete from [AspNet_SqlCacheTablesForChangeNotification] where  [tableName] = @tableName
end
select @tableName
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_AccountInfoEntity]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：IVAN
--时间：2013/9/15
-------------------------------------------------------------
--存储过程的功能：对表 AccountInfo 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@Account   
@AccountName   
@Pwd   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_AccountInfoEntity]
	@DataAction int,
	@ID int = 0,
	@Account nvarchar(64),
	@AccountName nvarchar(50),
	@Pwd nvarchar(50)
AS
 if @DataAction=0
begin
	insert into AccountInfo
	(
		[Account],
		[AccountName],
		[Pwd]
	) 
	values
	(
		@Account,
		@AccountName,
		@Pwd
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [AccountInfo] SET
		[Account] = @Account,
		[AccountName] = @AccountName,
		[Pwd] = @Pwd
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [AccountInfo] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_GroupInfoEntity]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：IVAN
--时间：2013/9/15
-------------------------------------------------------------
--存储过程的功能：对表 GroupInfo 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@GroupId  
@GroupName   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_GroupInfoEntity]
	@DataAction int,
	@GroupId int = 0,
	@GroupName nvarchar(300)
AS
 if @DataAction=0
begin
	insert into GroupInfo
	(
		[GroupName]
	) 
	values
	(
		@GroupName
	)
	set 
		@GroupId=scope_identity()
end
if @DataAction=1
begin
	UPDATE [GroupInfo] SET
		[GroupName] = @GroupName
	WHERE
		
		[GroupId] = @GroupId
end
if @DataAction=2
begin
	delete from [GroupInfo] where  [GroupId] = @GroupId
end
select @GroupId
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_ContactInGroupEntity]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：IVAN
--时间：2013/9/15
-------------------------------------------------------------
--存储过程的功能：对表 ContactInGroup 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@Id  
@Account   
@GroupNumber   
@ContactId   
@IsDelete   
@UpdateTime   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_ContactInGroupEntity]
	@DataAction int,
	@Id varchar(128) = 0,
	@Account nvarchar(64),
	@GroupNumber nvarchar(16),
	@ContactId varchar(128),
	@IsDelete int,
	@UpdateTime datetime
AS
 if @DataAction=0
begin
	insert into ContactInGroup
	(
		[Account],
		[GroupNumber],
		[ContactId],
		[IsDelete],
		[UpdateTime]
	) 
	values
	(
		@Account,
		@GroupNumber,
		@ContactId,
		@IsDelete,
		@UpdateTime
	)
	set 
		@Id=scope_identity()
end
if @DataAction=1
begin
	UPDATE [ContactInGroup] SET
		[Account] = @Account,
		[GroupNumber] = @GroupNumber,
		[ContactId] = @ContactId,
		[IsDelete] = @IsDelete,
		[UpdateTime] = @UpdateTime
	WHERE
		
		[Id] = @Id
end
if @DataAction=2
begin
	delete from [ContactInGroup] where  [Id] = @Id
end
select @Id
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAllContact8]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_GetAllContact8]
	@pageIndex int, --当前索引号
	@pageSize int, --当前每页显示的行数
	@totalCount int out  --当前联系人表中有效的总行数 isdelet=0	
AS
BEGIN
	
	SET NOCOUNT ON;
	
	--先定义开始和结束索引并
	declare @startindex int,@endindex int
	--赋值
	set @startindex=(@pageIndex-1)*@pageSize;
	set @endindex=@pageIndex*@pageSize;
	
	--分页逻辑
	select * from (
	select row=ROW_NUMBER() over(order by ID desc), * from ContactInfo where IsDelete=0	
	) as t
	where t.row>@startindex and t.row<=@endindex
	
	--得到总行数
	select @totalCount=COUNT(1) from ContactInfo where IsDelete=0

END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAllContact_old]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetAllContact_old]
( 
	@pageIndex int,
	@pageSize int,
	@totalCount int out
)
AS
BEGIN

declare @startIndex int ,@endIndex int

set @startIndex=(@pageIndex-1)*@pageSize;
set @endIndex=@pageIndex*@pageSize;

select * from (
 select row= ROW_NUMBER() over(order by c.ID desc)
		,[ID]
      ,[ContactId]
      ,[IsDelete]
      ,[Account]
      ,[ContactName]
      ,[CommonMobile]
      ,[HeadPortrait]
      ,[GroupId]
  from dbo.ContactInfo c
  where c.IsDelete=0
  ) as t
  where t.row>@startIndex and t.row<=@endIndex
  
  select @totalCount=COUNT(1) from ContactInfo  where IsDelete=0
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAllContact_1]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetAllContact_1]
	@pageIndex int, --页码
	@pageSize int, --每页显示的条数
	@totalCount int out	 --当前表ContactInfo的数据总行数，是输出参数，在asp。net调用的时候可以通过参数拿到
AS
BEGIN

declare @startNum int  --定义起始索引数字
,@endNum int--定义结束索引数字
set @startNum=(@pageIndex-1)*@pageSize; -- 给起始索引数字赋值
set @endNum=@pageIndex*@pageSize; -- 给结束索引数字赋值

--根据起始索引数字和结束索引数字获取当前分页数据
select * from (
--根据函数ROW_NUMBER() over(order by ID desc) 定义row 逻辑排序字段
select row=ROW_NUMBER() over(order by ID desc),* from ContactInfo where IsDelete=0
) as t
where t.row>@startNum and t.row<=@endNum

--得到表ContactInfo的总条数 赋值给输出参数@totalCount
select  @totalCount=COUNT(1) from ContactInfo  where IsDelete=0
	
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAllContact]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetAllContact]
	--编写输入参数区域
	@pageIndex int,
	@pageSize int,
	@totalCount int out
AS
BEGIN
--编写主体逻辑sql语句
--1 计算出开始结束索引值
declare @startIndex int,@endIndex int
set @startIndex=(@pageIndex-1)*@pageSize;  --给开始索引赋值
set @endIndex = @pageIndex*@pageSize;--给结束索引赋值
--2 根据row来筛选分页数据
select * from (
-- 2.1根据ID倒序来生成逻辑编号 row
select row=ROW_NUMBER() over(order by ID desc),* from dbo.ContactInfo where IsDelete=0
) as tmp
where tmp.row>@startIndex and tmp.row<=@endIndex

-- 3 给@totalCount赋值
select @totalCount=COUNT(1) from dbo.ContactInfo where IsDelete=0

END
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_ContactInfoEntity]    Script Date: 05/04/2014 12:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：IVAN
--时间：2013/9/15
-------------------------------------------------------------
--存储过程的功能：对表 ContactInfo 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@ContactId   
@IsDelete   
@Account   
@ContactName   
@CommonMobile   
@HeadPortrait   
@AttFile   
@GroupId   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_ContactInfoEntity]
	@DataAction int,
	@ID int = 0,
	@ContactId nvarchar(128),
	@IsDelete int,
	@Account nvarchar(64),
	@ContactName nvarchar(50),
	@CommonMobile nvarchar(50),
	@HeadPortrait nvarchar(256),
	@AttFile nvarchar(256),
	@GroupId int
AS
 if @DataAction=0
begin
	insert into ContactInfo
	(
		[ContactId],
		[IsDelete],
		[Account],
		[ContactName],
		[CommonMobile],
		[HeadPortrait],
		[AttFile],
		[GroupId]
	) 
	values
	(
		@ContactId,
		@IsDelete,
		@Account,
		@ContactName,
		@CommonMobile,
		@HeadPortrait,
		@AttFile,
		@GroupId
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [ContactInfo] SET
		[ContactId] = @ContactId,
		[IsDelete] = @IsDelete,
		[Account] = @Account,
		[ContactName] = @ContactName,
		[CommonMobile] = @CommonMobile,
		[HeadPortrait] = @HeadPortrait,
		[AttFile] = @AttFile,
		[GroupId] = @GroupId
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [ContactInfo] where  [ID] = @ID
end
select @ID
GO
/****** Object:  Default [DF__AspNet_Sq__notif__173876EA]    Script Date: 05/04/2014 12:12:01 ******/
ALTER TABLE [dbo].[AspNet_SqlCacheTablesForChangeNotification] ADD  DEFAULT (getdate()) FOR [notificationCreated]
GO
/****** Object:  Default [DF__AspNet_Sq__chang__182C9B23]    Script Date: 05/04/2014 12:12:01 ******/
ALTER TABLE [dbo].[AspNet_SqlCacheTablesForChangeNotification] ADD  DEFAULT ((0)) FOR [changeId]
GO
/****** Object:  Default [DF_ContactInGroup_IsDelete]    Script Date: 05/04/2014 12:12:01 ******/
ALTER TABLE [dbo].[ContactInGroup] ADD  CONSTRAINT [DF_ContactInGroup_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_Contact_IsDelete]    Script Date: 05/04/2014 12:12:01 ******/
ALTER TABLE [dbo].[ContactInfo] ADD  CONSTRAINT [DF_Contact_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  ForeignKey [FK_ContactInfo_GroupInfo]    Script Date: 05/04/2014 12:12:01 ******/
ALTER TABLE [dbo].[ContactInfo]  WITH CHECK ADD  CONSTRAINT [FK_ContactInfo_GroupInfo] FOREIGN KEY([GroupId])
REFERENCES [dbo].[GroupInfo] ([GroupId])
GO
ALTER TABLE [dbo].[ContactInfo] CHECK CONSTRAINT [FK_ContactInfo_GroupInfo]
GO
