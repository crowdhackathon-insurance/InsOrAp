USE [master]
GO
/****** Object:  Database [Insorama]    Script Date: 2/10/2016 3:21:39 μμ ******/
CREATE DATABASE [Insorama]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Insorama', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS2016\MSSQL\DATA\Insorama.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Insorama_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS2016\MSSQL\DATA\Insorama_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Insorama] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Insorama].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Insorama] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Insorama] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Insorama] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Insorama] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Insorama] SET ARITHABORT OFF 
GO
ALTER DATABASE [Insorama] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Insorama] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Insorama] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Insorama] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Insorama] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Insorama] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Insorama] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Insorama] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Insorama] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Insorama] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Insorama] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Insorama] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Insorama] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Insorama] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Insorama] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Insorama] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Insorama] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Insorama] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Insorama] SET  MULTI_USER 
GO
ALTER DATABASE [Insorama] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Insorama] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Insorama] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Insorama] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Insorama] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Insorama] SET QUERY_STORE = OFF
GO
USE [Insorama]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Insorama]
GO
/****** Object:  Table [dbo].[InsOr_ASFALISTHS]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_ASFALISTHS](
	[KWDASFALISTH] [int] NOT NULL,
	[EPWNYMO] [varchar](50) NOT NULL,
	[ONOMA] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ASFALISTHS] PRIMARY KEY CLUSTERED 
(
	[KWDASFALISTH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsOr_KLEIDARI8MOS]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_KLEIDARI8MOS](
	[KWDKLEIDAR] [int] NOT NULL,
	[KLEIDAR] [nvarchar](1000) NOT NULL,
	[KLEIDAR_Used] [tinyint] NOT NULL,
	[HMEROM_XRHSHS] [date] NULL,
	[WRA_XRHSHS] [time](7) NULL,
 CONSTRAINT [PK_KLEIDARI8MOS] PRIMARY KEY CLUSTERED 
(
	[KWDKLEIDAR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsOr_Log_File]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_Log_File](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Log_Date] [date] NOT NULL,
	[Log_Time] [time](7) NOT NULL,
	[Log_Text] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Log_File] PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsOr_PELATHS]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_PELATHS](
	[ENKWDPEL] [int] NOT NULL,
	[EPWNYMO] [varchar](50) NOT NULL,
	[ONOMA] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[KLEIDAR] [nvarchar](1000) NULL,
	[ASFALISTHS] [int] NULL,
 CONSTRAINT [PK_PELATHS] PRIMARY KEY CLUSTERED 
(
	[ENKWDPEL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsOr_PRAGMAT]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_PRAGMAT](
	[KWD_PRAGM] [int] NOT NULL,
	[EPWNYMO] [varchar](50) NOT NULL,
	[ONOMA] [varchar](50) NOT NULL,
	[THLEFWNO1] [varchar](30) NOT NULL,
	[THLEFWNO2] [varchar](30) NULL,
	[PRAGM_Email] [varchar](50) NOT NULL,
	[DIA8ESIMOS] [tinyint] NOT NULL,
 CONSTRAINT [PK_PRAGMAT] PRIMARY KEY CLUSTERED 
(
	[KWD_PRAGM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsOr_SYMBAN]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_SYMBAN](
	[SYMBAN_ID] [int] IDENTITY(1,1) NOT NULL,
	[SYMBAN_STATUS] [tinyint] NULL,
	[HMNIA] [date] NOT NULL,
	[WRA] [time](7) NOT NULL,
	[KWDPEL] [int] NOT NULL,
	[KWDSYM] [varchar](10) NOT NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
	[Tel1] [varchar](30) NULL,
	[Tel2] [varchar](30) NULL,
	[ANAGKH_166] [tinyint] NULL,
	[ANAGKH_100] [tinyint] NULL,
	[ANAGKH_OD_BOH8EIA] [tinyint] NULL,
	[ANAGKH_NOM_KAL] [tinyint] NULL,
	[YPAITIOTHTA] [tinyint] NULL,
	[FIL_DIAK] [tinyint] NULL,
	[EMPLEK_AR_KYKL] [varchar](10) NULL,
	[EMPLEK_ONOMAT] [varchar](100) NULL,
	[FIL_DIAK_PARAT] [ntext] NULL,
	[KLHSH_166] [datetime] NULL,
	[KLHSH_100] [datetime] NULL,
	[KLHSH_OD_BOH8EIA] [datetime] NULL,
	[KLHSH_NOM_PRO] [datetime] NULL,
	[KWDPRAGM] [int] NULL,
	[KLHSH_PRAGM] [datetime] NULL,
	[OLOKL_166] [datetime] NULL,
	[OLOKL_100] [datetime] NULL,
	[OLOKL_OD_BOH8] [datetime] NULL,
	[OLOKL_NOM_PRO] [datetime] NULL,
	[OLOKL_PRAGM] [datetime] NULL,
 CONSTRAINT [PK_SYMBAN] PRIMARY KEY CLUSTERED 
(
	[SYMBAN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsOr_SYMBAN_DEYTERO]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_SYMBAN_DEYTERO](
	[SYMBAN_DEYTERO_ID] [int] IDENTITY(1,1) NOT NULL,
	[SYMBAN_DEYTERO_STATUS] [tinyint] NULL,
	[SYMBAN_DEYTERO_TYPE] [smallint] NOT NULL,
	[HMNIA] [date] NOT NULL,
	[WRA] [time](7) NOT NULL,
	[KWDPEL] [int] NOT NULL,
	[KWDSYM] [varchar](10) NOT NULL,
	[SYMBAN_DEYTERO_TEXT] [nvarchar](200) NULL,
	[KWD_PRAGM] [int] NULL,
	[KLHSH_PRAGM] [datetime] NULL,
	[OLOKL_PRAGM] [datetime] NULL,
 CONSTRAINT [PK_InsOr_SYMBAN_DEYTERO] PRIMARY KEY CLUSTERED 
(
	[SYMBAN_DEYTERO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsOr_SYMBAN_DEYTERO_TYPES]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_SYMBAN_DEYTERO_TYPES](
	[SYMBAN_DEYTERO_TYPE] [smallint] NOT NULL,
	[SYMBAN_DEYTERO_TYPE_DESCR] [varchar](50) NOT NULL,
 CONSTRAINT [PK_InsOr_SYMBAN_DEYTERO_TYPES] PRIMARY KEY CLUSTERED 
(
	[SYMBAN_DEYTERO_TYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsOr_SYMBOLAIO]    Script Date: 2/10/2016 3:21:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsOr_SYMBOLAIO](
	[KWDSYM] [varchar](10) NOT NULL,
	[KVDPEL] [int] NOT NULL,
	[ARKYKL] [varchar](10) NOT NULL,
	[MARKA] [varchar](50) NOT NULL,
	[KLOPH] [tinyint] NOT NULL,
	[PYRKAIA] [tinyint] NOT NULL,
	[KRYSTALLA] [tinyint] NOT NULL,
	[ODIKH] [tinyint] NOT NULL,
	[NOMIKH] [tinyint] NOT NULL,
	[HMEROMAPO] [datetime] NOT NULL,
	[HMEROMEWS] [datetime] NOT NULL,
 CONSTRAINT [PK_SYMBOLAIO] PRIMARY KEY CLUSTERED 
(
	[KWDSYM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [Insorama] SET  READ_WRITE 
GO
