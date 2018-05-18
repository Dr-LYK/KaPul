USE [master]
GO
/****** Object:  Database [BugTrackLike]    Script Date: 01/03/2018 18:43:59 ******/
CREATE DATABASE [KaPul]
GO
USE [KaPul]
GO
/****** Object:  Table [dbo].[T_Car]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Car](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[platenumber] [nvarchar](64) NOT NULL,
	[model] [nvarchar](64) NOT NULL,
	[color] [nvarchar](64) NOT NULL,
	[user_id] [bigint] NOT NULL,
 CONSTRAINT [PK_T_Car] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Comment]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Comment](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[comment] [text] NOT NULL,
	[rate] [tinyint] NOT NULL,
	[passenger_id] [bigint] NOT NULL,
 CONSTRAINT [PK_T_Comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Passenger]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Passenger](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NOT NULL,
	[trip_id] [nvarchar](64) NOT NULL,
	[nb_seat] [tinyint] NOT NULL,
 CONSTRAINT [PK_T_Passenger] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_User]    Script Date: 18/05/2018 13:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_User](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL,
	[firstname] [nvarchar](64) NOT NULL,
	[email] [nvarchar](64) NOT NULL,
	[password] [varbinary](128) NOT NULL,
	[idcard] [nvarchar](64) NULL,
	[driving_licence] [nvarchar](64) NULL,
	[registration_time] [datetime] NOT NULL,
 CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Car]  WITH CHECK ADD  CONSTRAINT [FK_T_Car_T_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[T_User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Car] CHECK CONSTRAINT [FK_T_Car_T_User]
GO
ALTER TABLE [dbo].[T_Comment]  WITH CHECK ADD  CONSTRAINT [FK_T_Comment_T_Passenger] FOREIGN KEY([passenger_id])
REFERENCES [dbo].[T_Passenger] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Comment] CHECK CONSTRAINT [FK_T_Comment_T_Passenger]
GO
ALTER TABLE [dbo].[T_Passenger]  WITH CHECK ADD  CONSTRAINT [FK_T_Passenger_T_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[T_User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Passenger] CHECK CONSTRAINT [FK_T_Passenger_T_User]
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
	@name nvarchar(64),
	@firstname nvarchar(64),
	@email nvarchar(64),
	@password varchar(64)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[T_User] ([name], [firstname], [email], [password], [idcard], [driving_licence], [registration_time])
	VALUES (@name, @firstname, @email, HASHBYTES('SHA2_512', @password), NULL, NULL, GETDATE());
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
	@idUser bigint

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[T_User] WHERE [dbo].[T_User].[id] = @idUser;
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
	@idUser bigint,
	@name nvarchar(64),
	@firstname nvarchar(64),
	@email nvarchar(64),
	@password varchar(64),
	@idcard nvarchar(64),
	@driving_licence nvarchar(64)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[T_User]
	SET [dbo].[T_User].[name] = @name,
	[dbo].[T_User].[firstname] = @firstname,
	[dbo].[T_User].[email] = @email,
	[dbo].[T_User].[password] = HASHBYTES('SHA2_512', @password),
	[dbo].[T_User].[idcard] = @idcard,
	[dbo].[T_User].[driving_licence] = @driving_licence
	WHERE [dbo].[T_User].[id] = @idUser;
END
GO
