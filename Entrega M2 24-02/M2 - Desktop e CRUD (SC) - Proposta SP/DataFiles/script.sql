USE [master]
GO
/****** Object:  Database [Sessao2]    Script Date: 21/08/2025 14:53:23 ******/
CREATE DATABASE [Sessao2]
GO
USE [Sessao2]
GO
/****** Object:  Table [dbo].[Cashback]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cashback](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitacaoId] [int] NULL,
	[Valor] [float] NULL,
 CONSTRAINT [PK_Cashback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[CPF] [char](11) NOT NULL,
	[ResponsavelId] [int] NULL,
 CONSTRAINT [PK__Cliente__3214EC0705F4F54B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[Id] [int] NOT NULL,
	[RazaoSocial] [varchar](100) NOT NULL,
	[CNPJ] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Forneced__3214EC07E5BDDF11] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Telefone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Valor] [float] NULL,
	[TipoId] [int] NOT NULL,
	[FornecedorId] [int] NOT NULL,
	[Descricao] [text] NULL,
	[Validade] [date] NOT NULL,
	[DataHoraCadastro] [datetime] NOT NULL,
	[Estoque] [int] NULL,
 CONSTRAINT [PK__Produto__3214EC07E32A28F2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdutoSolicitacao]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutoSolicitacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitcaoId] [int] NOT NULL,
	[ProdutoId] [int] NOT NULL,
	[Quantidade] [int] NULL,
	[Desconto] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitacao]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Validade] [date] NOT NULL,
	[DataHoraCadastro] [datetime] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Descricao] [text] NOT NULL,
	[Cashback] [float] NULL,
 CONSTRAINT [PK__Solicita__3214EC07576DC8DA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposProduto]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposProduto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
 CONSTRAINT [PK_TiposProduto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 21/08/2025 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[SenhaHash] [varchar](255) NOT NULL,
 CONSTRAINT [PK__Usuario__3214EC0722561F1D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cashback] ON 
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (1, 1, 26.5726)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (6, 6, 18.7734)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (7, 7, 22.3462)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (10, 10, 21.5262)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (12, 12, 17.867199999999997)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (13, 13, 20.1241)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (15, 15, 17.1323)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (16, 16, 23.395500000000002)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (20, 20, 20.859)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (22, 22, 20.842)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (23, 23, 15.528200000000002)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (25, 25, 70.5666)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (27, 27, 19.046)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (29, 29, 19.2777)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (30, 30, 17.1223)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (31, 31, 60.2366)
GO
INSERT [dbo].[Cashback] ([Id], [SolicitacaoId], [Valor]) VALUES (35, 35, 65.0328)
GO
SET IDENTITY_INSERT [dbo].[Cashback] OFF
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (16, CAST(N'1993-12-11' AS Date), N'10809978715', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (17, CAST(N'1989-11-17' AS Date), N'36668198463', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (18, CAST(N'1996-04-27' AS Date), N'84234713273', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (19, CAST(N'2002-09-10' AS Date), N'07634229421', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (20, CAST(N'1988-07-12' AS Date), N'60919955954', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (21, CAST(N'1998-12-14' AS Date), N'82769278936', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (22, CAST(N'1992-03-15' AS Date), N'74741284230', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (23, CAST(N'1997-08-11' AS Date), N'96970446966', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (24, CAST(N'2004-02-09' AS Date), N'58976759617', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (25, CAST(N'1992-10-28' AS Date), N'44415920000', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (26, CAST(N'1991-03-20' AS Date), N'55318073154', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (27, CAST(N'1993-01-27' AS Date), N'24935157105', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (28, CAST(N'1984-08-03' AS Date), N'10973022789', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (29, CAST(N'1992-03-18' AS Date), N'37680201866', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (30, CAST(N'2004-09-15' AS Date), N'75791045817', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (31, CAST(N'1996-01-11' AS Date), N'23781505204', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (32, CAST(N'2004-10-10' AS Date), N'95540147110', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (33, CAST(N'2002-01-10' AS Date), N'37851920249', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (34, CAST(N'1984-12-31' AS Date), N'93800797956', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (35, CAST(N'2001-04-10' AS Date), N'46258188367', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (36, CAST(N'2002-04-07' AS Date), N'14631075865', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (37, CAST(N'2009-05-28' AS Date), N'02698750689', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (38, CAST(N'1991-07-30' AS Date), N'24849354089', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (39, CAST(N'1993-05-10' AS Date), N'50528250295', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (40, CAST(N'1987-03-20' AS Date), N'78257211304', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (41, CAST(N'1981-07-26' AS Date), N'67522571408', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (42, CAST(N'2007-12-16' AS Date), N'65902620903', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (43, CAST(N'2009-03-21' AS Date), N'84107213375', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (44, CAST(N'1999-08-13' AS Date), N'83288590941', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (45, CAST(N'2003-07-31' AS Date), N'23115062327', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (46, CAST(N'1990-06-24' AS Date), N'07120605884', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (47, CAST(N'2005-03-08' AS Date), N'02185013996', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (48, CAST(N'2007-12-20' AS Date), N'98017915825', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (49, CAST(N'1987-07-31' AS Date), N'64741215563', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (50, CAST(N'1993-12-21' AS Date), N'05850841808', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (52, CAST(N'2025-08-19' AS Date), N'12345678911', NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DataNascimento], [CPF], [ResponsavelId]) VALUES (56, CAST(N'2007-08-20' AS Date), N'11111111111', NULL)
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (1, N'BioPharma Distribuidora de Medicamentos LTDA', N'10.123.456/0001-01')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (2, N'Vida Limpa Produtos de Higiene LTDA', N'11.234.567/0001-02')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (3, N'MediTech Equipamentos Hospitalares LTDA', N'12.345.678/0001-03')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (4, N'Higieniza+ Soluções em Limpeza LTDA', N'13.456.789/0001-04')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (5, N'Saúde Plena Produtos Médicos LTDA', N'14.567.890/0001-05')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (6, N'ClinEquip Hospitalar LTDA', N'15.678.901/0001-06')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (7, N'FarmaFácil Distribuição de Medicamentos LTDA', N'16.789.012/0001-07')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (8, N'CleanCare Higiene Profissional LTDA', N'17.890.123/0001-08')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (9, N'VitaMed Importadora de Medicamentos LTDA', N'18.901.234/0001-09')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (10, N'MediLine Equipamentos Cirúrgicos LTDA', N'19.012.345/0001-10')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (11, N'BioHigiene Produtos e Limpeza LTDA', N'20.123.456/0001-11')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (12, N'Hospitalar Brasil Equipamentos LTDA', N'21.234.567/0001-12')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (13, N'Sanit+ Distribuidora de Higiene LTDA', N'22.345.678/0001-13')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (14, N'UltraMedic Soluções Farmacêuticas LTDA', N'23.456.789/0001-14')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (15, N'EquipVida Aparelhos Hospitalares LTDA', N'24.567.890/0001-15')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (54, N'TESTE', N'13245678911111')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (55, N'fdsa', N'11111111111111')
GO
INSERT [dbo].[Fornecedor] ([Id], [RazaoSocial], [CNPJ]) VALUES (58, N'fdas', N'12345678912321')
GO
SET IDENTITY_INSERT [dbo].[Pessoa] ON 
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (1, N'Adalberto Martins da Silva', N'(61) 97708-4480')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (2, N'Adan Roger Guimarães Dias', N'(61) 98694-2811')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (3, N'Adão Walter Gomes de Sousa', N'(61) 91912-3133')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (4, N'Adelson Fernandes Sena', N'(61) 94963-3812')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (5, N'Ademir Augusto Simões', N'(61) 99226-4834')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (6, N'Ademir Borges dos Santos', N'(61) 94833-7853')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (7, N'Adilio José da Silva Santos', N'(61) 96671-9394')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (8, N'Adriana Ferreira de Lima Teodoro', N'(61) 93770-1591')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (9, N'Adriano Bezerra Apolinario', N'(61) 92428-2034')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (10, N'Adriano Heleno Basso', N'(61) 98963-5102')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (11, N'Adriano Lourenço do Rego', N'(61) 98654-7340')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (12, N'Adriano Matos Santos', N'(61) 99143-6279')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (13, N'Adriano Pires Caetano', N'(61) 97930-8181')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (14, N'Adriano Prada de Campos', N'(61) 94028-1913')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (15, N'Adriel Alberto dos Santos', N'(61) 97982-5252')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (16, N'Agner Vinicius Marques de Camargo', N'(61) 97232-7430')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (17, N'Agrinaldo Ferreira Soares', N'(61) 99107-8353')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (18, N'Alan Jhonnes Banlian da Silva e Sá', N'(61) 92645-9546')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (19, N'Alberto Ramos Rodrigues', N'(61) 94981-4168')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (20, N'Alcides José Ramos', N'(61) 97895-5911')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (21, N'Aldemir SantAna dos Santos', N'(61) 96968-9454')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (22, N'Aleksandro Marcelo da Silva', N'(61) 98696-9467')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (23, N'Alessandro Martins Silva', N'(61) 95920-8353')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (24, N'Alessandro Sanches', N'(61) 94197-8158')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (25, N'Alex dos Reis de Jesus', N'(61) 95775-4765')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (26, N'Alex Ferreira Soares', N'(61) 91939-9095')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (27, N'Alex Sandro Oliveira', N'(61) 99855-7469')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (28, N'Alex Souza Farias', N'(61) 98108-5334')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (29, N'Alexandra de Lima Silva', N'(61) 97229-7026')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (30, N'Alexandre Clemente da Costa', N'(61) 93814-8177')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (31, N'Alexandre Feltrin Pavanelli', N'(61) 91341-8796')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (32, N'Alexandre Kawai Francischetti', N'(61) 92129-7844')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (33, N'Alexandre Pavanello e Silva', N'(61) 99208-1852')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (34, N'Alexandre Vieira', N'(61) 93530-1744')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (35, N'Alexsandro José dos Santos', N'(61) 91158-6872')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (36, N'Allan Borges Ferreira', N'(61) 98189-9471')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (37, N'Allisson Ferreira Soares Santos', N'(61) 97482-5856')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (38, N'Allysson de Oliveira Costa', N'(61) 94054-3724')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (39, N'Altair Antonio da Silva', N'(61) 98402-3215')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (40, N'Altair de Oliveira Junior', N'(61) 95226-4083')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (41, N'Amilton Vagner Pereira', N'(61) 91907-7413')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (42, N'Ana Claudia Bento Ribeiro', N'(61) 95776-4327')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (43, N'Ana Cristina Pereira de Souza', N'(61) 99236-1563')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (44, N'ANDERSON CALDEIRA DA SILVA REIMBERG', N'(61) 94668-4064')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (45, N'Anderson de Castro Silva', N'(61) 99126-3711')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (46, N'Anderson de Oliveira', N'(61) 95478-9898')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (47, N'Anderson de Sousa Trindade', N'(61) 99106-4916')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (48, N'Anderson de Souza Santos', N'(61) 94546-3709')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (49, N'Anderson Dias do Nascimento', N'(61) 94520-4077')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (50, N'ANDERSON MILITÃO DE SANTANA', N'(61) 95043-7356')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (51, N'André Luis de Souza Futro', N'(61) 98694-2811')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (52, N'fiore', N'FDSA')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (54, N'FDSAF', N'4312')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (55, N'fasd', N'fasf')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (56, N'fdsafda', N'fas')
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [Telefone]) VALUES (58, N'fasdf', N'4312341')
GO
SET IDENTITY_INSERT [dbo].[Pessoa] OFF
GO
SET IDENTITY_INSERT [dbo].[Produto] ON 
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (1, N'Ibuprofeno', 994.99, 3, 1, N'Anti-inflamatório não esteroide', CAST(N'2025-09-30' AS Date), CAST(N'2025-04-01T08:00:00.000' AS DateTime), 15)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (2, N'Algodão', 672.28, 1, 1, N'Algodão hidrófilo', CAST(N'2026-03-15' AS Date), CAST(N'2025-05-01T09:00:00.000' AS DateTime), 25)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (3, N'Luvas Cirúrgicas', 358.41, 2, 1, N'Luvas descartáveis', CAST(N'2026-01-15' AS Date), CAST(N'2025-06-01T10:00:00.000' AS DateTime), 10)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (4, N'Gaze', 141.35, 1, 2, N'Compressas de gaze', CAST(N'2025-07-01' AS Date), CAST(N'2025-03-02T11:00:00.000' AS DateTime), 10)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (5, N'Oxímetro', 575.8, 2, 2, N'Medidor de saturação de oxigênio', CAST(N'2026-04-30' AS Date), CAST(N'2025-04-02T12:00:00.000' AS DateTime), 20)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (6, N'Paracetamol', 261.42, 3, 3, N'Analgésico e antitérmico', CAST(N'2025-12-15' AS Date), CAST(N'2025-07-01T08:00:00.000' AS DateTime), 45)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (7, N'Soro Fisiológico', 178.77, 1, 4, N'Desinfetante líquido', CAST(N'2026-01-10' AS Date), CAST(N'2025-07-01T09:00:00.000' AS DateTime), 20)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (8, N'Termômetro Digital', 248.49, 2, 5, N'Equipamento para medição de temperatura', CAST(N'2027-01-01' AS Date), CAST(N'2025-07-01T10:00:00.000' AS DateTime), 50)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (9, N'Dipirona Sódica', 930.16, 3, 6, N'Analgésico e antitérmico', CAST(N'2025-08-25' AS Date), CAST(N'2025-07-01T11:00:00.000' AS DateTime), 90)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (10, N'Band Aid', 230.58, 1, 7, N'Máscara de proteção descartável', CAST(N'2026-02-28' AS Date), CAST(N'2025-07-01T12:00:00.000' AS DateTime), 35)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (11, N'Seringa 5ml', 353.82, 2, 8, N'Seringa estéril para aplicações', CAST(N'2027-05-15' AS Date), CAST(N'2025-08-01T08:00:00.000' AS DateTime), 80)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (12, N'Amoxicilina', 762.26, 3, 9, N'Antibiótico para infecções bacterianas', CAST(N'2025-11-01' AS Date), CAST(N'2025-08-01T09:00:00.000' AS DateTime), 135)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (13, N'Sabonete Antisséptico', 155.42, 1, 10, N'Sabonete com ação antibacteriana', CAST(N'2026-06-30' AS Date), CAST(N'2025-08-01T10:00:00.000' AS DateTime), 50)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (14, N'Estetoscópio', 886.68, 2, 11, N'Equipamento para ausculta médica', CAST(N'2027-10-10' AS Date), CAST(N'2025-08-01T11:00:00.000' AS DateTime), 110)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (15, N'Aspirina', 437.35, 3, 12, N'Medicamento para pressão arterial', CAST(N'2026-09-05' AS Date), CAST(N'2025-08-01T12:00:00.000' AS DateTime), 180)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (16, N'Sabão Líquido Hospitalar', 240.77, 1, 13, N'Sabão com pH neutro para uso clínico', CAST(N'2026-03-01' AS Date), CAST(N'2025-09-01T08:00:00.000' AS DateTime), 65)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (17, N'Nebulizador', 157.66, 2, 14, N'Equipamento para inalação', CAST(N'2027-12-01' AS Date), CAST(N'2025-09-01T09:00:00.000' AS DateTime), 140)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (18, N'Omeprazol', 109.46, 3, 15, N'Antiácido e inibidor de bomba de prótons', CAST(N'2025-10-20' AS Date), CAST(N'2025-09-01T10:00:00.000' AS DateTime), 225)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (19, N'Água Oxigenada', 775.91, 1, 1, N'Antisséptico para limpeza de feridas', CAST(N'2026-04-15' AS Date), CAST(N'2025-09-01T11:00:00.000' AS DateTime), 25)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (20, N'Bisturi Descartável', 600.8, 2, 2, N'Instrumento cirúrgico de corte', CAST(N'2027-03-12' AS Date), CAST(N'2025-09-01T12:00:00.000' AS DateTime), 20)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (21, N'Metformina', 194.89, 3, 3, N'Medicamento para diabetes tipo 2', CAST(N'2025-12-30' AS Date), CAST(N'2025-10-01T08:00:00.000' AS DateTime), 45)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (22, N'Papel Toalha Hospitalar', 234.68, 1, 4, N'Papel absorvente descartável', CAST(N'2026-02-20' AS Date), CAST(N'2025-10-01T09:00:00.000' AS DateTime), 20)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (23, N'Autoclave Portátil', 120.88, 2, 5, N'Esterilizador a vapor', CAST(N'2028-01-01' AS Date), CAST(N'2025-10-01T10:00:00.000' AS DateTime), 50)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (24, N'Azitromicina', 833.42, 3, 6, N'Antibiótico de amplo espectro', CAST(N'2026-05-10' AS Date), CAST(N'2025-10-01T11:00:00.000' AS DateTime), 90)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (25, N'Desinfetante Hospitalar', 772.33, 1, 7, N'Desinfetante para superfícies clínicas', CAST(N'2026-08-18' AS Date), CAST(N'2025-10-01T12:00:00.000' AS DateTime), 35)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (26, N'Cadeira de Rodas', 413.36, 2, 8, N'Equipamento de locomoção', CAST(N'2028-06-30' AS Date), CAST(N'2025-11-01T08:00:00.000' AS DateTime), 80)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (27, N'Enalapril', 259.87, 3, 9, N'Antihipertensivo', CAST(N'2026-07-12' AS Date), CAST(N'2025-11-01T09:00:00.000' AS DateTime), 135)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (28, N'Toalhas Umedecidas', 834.95, 1, 10, N'Lenços higiênicos para limpeza', CAST(N'2026-05-22' AS Date), CAST(N'2025-11-01T10:00:00.000' AS DateTime), 50)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (29, N'Aparelho de Pressão', 458.76, 2, 11, N'Esfigmomanômetro clínico', CAST(N'2027-11-15' AS Date), CAST(N'2025-11-01T11:00:00.000' AS DateTime), 110)
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Valor], [TipoId], [FornecedorId], [Descricao], [Validade], [DataHoraCadastro], [Estoque]) VALUES (30, N'Desfrilador', 266.57, 3, 12, N'Corticoide anti-inflamatório', CAST(N'2026-12-31' AS Date), CAST(N'2025-11-01T12:00:00.000' AS DateTime), 180)
GO
SET IDENTITY_INSERT [dbo].[Produto] OFF
GO
SET IDENTITY_INSERT [dbo].[ProdutoSolicitacao] ON 
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (154, 1, 1, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (155, 1, 2, 1, 5)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (160, 4, 7, 2, 3)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (161, 4, 8, 3, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (162, 5, 9, 1, 4)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (163, 5, 10, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (164, 6, 11, 1, 1)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (165, 6, 12, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (166, 7, 13, 3, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (167, 7, 14, 2, 5)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (168, 8, 15, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (169, 8, 16, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (170, 9, 17, 2, 2)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (171, 9, 18, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (172, 10, 19, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (173, 10, 20, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (174, 11, 21, 2, 3)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (175, 11, 22, 3, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (176, 12, 23, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (177, 12, 24, 2, 1)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (178, 13, 25, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (179, 13, 26, 3, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (180, 14, 27, 2, 2)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (181, 14, 28, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (182, 15, 29, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (183, 15, 30, 3, 4)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (184, 16, 1, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (185, 16, 2, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (186, 17, 3, 1, 3)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (187, 17, 4, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (188, 18, 5, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (189, 18, 6, 1, 2)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (190, 19, 7, 3, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (191, 19, 8, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (192, 20, 9, 2, 5)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (193, 20, 10, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (194, 21, 11, 1, 1)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (195, 21, 12, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (196, 22, 13, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (197, 22, 14, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (198, 23, 15, 3, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (199, 23, 16, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (200, 24, 17, 1, 3)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (201, 24, 18, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (202, 25, 19, 3, 1)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (203, 25, 20, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (204, 26, 21, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (205, 26, 22, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (206, 27, 23, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (207, 27, 24, 2, 4)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (208, 28, 25, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (209, 28, 26, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (210, 29, 27, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (211, 29, 28, 2, 2)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (212, 30, 29, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (213, 30, 30, 3, 5)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (214, 31, 1, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (215, 31, 2, 3, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (216, 32, 3, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (217, 32, 4, 1, 2)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (218, 33, 5, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (219, 33, 6, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (220, 34, 7, 2, 3)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (221, 34, 8, 1, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (222, 35, 9, 3, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (223, 35, 10, 2, 0)
GO
INSERT [dbo].[ProdutoSolicitacao] ([Id], [SolicitcaoId], [ProdutoId], [Quantidade], [Desconto]) VALUES (226, 1, 10, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[ProdutoSolicitacao] OFF
GO
SET IDENTITY_INSERT [dbo].[Solicitacao] ON 
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (1, CAST(N'2025-08-10' AS Date), CAST(N'2025-01-01T08:00:00.000' AS DateTime), 16, N'Solicitação de medicamentos de uso contínuo', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (4, CAST(N'2025-11-05' AS Date), CAST(N'2025-01-01T11:00:00.000' AS DateTime), 19, N'Solicitação de medicamentos para dor', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (5, CAST(N'2026-01-12' AS Date), CAST(N'2025-01-01T12:00:00.000' AS DateTime), 20, N'Solicitação emergencial de curativos', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (6, CAST(N'2025-12-01' AS Date), CAST(N'2025-02-01T08:00:00.000' AS DateTime), 21, N'Reposição de seringas e agulhas', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (7, CAST(N'2026-02-28' AS Date), CAST(N'2025-02-01T09:00:00.000' AS DateTime), 22, N'Solicitação de frascos de álcool 70%', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (8, CAST(N'2026-03-15' AS Date), CAST(N'2025-02-01T10:00:00.000' AS DateTime), 23, N'Solicitação de medicações para pressão', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (9, CAST(N'2026-04-10' AS Date), CAST(N'2025-02-01T11:00:00.000' AS DateTime), 24, N'Solicitação de insumos para laboratório', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (10, CAST(N'2026-05-05' AS Date), CAST(N'2025-02-01T12:00:00.000' AS DateTime), 25, N'Solicitação de máscaras descartáveis', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (11, CAST(N'2026-06-01' AS Date), CAST(N'2025-03-01T08:00:00.000' AS DateTime), 26, N'Solicitação de material de assepsia', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (12, CAST(N'2025-09-01' AS Date), CAST(N'2025-03-01T09:00:00.000' AS DateTime), 27, N'Solicitação de antibióticos', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (13, CAST(N'2025-10-10' AS Date), CAST(N'2025-03-01T10:00:00.000' AS DateTime), 28, N'Solicitação de luvas cirúrgicas', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (14, CAST(N'2025-11-15' AS Date), CAST(N'2025-03-01T11:00:00.000' AS DateTime), 29, N'Solicitação de aparelhos de aferição', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (15, CAST(N'2026-01-30' AS Date), CAST(N'2025-03-01T12:00:00.000' AS DateTime), 30, N'Solicitação de equipamentos para fisioterapia', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (16, CAST(N'2026-02-15' AS Date), CAST(N'2025-04-01T08:00:00.000' AS DateTime), 31, N'Solicitação de remédios para diabetes', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (17, CAST(N'2026-03-01' AS Date), CAST(N'2025-04-01T09:00:00.000' AS DateTime), 32, N'Solicitação de termômetros digitais', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (18, CAST(N'2026-04-05' AS Date), CAST(N'2025-04-01T10:00:00.000' AS DateTime), 33, N'Solicitação de compressas esterilizadas', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (19, CAST(N'2026-05-20' AS Date), CAST(N'2025-04-01T11:00:00.000' AS DateTime), 34, N'Solicitação de desinfetantes hospitalares', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (20, CAST(N'2026-06-15' AS Date), CAST(N'2025-04-01T12:00:00.000' AS DateTime), 35, N'Solicitação de anti-inflamatórios', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (21, CAST(N'2026-07-10' AS Date), CAST(N'2025-05-01T08:00:00.000' AS DateTime), 36, N'Solicitação de seringas descartáveis', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (22, CAST(N'2025-08-20' AS Date), CAST(N'2025-05-01T00:00:00.000' AS DateTime), 37, N'Solicitação de itens para primeiros socorros', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (23, CAST(N'2025-09-18' AS Date), CAST(N'2025-05-01T10:00:00.000' AS DateTime), 38, N'Solicitação de material odontológico básico', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (24, CAST(N'2025-10-25' AS Date), CAST(N'2025-05-01T11:00:00.000' AS DateTime), 39, N'Solicitação de kits de teste rápido', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (25, CAST(N'2025-11-30' AS Date), CAST(N'2025-05-01T12:00:00.000' AS DateTime), 40, N'Solicitação de papel toalha hospitalar', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (26, CAST(N'2026-01-10' AS Date), CAST(N'2025-06-01T08:00:00.000' AS DateTime), 41, N'Solicitação de medicamentos para dor crônica', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (27, CAST(N'2026-02-05' AS Date), CAST(N'2025-06-01T09:00:00.000' AS DateTime), 42, N'Solicitação de toalhas umedecidas', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (28, CAST(N'2026-03-22' AS Date), CAST(N'2025-06-01T10:00:00.000' AS DateTime), 43, N'Solicitação de luvas de procedimento', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (29, CAST(N'2026-04-18' AS Date), CAST(N'2025-06-01T11:00:00.000' AS DateTime), 44, N'Solicitação de seringas para insulina', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (30, CAST(N'2026-05-30' AS Date), CAST(N'2025-06-01T12:00:00.000' AS DateTime), 45, N'Solicitação de anti-histamínicos', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (31, CAST(N'2026-06-12' AS Date), CAST(N'2025-07-01T08:00:00.000' AS DateTime), 46, N'Solicitação de solução salina', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (32, CAST(N'2025-09-09' AS Date), CAST(N'2025-07-01T09:00:00.000' AS DateTime), 47, N'Solicitação de máscaras N95', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (33, CAST(N'2025-10-19' AS Date), CAST(N'2025-07-01T10:00:00.000' AS DateTime), 48, N'Solicitação de álcool em gel', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (34, CAST(N'2025-11-25' AS Date), CAST(N'2025-07-01T11:00:00.000' AS DateTime), 49, N'Solicitação de medicamentos para hipertensão', NULL)
GO
INSERT [dbo].[Solicitacao] ([Id], [Validade], [DataHoraCadastro], [ClienteId], [Descricao], [Cashback]) VALUES (35, CAST(N'2026-01-15' AS Date), CAST(N'2025-07-01T12:00:00.000' AS DateTime), 50, N'Solicitação de equipamentos ortopédicos', NULL)
GO
SET IDENTITY_INSERT [dbo].[Solicitacao] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposProduto] ON 
GO
INSERT [dbo].[TiposProduto] ([Id], [Nome]) VALUES (1, N'Higiene')
GO
INSERT [dbo].[TiposProduto] ([Id], [Nome]) VALUES (2, N'Equipamento')
GO
INSERT [dbo].[TiposProduto] ([Id], [Nome]) VALUES (3, N'Medicamento')
GO
SET IDENTITY_INSERT [dbo].[TiposProduto] OFF
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (1, N'adalbertosilva@email.com', N'7001439')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (2, N'adandias@email.com', N'3267698')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (3, N'adãosousa@email.com', N'6032386')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (4, N'adelsonsena@email.com', N'2281491')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (5, N'ademirsimões@email.com', N'4986896')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (6, N'ademirsantos@email.com', N'2156482')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (7, N'adiliosantos@email.com', N'4110059')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (8, N'adrianateodoro@email.com', N'3412150')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (9, N'adrianoapolinario@email.com', N'6282502')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (10, N'adrianobasso@email.com', N'8391653')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (11, N'adrianorego@email.com', N'2320362')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (12, N'adrianosantos@email.com', N'5779789')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (13, N'adrianocaetano@email.com', N'3713773')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (14, N'adrianocampos@email.com', N'5398667')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (15, N'adrielsantos@email.com', N'4849681')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (16, N'agnercamargo@email.com', N'4522398')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (17, N'agrinaldosoares@email.com', N'5901088')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (18, N'alansá@email.com', N'2491451')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (19, N'albertorodrigues@email.com', N'7090791')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (20, N'alcidesramos@email.com', N'8698226')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (21, N'aldemirsantos@email.com', N'30309')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (22, N'aleksandrosilva@email.com', N'6107221')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (23, N'alessandrosilva@email.com', N'1315268')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (24, N'alessandrosanches@email.com', N'3011255')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (25, N'alexjesus@email.com', N'2418652')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (26, N'alexsoares@email.com', N'2906859')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (27, N'alexoliveira@email.com', N'840537')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (28, N'alexfarias@email.com', N'3201417')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (29, N'alexandrasilva@email.com', N'9088525')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (30, N'alexandrecosta@email.com', N'220448')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (31, N'alexandrepavanelli@email.com', N'5872152')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (32, N'alexandrefrancischetti@email.com', N'798929')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (33, N'alexandresilva@email.com', N'6214408')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (34, N'alexandrevieira@email.com', N'3334200')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (35, N'alexsandrosantos@email.com', N'4067578')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (36, N'allanferreira@email.com', N'3404705')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (37, N'allissonsantos@email.com', N'8700233')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (38, N'allyssoncosta@email.com', N'9891272')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (39, N'altairsilva@email.com', N'814343')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (40, N'altairjunior@email.com', N'3236232')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (41, N'amiltonpereira@email.com', N'4172041')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (42, N'anaribeiro@email.com', N'8736249')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (43, N'anasouza@email.com', N'463741')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (44, N'andersonreimberg@email.com', N'8285570')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (45, N'andersonsilva@email.com', N'4810856')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (46, N'andersonoliveira@email.com', N'8566276')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (47, N'andersontrindade@email.com', N'5130354')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (48, N'andersonsantos@email.com', N'8738474')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (49, N'andersonnascimento@email.com', N'5850185')
GO
INSERT [dbo].[Usuario] ([Id], [Login], [SenhaHash]) VALUES (50, N'andersonsantana@email.com', N'2125484')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Cliente__C1F89731ECB2414E]    Script Date: 21/08/2025 14:53:23 ******/
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [UQ__Cliente__C1F89731ECB2414E] UNIQUE NONCLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Forneced__AA57D6B40A4CB1F8]    Script Date: 21/08/2025 14:53:23 ******/
ALTER TABLE [dbo].[Fornecedor] ADD  CONSTRAINT [UQ__Forneced__AA57D6B40A4CB1F8] UNIQUE NONCLUSTERED 
(
	[CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__5E55825B41DEA89A]    Script Date: 21/08/2025 14:53:23 ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [UQ__Usuario__5E55825B41DEA89A] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__5E55825BEA2686C3]    Script Date: 21/08/2025 14:53:23 ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [UQ__Usuario__5E55825BEA2686C3] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cashback]  WITH CHECK ADD  CONSTRAINT [FK_Cashback_Solicitacao] FOREIGN KEY([SolicitacaoId])
