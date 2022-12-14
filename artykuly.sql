USE [firma_dem]
GO
/****** Object:  Table [dbo].[artykuly]    Script Date: 06.01.2023 12:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[artykuly](
	[Art_Id] [int] IDENTITY(1,1) NOT NULL,
	[nazwa_art] [varchar](50) NOT NULL,
	[kod_kresk] [varchar](13) NOT NULL,
	[zapas] [varchar](50) NOT NULL,
	[wartosc_sprzedazy] [float] NULL,
	[koszt_zakupu] [float] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[artykuly] ON 

INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (1, N'Woda Mineralna', N'5902930000042', N'999', 110, 100)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (12, N'Chipsy Lays', N'978073562153', N'2000', 5.5, 2.3)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (13, N'Cola', N'998175563452', N'900', 5.3, 2.5)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (14, N'AddTest', N'592174563452', N'2', 3, 1)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (15, N'UpdateTest', N'512273547489', N'200', 120, 150)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (16, N'Mleko', N'532475567783', N'2000', 5, 2)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (17, N'Cukier', N'542275169781', N'1000', 7, 3.5)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (18, N'Pizza', N'512145189721', N'20', 21, 11)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (19, N'Lody', N'532345389371', N'100', 15, 7.3)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (20, N'Polaris VitalGreen', N'5901088012990', N'500', 2.9, 2)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (21, N'Napój Tymbark', N'5900334004307', N'300', 3.54, 2.1)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (22, N'Dr Pepper mały', N'5902860411994', N'500', 3.14, 2.2)
INSERT [dbo].[artykuly] ([Art_Id], [nazwa_art], [kod_kresk], [zapas], [wartosc_sprzedazy], [koszt_zakupu]) VALUES (23, N'Sebidin Tabletki', N'5909990143511', N'100', 13.5, 8.2)
SET IDENTITY_INSERT [dbo].[artykuly] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__artykuly__14F986C832034689]    Script Date: 06.01.2023 12:09:36 ******/
ALTER TABLE [dbo].[artykuly] ADD UNIQUE NONCLUSTERED 
(
	[kod_kresk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__artykuly__FD7CB5539DAE556A]    Script Date: 06.01.2023 12:09:36 ******/
ALTER TABLE [dbo].[artykuly] ADD UNIQUE NONCLUSTERED 
(
	[Art_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
