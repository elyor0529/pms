USE [RealEstate]
GO
/****** Object:  Schema [RE]    Script Date: 3/8/2016 9:36:19 PM ******/
CREATE SCHEMA [RE]
GO
/****** Object:  Table [RE].[Addresses]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [RE].[Addresses](
	[AddressId] [int] NOT NULL,
	[Unit] [nvarchar](50) NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[CountryCode] [char](2) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [RE].[AddressTypes]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[AddressTypes](
	[AddressTypeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AddressTypes] PRIMARY KEY CLUSTERED 
(
	[AddressTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[Companies]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[Companies](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[ContactInfos]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[ContactInfos](
	[ContactInfoId] [int] IDENTITY(1,1) NOT NULL,
	[ContactInfoTypeId] [smallint] NULL,
	[ContactInfo] [nvarchar](250) NULL,
 CONSTRAINT [PK_ContactInfos] PRIMARY KEY CLUSTERED 
(
	[ContactInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[ContactInfoTypes]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[ContactInfoTypes](
	[ContactInfoTypeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContactInfoTypes] PRIMARY KEY CLUSTERED 
(
	[ContactInfoTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[ContactInfoUsageTypes]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[ContactInfoUsageTypes](
	[ContactInfoUsageTypeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContactInfoUsageTypes] PRIMARY KEY CLUSTERED 
(
	[ContactInfoUsageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[Countries]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [RE].[Countries](
	[CountryCode] [char](2) NOT NULL,
	[Country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [RE].[Lease]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[Lease](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeaseTypeId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Deposit] [float] NULL,
	[DelinquentAfter] [int] NULL,
	[MoveInDate] [datetime] NULL,
	[Rent] [float] NULL,
	[PaymentFreqId] [int] NULL,
	[PaymentTypeId] [int] NULL,
	[QuickPayId] [int] NULL,
	[Notes] [nvarchar](max) NULL,
	[PetsFlag] [bit] NULL,
	[SmokingFlag] [bit] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Lease] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [RE].[LeaseFiles]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[LeaseFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeaseId] [int] NULL,
	[Path] [nvarchar](150) NULL,
 CONSTRAINT [PK_LeaseFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[LeaseType]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[LeaseType](
	[Id] [int] NOT NULL,
	[LeaseType] [nvarchar](50) NULL,
 CONSTRAINT [PK_LeaseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[PaymentFrequency]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[PaymentFrequency](
	[Id] [int] NOT NULL,
	[PaymentFreq] [nvarchar](50) NULL,
 CONSTRAINT [PK_PaymentFrequency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[PaymentTypes]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[PaymentTypes](
	[Id] [int] NOT NULL,
	[PaymentType] [nvarchar](50) NULL,
 CONSTRAINT [PK_PaymentTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[PrincipalRelationTypes]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[PrincipalRelationTypes](
	[PrincipalRelationTypeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PrincipalRelationTypes] PRIMARY KEY CLUSTERED 
(
	[PrincipalRelationTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[Properties]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [RE].[Properties](
	[PropertyId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyTypeId] [int] NOT NULL,
	[IsEndUnit] [bit] NOT NULL,
	[ParentID] [int] NULL,
	[AddressId] [int] NULL,
	[DisplayOrder] [int] NOT NULL,
	[RecordStatus] [smallint] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[DateBuild] [varchar](50) NULL,
	[Area] [decimal](9, 2) NULL,
	[RentalStatus] [smallint] NULL,
	[Notes] [nvarchar](max) NULL,
	[Unit] [nvarchar](50) NULL,
	[StreetAdress] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[CountryCode] [char](2) NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [RE].[PropertyTenantMap]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[PropertyTenantMap](
	[PropertyTenantMapId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[IsProspect] [bit] NOT NULL,
	[IsOwner] [bit] NOT NULL,
 CONSTRAINT [PK_EntityTenantMap] PRIMARY KEY CLUSTERED 
(
	[PropertyTenantMapId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[PropertyTypes]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[PropertyTypes](
	[PropertyTypeId] [int] NOT NULL,
	[PropertyType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EntityTypes] PRIMARY KEY CLUSTERED 
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[RecordStatuses]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[RecordStatuses](
	[RecordStatusId] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RecordStatuses] PRIMARY KEY CLUSTERED 
(
	[RecordStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[RentalStatuses]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[RentalStatuses](
	[RentalStatusId] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RentalStatuses] PRIMARY KEY CLUSTERED 
(
	[RentalStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [RE].[TenantAddressMap]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[TenantAddressMap](
	[TenantAddressMapId] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[AddressTypeId] [smallint] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_TenantAddressMap] PRIMARY KEY CLUSTERED 
(
	[TenantAddressMapId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [RE].[TenantContactInfoMap]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[TenantContactInfoMap](
	[TenantContactInfoMapId] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [int] NOT NULL,
	[ContactInfoId] [int] NOT NULL,
	[ContactInfoUsageTypeId] [smallint] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_TenantContactInfoMap_1] PRIMARY KEY CLUSTERED 
(
	[TenantContactInfoMapId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [RE].[Tenants]    Script Date: 3/8/2016 9:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RE].[Tenants](
	[TenantID] [int] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PrincipalTenantID] [int] NULL,
	[PrincipalRelationTypeID] [smallint] NOT NULL,
	[HomePhone] [nvarchar](25) NULL,
	[WorkPhone] [nvarchar](25) NULL,
	[CellPhone] [nvarchar](25) NULL,
	[Email] [nvarchar](50) NULL,
	[DOB] [datetime] NULL,
	[Status] [smallint] NULL,
	[Notes] [nvarchar](max) NULL,
	[LeaseId] [int] NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [RE].[Properties] ADD  CONSTRAINT [DF_Properties_IsEndUnit]  DEFAULT ((0)) FOR [IsEndUnit]
GO
ALTER TABLE [RE].[Properties] ADD  CONSTRAINT [DF_Properties_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [RE].[PropertyTenantMap] ADD  CONSTRAINT [DF_EntityTenantMap_IsProspect]  DEFAULT ((0)) FOR [IsProspect]
GO
ALTER TABLE [RE].[PropertyTenantMap] ADD  CONSTRAINT [DF_EntityTenantMap_IsOwner]  DEFAULT ((0)) FOR [IsOwner]
GO
ALTER TABLE [RE].[TenantContactInfoMap] ADD  CONSTRAINT [DF_TenantContactInfoMap_ContactInfoUsageTypeId]  DEFAULT ((1)) FOR [ContactInfoUsageTypeId]
GO
ALTER TABLE [RE].[Tenants] ADD  CONSTRAINT [DF_Tenants_PrincipalRelationTypeiD]  DEFAULT ((1)) FOR [PrincipalRelationTypeID]
GO
ALTER TABLE [RE].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Countries] FOREIGN KEY([CountryCode])
REFERENCES [RE].[Countries] ([CountryCode])
GO
ALTER TABLE [RE].[Addresses] CHECK CONSTRAINT [FK_Addresses_Countries]
GO
ALTER TABLE [RE].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_Properties] FOREIGN KEY([PropertyId])
REFERENCES [RE].[Properties] ([PropertyId])
GO
ALTER TABLE [RE].[Companies] CHECK CONSTRAINT [FK_Companies_Properties]
GO
ALTER TABLE [RE].[ContactInfos]  WITH CHECK ADD  CONSTRAINT [FK_ContactInfos_ContactInfoTypes] FOREIGN KEY([ContactInfoTypeId])
REFERENCES [RE].[ContactInfoTypes] ([ContactInfoTypeId])
GO
ALTER TABLE [RE].[ContactInfos] CHECK CONSTRAINT [FK_ContactInfos_ContactInfoTypes]
GO
ALTER TABLE [RE].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_LeaseType] FOREIGN KEY([LeaseTypeId])
REFERENCES [RE].[LeaseType] ([Id])
GO
ALTER TABLE [RE].[Lease] CHECK CONSTRAINT [FK_Lease_LeaseType]
GO
ALTER TABLE [RE].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_PaymentFrequency] FOREIGN KEY([PaymentFreqId])
REFERENCES [RE].[PaymentFrequency] ([Id])
GO
ALTER TABLE [RE].[Lease] CHECK CONSTRAINT [FK_Lease_PaymentFrequency]
GO
ALTER TABLE [RE].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_PaymentTypes] FOREIGN KEY([PaymentTypeId])
REFERENCES [RE].[PaymentTypes] ([Id])
GO
ALTER TABLE [RE].[Lease] CHECK CONSTRAINT [FK_Lease_PaymentTypes]
GO
ALTER TABLE [RE].[LeaseFiles]  WITH CHECK ADD  CONSTRAINT [FK_LeaseFiles_Lease] FOREIGN KEY([LeaseId])
REFERENCES [RE].[Lease] ([Id])
GO
ALTER TABLE [RE].[LeaseFiles] CHECK CONSTRAINT [FK_LeaseFiles_Lease]
GO
ALTER TABLE [RE].[Properties]  WITH CHECK ADD  CONSTRAINT [FK_Properties_Addresses] FOREIGN KEY([AddressId])
REFERENCES [RE].[Addresses] ([AddressId])
GO
ALTER TABLE [RE].[Properties] CHECK CONSTRAINT [FK_Properties_Addresses]
GO
ALTER TABLE [RE].[Properties]  WITH CHECK ADD  CONSTRAINT [FK_Properties_EntityTypes] FOREIGN KEY([PropertyTypeId])
REFERENCES [RE].[PropertyTypes] ([PropertyTypeId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [RE].[Properties] CHECK CONSTRAINT [FK_Properties_EntityTypes]
GO
ALTER TABLE [RE].[Properties]  WITH CHECK ADD  CONSTRAINT [FK_Properties_Properties] FOREIGN KEY([ParentID])
REFERENCES [RE].[Properties] ([PropertyId])
GO
ALTER TABLE [RE].[Properties] CHECK CONSTRAINT [FK_Properties_Properties]
GO
ALTER TABLE [RE].[Properties]  WITH CHECK ADD  CONSTRAINT [FK_Properties_RecordStatuses] FOREIGN KEY([RecordStatus])
REFERENCES [RE].[RecordStatuses] ([RecordStatusId])
GO
ALTER TABLE [RE].[Properties] CHECK CONSTRAINT [FK_Properties_RecordStatuses]
GO
ALTER TABLE [RE].[Properties]  WITH CHECK ADD  CONSTRAINT [FK_Properties_RentalStatuses] FOREIGN KEY([RentalStatus])
REFERENCES [RE].[RentalStatuses] ([RentalStatusId])
GO
ALTER TABLE [RE].[Properties] CHECK CONSTRAINT [FK_Properties_RentalStatuses]
GO
ALTER TABLE [RE].[PropertyTenantMap]  WITH CHECK ADD  CONSTRAINT [FK_EntityTenantMap_Properties] FOREIGN KEY([PropertyId])
REFERENCES [RE].[Properties] ([PropertyId])
GO
ALTER TABLE [RE].[PropertyTenantMap] CHECK CONSTRAINT [FK_EntityTenantMap_Properties]
GO
ALTER TABLE [RE].[PropertyTenantMap]  WITH CHECK ADD  CONSTRAINT [FK_EntityTenantMap_Tenants] FOREIGN KEY([TenantId])
REFERENCES [RE].[Tenants] ([TenantID])
GO
ALTER TABLE [RE].[PropertyTenantMap] CHECK CONSTRAINT [FK_EntityTenantMap_Tenants]
GO
ALTER TABLE [RE].[TenantAddressMap]  WITH CHECK ADD  CONSTRAINT [FK_TenantAddressMap_Addresses] FOREIGN KEY([AddressId])
REFERENCES [RE].[Addresses] ([AddressId])
GO
ALTER TABLE [RE].[TenantAddressMap] CHECK CONSTRAINT [FK_TenantAddressMap_Addresses]
GO
ALTER TABLE [RE].[TenantAddressMap]  WITH CHECK ADD  CONSTRAINT [FK_TenantAddressMap_AddressTypes] FOREIGN KEY([AddressTypeId])
REFERENCES [RE].[AddressTypes] ([AddressTypeId])
GO
ALTER TABLE [RE].[TenantAddressMap] CHECK CONSTRAINT [FK_TenantAddressMap_AddressTypes]
GO
ALTER TABLE [RE].[TenantAddressMap]  WITH CHECK ADD  CONSTRAINT [FK_TenantAddressMap_Tenants] FOREIGN KEY([TenantId])
REFERENCES [RE].[Tenants] ([TenantID])
GO
ALTER TABLE [RE].[TenantAddressMap] CHECK CONSTRAINT [FK_TenantAddressMap_Tenants]
GO
ALTER TABLE [RE].[TenantContactInfoMap]  WITH CHECK ADD  CONSTRAINT [FK_TenantContactInfoMap_ContactInfos] FOREIGN KEY([ContactInfoId])
REFERENCES [RE].[ContactInfos] ([ContactInfoId])
GO
ALTER TABLE [RE].[TenantContactInfoMap] CHECK CONSTRAINT [FK_TenantContactInfoMap_ContactInfos]
GO
ALTER TABLE [RE].[TenantContactInfoMap]  WITH CHECK ADD  CONSTRAINT [FK_TenantContactInfoMap_ContactInfoUsageTypes] FOREIGN KEY([ContactInfoUsageTypeId])
REFERENCES [RE].[ContactInfoUsageTypes] ([ContactInfoUsageTypeId])
GO
ALTER TABLE [RE].[TenantContactInfoMap] CHECK CONSTRAINT [FK_TenantContactInfoMap_ContactInfoUsageTypes]
GO
ALTER TABLE [RE].[TenantContactInfoMap]  WITH CHECK ADD  CONSTRAINT [FK_TenantContactInfoMap_Tenants] FOREIGN KEY([TenantId])
REFERENCES [RE].[Tenants] ([TenantID])
GO
ALTER TABLE [RE].[TenantContactInfoMap] CHECK CONSTRAINT [FK_TenantContactInfoMap_Tenants]
GO
ALTER TABLE [RE].[Tenants]  WITH CHECK ADD  CONSTRAINT [FK_Tenants_Lease] FOREIGN KEY([LeaseId])
REFERENCES [RE].[Lease] ([Id])
GO
ALTER TABLE [RE].[Tenants] CHECK CONSTRAINT [FK_Tenants_Lease]
GO
ALTER TABLE [RE].[Tenants]  WITH CHECK ADD  CONSTRAINT [FK_Tenants_PrincipalRelationTypes] FOREIGN KEY([PrincipalRelationTypeID])
REFERENCES [RE].[PrincipalRelationTypes] ([PrincipalRelationTypeId])
GO
ALTER TABLE [RE].[Tenants] CHECK CONSTRAINT [FK_Tenants_PrincipalRelationTypes]
GO
