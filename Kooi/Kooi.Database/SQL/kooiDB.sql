USE master
GO
-- Check if the database '[KooiDesign]' exists
IF DB_ID('KooiDesign') IS NOT NULL
BEGIN
    BEGIN TRY
        ALTER DATABASE [KooiDesign] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
        DROP DATABASE [KooiDesign];
        PRINT 'Database [KooiDesign] dropped successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error encountered while dropping the database.';
        THROW;  
        RETURN;  
    END CATCH
END

CREATE DATABASE [KooiDesign];
GO


USE [KooiDesign]
GO
CREATE TABLE [dbo].[Roles](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Name] [nvarchar](100) NOT NULL
);


-- Users table
CREATE TABLE [dbo].[Users](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [NetworkId] [nvarchar](200) NOT NULL,
    [FirstActive] [date] NOT NULL,
    [LastActive] [date] NOT NULL
);


-- AdminUsers table
CREATE TABLE [dbo].[AdminUsers](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Email] [nvarchar](200) NOT NULL,
    [FirebaseId] [nvarchar](50) NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [RoleId] [uniqueidentifier] NOT NULL,
    [Fullname] [nvarchar](200) NOT NULL,
    CONSTRAINT [FK_AdminUsers_Users] FOREIGN KEY([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_AdminUsers_Roles] FOREIGN KEY([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);


-- Alignments table
CREATE TABLE [dbo].[Alignments](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Name] [nvarchar](10) NOT NULL
);


-- Icons table
CREATE TABLE [dbo].[Icons](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Name] [nvarchar](200) NOT NULL,
    [SVG] [nvarchar](max) NOT NULL
);


-- Notifications table
CREATE TABLE [dbo].[Notifications](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Description] [nvarchar](max) NOT NULL,
    [StartDate] [date] NOT NULL,
    [EndDate] [date] NULL,
    [Required] [bit] NOT NULL
);


-- NotificationsUsers table
CREATE TABLE [dbo].[NotificationsUsers](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [UserId] [uniqueidentifier] NOT NULL,
    [NotificationId] [uniqueidentifier] NOT NULL,
    [Acknowledged] [bit] NOT NULL,
    [DateViewed] [date] NOT NULL,
    CONSTRAINT [FK_NotificationsUsers_Notifications] FOREIGN KEY([NotificationId]) REFERENCES [dbo].[Notifications] ([Id]),
    CONSTRAINT [FK_NotificationsUsers_Users] FOREIGN KEY([UserId]) REFERENCES [dbo].[Users] ([Id])
);


-- Routes table
CREATE TABLE [dbo].[Routes](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Uri] [nvarchar](200) NOT NULL
);


-- Sides table
CREATE TABLE [dbo].[Sides](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Name] [nvarchar](10) NOT NULL
);

CREATE TABLE [dbo].[ContentTypes](
     [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	 [Type] [nvarchar](100) NOT NULL   
);

-- Tooltips table
CREATE TABLE [dbo].[Tooltips](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[ContenTtypeId] [uniqueidentifier] NOT NULL,
    [Title] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NOT NULL,
    [ShowProgress] [bit] NOT NULL,
    [ProgressText] [nvarchar](100) NOT NULL,
    [NextBtnText] [nvarchar](50) NOT NULL,
    [PrevBtnText] [nvarchar](50) NOT NULL,
    [DoneBtnText] [nvarchar](50) NOT NULL
	CONSTRAINT [FK_Tooltips_ContentTypes] FOREIGN KEY([ContenTtypeId]) REFERENCES [dbo].[ContentTypes] ([Id])
);


-- TooltipInstructions table
CREATE TABLE [dbo].[TooltipInstructions](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [ElementIdentifier] [varchar](max) NOT NULL,
    [TooltipId] [uniqueidentifier] NOT NULL,
    [IconId] [uniqueidentifier] NOT NULL,
    [IconSideId] [uniqueidentifier] NOT NULL,
    [IconAlignId] [uniqueidentifier] NOT NULL,
    [RouteId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [FK_TooltipInstructions_Tooltips] FOREIGN KEY([TooltipId]) REFERENCES [dbo].[Tooltips] ([Id]),
    CONSTRAINT [FK_TooltipInstructions_Routes] FOREIGN KEY([RouteId]) REFERENCES [dbo].[Routes] ([Id]),
    CONSTRAINT [FK_TooltipInstructions_Sides] FOREIGN KEY([IconSideId]) REFERENCES [dbo].[Sides] ([Id])
);



-- Tours table
CREATE TABLE [dbo].[Tours](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Name] [nvarchar](200) NOT NULL,
    [RouteId] [uniqueidentifier] NOT NULL,
    [Required] [bit] NOT NULL,
    CONSTRAINT [FK_Tours_Routes] FOREIGN KEY([RouteId]) REFERENCES [dbo].[Routes] ([Id])
);

-- TourAuditLog table
CREATE TABLE [dbo].[TourAuditLog](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [TourId] [uniqueidentifier] NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [DateViewed] [date] NOT NULL,
    [Completed] [bit] NOT NULL,
    CONSTRAINT [FK_TourAuditLog_Tours] FOREIGN KEY([TourId]) REFERENCES [dbo].[Tours] ([Id])
);


-- TourSteps table
CREATE TABLE [dbo].[TourSteps](
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [TourId] [uniqueidentifier] NOT NULL,
    [ElementIdentifier] [nvarchar](max) NOT NULL,
    [Sequence] [int] NOT NULL,
    [TooltipId] [uniqueidentifier] NOT NULL,
    [AlignId] [uniqueidentifier] NOT NULL,
    [SideId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [FK_TourSteps_Tours] FOREIGN KEY([TourId]) REFERENCES [dbo].[Tours] ([Id]),
    CONSTRAINT [FK_TourSteps_Tooltips] FOREIGN KEY([TooltipId]) REFERENCES [dbo].[Tooltips] ([Id]),
    CONSTRAINT [FK_TourSteps_Sides] FOREIGN KEY([SideId]) REFERENCES [dbo].[Sides] ([Id])
);

