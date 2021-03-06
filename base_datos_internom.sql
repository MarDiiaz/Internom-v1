USE [master]
GO
/****** Object:  Database [internom]    Script Date: 04/08/2017 11:50:02 ******/
CREATE DATABASE [internom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'internom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\internom.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'internom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\internom_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [internom] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [internom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [internom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [internom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [internom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [internom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [internom] SET ARITHABORT OFF 
GO
ALTER DATABASE [internom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [internom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [internom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [internom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [internom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [internom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [internom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [internom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [internom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [internom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [internom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [internom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [internom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [internom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [internom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [internom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [internom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [internom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [internom] SET  MULTI_USER 
GO
ALTER DATABASE [internom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [internom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [internom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [internom] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [internom] SET DELAYED_DURABILITY = DISABLED 
GO
USE [internom]
GO
/****** Object:  Table [dbo].[catalogorutas]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[catalogorutas](
	[id_catalogoruta] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_catalogorutas] PRIMARY KEY CLUSTERED 
(
	[id_catalogoruta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[departamentos]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[departamentos](
	[id_departamento] [int] IDENTITY(1,1) NOT NULL,
	[nombre_dpto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_departamentos] PRIMARY KEY CLUSTERED 
(
	[id_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[empleados]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[empleados](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[seguro] [varchar](50) NOT NULL,
	[fecha_ingreso] [date] NOT NULL,
	[id_departamento] [int] NOT NULL,
	[no_nomina] [varchar](50) NOT NULL,
	[cargo] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
 CONSTRAINT [PK_empleados] PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[empleadovis]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[empleadovis](
	[id_empleadovi] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[id_departamento] [int] NOT NULL,
 CONSTRAINT [PK_empleadovis] PRIMARY KEY CLUSTERED 
(
	[id_empleadovi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[faltas]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[faltas](
	[id_falta] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](150) NULL,
	[fecha] [date] NOT NULL,
	[id_empleado] [int] NOT NULL,
 CONSTRAINT [PK_faltas] PRIMARY KEY CLUSTERED 
(
	[id_falta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[horarios]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[horarios](
	[id_horario] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[hora_ingreso] [time](7) NOT NULL,
	[entrada_comida] [time](7) NOT NULL,
	[salida_comida] [time](7) NOT NULL,
	[hora_salida] [time](7) NOT NULL,
	[horas_trabajadas] [time](7) NOT NULL,
	[id_empleado] [int] NOT NULL,
 CONSTRAINT [PK_horarios] PRIMARY KEY CLUSTERED 
(
	[id_horario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nominas]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nominas](
	[id_nomina] [int] IDENTITY(1,1) NOT NULL,
	[id_horario] [int] NOT NULL,
	[id_vacacion] [int] NOT NULL,
	[id_empleado] [int] NOT NULL,
	[salario_ordinario] [int] NOT NULL,
	[bono_asistencia] [int] NOT NULL,
	[isr] [int] NOT NULL,
	[imss] [int] NOT NULL,
	[deduccion_total] [int] NOT NULL,
	[pago_neto] [int] NOT NULL,
	[bono_puntualidad] [int] NOT NULL,
 CONSTRAINT [PK_nominas] PRIMARY KEY CLUSTERED 
(
	[id_nomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[permisos]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[permisos](
	[id_permiso] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](150) NOT NULL,
	[fecha] [date] NOT NULL,
	[id_empleado] [int] NOT NULL,
 CONSTRAINT [PK_permisos] PRIMARY KEY CLUSTERED 
(
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rutas]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rutas](
	[id_ruta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_ruta] [varchar](50) NOT NULL,
	[fecha_salida] [date] NOT NULL,
	[fecha_llegada] [date] NOT NULL,
	[hora_salida] [time](7) NOT NULL,
	[hora_llegada] [time](7) NOT NULL,
	[notas] [varchar](100) NOT NULL,
	[horas_trabajadas] [time](7) NOT NULL,
	[id_catalogoruta] [int] NOT NULL,
 CONSTRAINT [PK_rutas] PRIMARY KEY CLUSTERED 
(
	[id_ruta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vacaciones]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacaciones](
	[id_vacacion] [int] IDENTITY(1,1) NOT NULL,
	[id_empleado] [int] NOT NULL,
	[dias_otorgados] [int] NOT NULL,
	[dias_tomados] [int] NOT NULL,
	[dias_restantes] [int] NOT NULL,
	[prima_vacacional] [int] NOT NULL,
 CONSTRAINT [PK_vacaciones] PRIMARY KEY CLUSTERED 
(
	[id_vacacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[visitantes]    Script Date: 04/08/2017 11:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[visitantes](
	[id_visitante] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[compañia] [varchar](50) NOT NULL,
	[persona_visitada] [varchar](50) NOT NULL,
	[departamento] [varchar](50) NOT NULL,
	[hora_entrada] [time](7) NOT NULL,
	[hora_salida] [time](7) NULL,
 CONSTRAINT [PK_visitantes] PRIMARY KEY CLUSTERED 
(
	[id_visitante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[empleados]  WITH CHECK ADD  CONSTRAINT [FK_empleados_departamentos] FOREIGN KEY([id_departamento])
REFERENCES [dbo].[departamentos] ([id_departamento])
GO
ALTER TABLE [dbo].[empleados] CHECK CONSTRAINT [FK_empleados_departamentos]
GO
ALTER TABLE [dbo].[faltas]  WITH CHECK ADD  CONSTRAINT [FK_faltas_empleados] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[empleados] ([id_empleado])
GO
ALTER TABLE [dbo].[faltas] CHECK CONSTRAINT [FK_faltas_empleados]
GO
ALTER TABLE [dbo].[nominas]  WITH CHECK ADD  CONSTRAINT [FK_nominas_empleados] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[empleados] ([id_empleado])
GO
ALTER TABLE [dbo].[nominas] CHECK CONSTRAINT [FK_nominas_empleados]
GO
ALTER TABLE [dbo].[nominas]  WITH CHECK ADD  CONSTRAINT [FK_nominas_horarios] FOREIGN KEY([id_horario])
REFERENCES [dbo].[horarios] ([id_horario])
GO
ALTER TABLE [dbo].[nominas] CHECK CONSTRAINT [FK_nominas_horarios]
GO
ALTER TABLE [dbo].[nominas]  WITH CHECK ADD  CONSTRAINT [FK_nominas_vacaciones] FOREIGN KEY([id_vacacion])
REFERENCES [dbo].[vacaciones] ([id_vacacion])
GO
ALTER TABLE [dbo].[nominas] CHECK CONSTRAINT [FK_nominas_vacaciones]
GO
ALTER TABLE [dbo].[permisos]  WITH CHECK ADD  CONSTRAINT [FK_permisos_empleados] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[empleados] ([id_empleado])
GO
ALTER TABLE [dbo].[permisos] CHECK CONSTRAINT [FK_permisos_empleados]
GO
USE [master]
GO
ALTER DATABASE [internom] SET  READ_WRITE 
GO
