USE [master]
GO
/****** Object:  Database [JSGL]    Script Date: 2020/11/12 14:28:17 ******/
CREATE DATABASE [JSGL] 
GO
USE [JSGL]
GO
/****** Object:  Table [dbo].[Achievement]    Script Date: 2020/11/12 14:28:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achievement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[CourseID] [nvarchar](50) NULL,
	[TeacherID] [nvarchar](50) NULL,
	[Score] [nvarchar](50) NULL,
	[Time] [nvarchar](50) NULL,
 CONSTRAINT [PK_Achievement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 2020/11/12 14:28:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2020/11/12 14:28:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [nchar](20) NULL,
	[Course] [nchar](50) NULL,
	[Title] [nchar](10) NULL,
	[Time] [nchar](50) NULL,
	[Str1] [nchar](10) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 2020/11/12 14:28:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nchar](50) NULL,
	[LoginPSD] [nchar](20) NULL,
	[UserName] [nchar](50) NULL,
	[Sex] [nchar](10) NULL,
	[Age] [nchar](10) NULL,
	[Usertype] [nchar](10) NULL,
	[UserNum] [nchar](50) NULL,
	[Str1] [nchar](10) NULL,
	[Str2] [nchar](10) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Achievement] ON 

INSERT [dbo].[Achievement] ([ID], [UserID], [CourseID], [TeacherID], [Score], [Time]) VALUES (1, N'2015001', N'3', N'3', N'90', N'2018')
INSERT [dbo].[Achievement] ([ID], [UserID], [CourseID], [TeacherID], [Score], [Time]) VALUES (2, N'2015002', N'3', N'3', N'99', NULL)
INSERT [dbo].[Achievement] ([ID], [UserID], [CourseID], [TeacherID], [Score], [Time]) VALUES (3, N'2019011', N'4', N'3', N'98', NULL)
SET IDENTITY_INSERT [dbo].[Achievement] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([ID], [CourseName]) VALUES (2, N'课程2                                               ')
INSERT [dbo].[Course] ([ID], [CourseName]) VALUES (3, N'大学英语                                              ')
INSERT [dbo].[Course] ([ID], [CourseName]) VALUES (4, N'大学英语                                              ')
INSERT [dbo].[Course] ([ID], [CourseName]) VALUES (1003, N'计算机网络                                             ')
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([ID], [TeacherName], [Course], [Title], [Time], [Str1]) VALUES (3, N'李莉                  ', N'计算机基础                                             ', N'高级讲师      ', N'计算机学院                                             ', NULL)
INSERT [dbo].[Teacher] ([ID], [TeacherName], [Course], [Title], [Time], [Str1]) VALUES (4, N'李冬梅                 ', N'计算机网络                                             ', N'高级教师      ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [LoginName], [LoginPSD], [UserName], [Sex], [Age], [Usertype], [UserNum], [Str1], [Str2]) VALUES (1, N'admin                                             ', N'123456              ', N'管理                                                ', NULL, NULL, N'管理员       ', NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [LoginName], [LoginPSD], [UserName], [Sex], [Age], [Usertype], [UserNum], [Str1], [Str2]) VALUES (1001, N'2015001                                           ', N'123456              ', N'王小明                                               ', N'男         ', N'22        ', N'学生        ', N'18111111111                                       ', N'计算机学院     ', NULL)
INSERT [dbo].[Users] ([ID], [LoginName], [LoginPSD], [UserName], [Sex], [Age], [Usertype], [UserNum], [Str1], [Str2]) VALUES (1002, N'2019011                                           ', NULL, N'小张                                                ', N'男         ', N'22        ', N'学生        ', NULL, N'计算机       ', NULL)
INSERT [dbo].[Users] ([ID], [LoginName], [LoginPSD], [UserName], [Sex], [Age], [Usertype], [UserNum], [Str1], [Str2]) VALUES (1003, N'0001                                              ', NULL, N'网现场                                               ', N'男         ', N'12        ', N'学生        ', NULL, N'212       ', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [JSGL] SET  READ_WRITE 
GO