REFERENCES [dbo].[Solicitacao] ([Id])
GO
ALTER TABLE [dbo].[Cashback] CHECK CONSTRAINT [FK_Cashback_Solicitacao]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK__Cliente__Respons__403A8C7D] FOREIGN KEY([ResponsavelId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK__Cliente__Respons__403A8C7D]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Pessoa] FOREIGN KEY([Id])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Pessoa]
GO
ALTER TABLE [dbo].[Fornecedor]  WITH CHECK ADD  CONSTRAINT [FK_Fornecedor_Pessoa] FOREIGN KEY([Id])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Fornecedor] CHECK CONSTRAINT [FK_Fornecedor_Pessoa]
GO
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK__Produto__Fornece__4D94879B] FOREIGN KEY([FornecedorId])
REFERENCES [dbo].[Fornecedor] ([Id])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK__Produto__Fornece__4D94879B]
GO
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_TiposProduto] FOREIGN KEY([TipoId])
REFERENCES [dbo].[TiposProduto] ([Id])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_TiposProduto]
GO
ALTER TABLE [dbo].[ProdutoSolicitacao]  WITH CHECK ADD  CONSTRAINT [FK__ProdutoSo__Produ__5535A963] FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[ProdutoSolicitacao] CHECK CONSTRAINT [FK__ProdutoSo__Produ__5535A963]
GO
ALTER TABLE [dbo].[ProdutoSolicitacao]  WITH CHECK ADD  CONSTRAINT [FK__ProdutoSo__Solic__5441852A] FOREIGN KEY([SolicitcaoId])
REFERENCES [dbo].[Solicitacao] ([Id])
GO
ALTER TABLE [dbo].[ProdutoSolicitacao] CHECK CONSTRAINT [FK__ProdutoSo__Solic__5441852A]
GO
ALTER TABLE [dbo].[Solicitacao]  WITH CHECK ADD  CONSTRAINT [FK__Solicitac__Clien__5165187F] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Solicitacao] CHECK CONSTRAINT [FK__Solicitac__Clien__5165187F]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Pessoa] FOREIGN KEY([Id])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Pessoa]
GO
USE [master]
GO
ALTER DATABASE [Sessao2] SET  READ_WRITE 
GO
