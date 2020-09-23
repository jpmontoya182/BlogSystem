USE [BlogBD]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 9/22/2020 11:15:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[ContentComment] [varchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[PostId] [int] NOT NULL,
 CONSTRAINT [PK_CommentBlog] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 9/22/2020 11:15:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[PostContent] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_PostBlog] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 9/22/2020 11:15:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[ProfileId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK_ProfilesBlog] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/22/2020 11:15:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ProfileId] [int] NOT NULL,
 CONSTRAINT [PK_UserBlog] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 
GO
INSERT [dbo].[Comments] ([CommentId], [ContentComment], [CreateDate], [PostId]) VALUES (1, N'Muy bueno gracias', CAST(N'2020-09-22T23:08:29.230' AS DateTime), 7)
GO
INSERT [dbo].[Comments] ([CommentId], [ContentComment], [CreateDate], [PostId]) VALUES (2, N'Gracias lo estaba buscando', CAST(N'2020-09-22T23:56:29.230' AS DateTime), 7)
GO
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 
GO
INSERT [dbo].[Posts] ([PostId], [Title], [PostContent], [CreateDate], [State], [UserId]) VALUES (7, N'OOP', N'This is a little ´post related to programming', CAST(N'2020-09-22T17:07:06.303' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[Profiles] ON 
GO
INSERT [dbo].[Profiles] ([ProfileId], [Name], [Description], [State]) VALUES (1, N'admin', N'Administrator', 1)
GO
INSERT [dbo].[Profiles] ([ProfileId], [Name], [Description], [State]) VALUES (2, N'user', N'Usuario', 1)
GO
SET IDENTITY_INSERT [dbo].[Profiles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Email], [ProfileId]) VALUES (1, N'root', N'root', N'root@myblog.com', 1)
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Email], [ProfileId]) VALUES (2, N'pepito', N'pepito100', N'pepito@hotmail.com', 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_CommentBlog_PostBlog] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([PostId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_CommentBlog_PostBlog]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_PostBlog_UserBlog] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_PostBlog_UserBlog]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_UserBlog_ProfilesBlog] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profiles] ([ProfileId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_UserBlog_ProfilesBlog]
GO
