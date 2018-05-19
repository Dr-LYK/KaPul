USE [master]
GO
/****** Object:  Database [BugTrackLike]    Script Date: 01/03/2018 18:43:59 ******/
CREATE DATABASE [KaPul]
GO
USE [KaPul]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[id] [uniqueidentifier] NOT NULL,
	[registration] [nvarchar](64) NOT NULL,
	[model] [nvarchar](64) NOT NULL,
	[color] [nvarchar](64) NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[id] [uniqueidentifier] NOT NULL,
	[detail] [text] NOT NULL,
	[rate] [tinyint] NOT NULL,
	[passenger_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[id] [uniqueidentifier] NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
	[trip_id] [nvarchar](64) NOT NULL,
	[nb_seat] [tinyint] NOT NULL,
 CONSTRAINT [PK_Passenger] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](64) NOT NULL,
	[firstname] [nvarchar](64) NOT NULL,
	[email] [nvarchar](64) NOT NULL,
	[password] [nvarchar](64) NOT NULL,
	[idcard] [nvarchar](64) NULL,
	[driving_licence] [nvarchar](64) NULL,
	[registration_date] [datetime] NOT NULL,
	CONSTRAINT [AK_email] UNIQUE(email), 
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_User]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_CommenPassenger] FOREIGN KEY([passenger_id])
REFERENCES [dbo].[Passenger] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_CommenPassenger]
GO
ALTER TABLE [dbo].[Passenger]  WITH CHECK ADD  CONSTRAINT [FK_Passenger_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Passenger] CHECK CONSTRAINT [FK_Passenger_User]
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vivian CHAIZEMARTIN
-- Create date: 19/06/2018
-- Description:	Création d'un nouvel utilisateur
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser]
	-- Add the parameters for the stored procedure here
	@idUser uniqueidentifier,
	@name nvarchar(64),
	@firstname nvarchar(64),
	@email nvarchar(64),
	@password nvarchar(64)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[User] ([id], [name], [firstname], [email], [password], [idcard], [driving_licence], [registration_date])
	VALUES (@idUser, @name, @firstname, @email, @password, NULL, NULL, GETDATE());
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vivian CHAIZEMARTIN
-- Create date: 19/06/2018
-- Description:	Suppression d'un utilisateur
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@idUser uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[User] WHERE [dbo].[User].[id] = @idUser;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vivian CHAIZEMARTIN
-- Create date: 19/06/2018
-- Description:	Mise à jour des informations d'un utilisateur
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUser]
	-- Add the parameters for the stored procedure here
	@idUser uniqueidentifier,
	@name nvarchar(64),
	@firstname nvarchar(64),
	@email nvarchar(64),
	@password nvarchar(64),
	@idcard nvarchar(64),
	@driving_licence nvarchar(64)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[User]
	SET [dbo].[User].[name] = @name,
	[dbo].[User].[firstname] = @firstname,
	[dbo].[User].[email] = @email,
	[dbo].[User].[password] = @password,
	[dbo].[User].[idcard] = @idcard,
	[dbo].[User].[driving_licence] = @driving_licence
	WHERE [dbo].[User].[id] = @idUser;
END
GO
