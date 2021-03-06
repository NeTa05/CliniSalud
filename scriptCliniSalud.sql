USE [dbClinica]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 21/12/2013 12:32:08 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Citas](
	[fecha] [datetime] NOT NULL,
	[acupuntura] [varchar](50) NOT NULL,
	[tratamiento] [varchar](50) NOT NULL,
	[equipo] [varchar](50) NOT NULL,
	[recomendacion] [varchar](50) NOT NULL,
	[otro] [varchar](50) NOT NULL,
	[pagos] [int] NOT NULL,
	[id_cliente] [varchar](50) NOT NULL,
	[id_citas] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 21/12/2013 12:32:08 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[cedula] [varchar](50) NOT NULL,
	[fecha_valoracion] [datetime] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellidos] [varchar](100) NOT NULL,
	[edad] [varchar](50) NOT NULL,
	[estatura] [varchar](50) NOT NULL,
	[peso] [varchar](50) NOT NULL,
	[fecha_nacimiento] [datetime] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[hijos] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[celular] [varchar](50) NOT NULL,
	[ocupacion] [varchar](50) NOT NULL,
	[motivo_consulta] [varchar](50) NOT NULL,
	[presion_arterial] [varchar](50) NOT NULL,
	[lindefedema] [varchar](50) NOT NULL,
	[rh] [varchar](50) NOT NULL,
	[factor_genetico] [varchar](50) NOT NULL,
	[glucosa] [varchar](50) NOT NULL,
	[estrenimiento] [varchar](50) NOT NULL,
	[trigliceridos] [varchar](50) NOT NULL,
	[colesterol] [varchar](50) NOT NULL,
	[rm] [varchar](50) NOT NULL,
	[medicamentos] [varchar](50) NOT NULL,
	[enfermedades] [varchar](50) NOT NULL,
	[tabaco] [varchar](50) NOT NULL,
	[alcohol] [varchar](50) NOT NULL,
	[lesiones_fisicas] [varchar](50) NOT NULL,
	[ejercicio_fisico] [varchar](50) NOT NULL,
	[exposicion_solar] [varchar](50) NOT NULL,
	[proteccion_solar] [varchar](50) NOT NULL,
	[lunares_manchas] [varchar](50) NOT NULL,
	[implantes] [varchar](50) NOT NULL,
	[anticonceptivos] [varchar](50) NOT NULL,
	[embarazo] [varchar](50) NOT NULL,
	[tipo_alimentacion] [varchar](50) NOT NULL,
	[desayuno] [varchar](50) NOT NULL,
	[almuerzo] [varchar](50) NOT NULL,
	[cena] [varchar](50) NOT NULL,
	[infusiones] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 21/12/2013 12:32:08 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[usuario] [varchar](50) NOT NULL,
	[contrasena] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[administrador] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Clientes1] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([cedula])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Clientes1]
GO
