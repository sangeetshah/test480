--- Permission Profile menu
Insert Into [dbo].[PermissionRecord] values('Admin area. Access Profile','Profile.AccessProfile','Profile')
Insert Into [dbo].[PermissionRecord] values('Admin area. Profile Create, edit, delete','Profile.CreateEditDelete','Profile')

--- Drop profile table
DROP TABLE [dbo].[Profile]

-------- Profile
CREATE TABLE [dbo].[Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantId] [nvarchar](400) NOT NULL,
    [GivenName] nvarchar(400) null,
	[FamilyName] nvarchar(400) null,
    [DateOfBirth] [datetime2](7) NULL,
	[GenderCode] nvarchar(400) null,
	[PrimaryCitizenship] nvarchar(400) null,
	[Citizenship1Id] int not null default 0,
	[Citizenship2Id] int not null default 0,
	[Email] [nvarchar](400) NOT NULL,
	[Mobile1] nvarchar(400) null,
	[Mobile2] nvarchar(400) null,
	[WhtasppMobile] nvarchar(400) null,
    [Address1Line1] nvarchar(400) null,
	[Address1Line2] nvarchar(400) null,	
	[Address1CountryId] int not null default 0,
	[Address1StateProvinceId] int not null default 0,
	[Address1City] nvarchar(400) null,
	[Address1PostalCode] nvarchar(400) null,
	[Address2Line1] nvarchar(400) null,
	[Address2Line2] nvarchar(400) null,	
	[Address2CountryId] int not null default 0,
	[Address2StateProvinceId] int not null default 0,
	[Address2City] nvarchar(400) null,
	[Address2PostalCode] nvarchar(400) null,	
	[MaritalStatusCode] nvarchar(400) null,
	[HasSponsor] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
    [UpdatedAt] [datetime2](7) NULL,
	[CreatedBy] nvarchar(400) null,
	[UpdatedBy] nvarchar(400) null,
	[AadharNo] nvarchar(400) null,
	[FacebookId1] nvarchar(400) null,
	[FacebookId2] nvarchar(400) null,
	[InstagramId1] nvarchar(400) null,
	[InstagramId2] nvarchar(400) null,
	[LinkedInURL] nvarchar(400) null,
	[TwitterId] nvarchar(400) null,
	[PhotoId] int not null default 0,
	[ResumeId] int not null default 0
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--- Permission Passport menu
Insert Into [dbo].[PermissionRecord] values('Admin area. Access Passport','Passport.AccessPassport','Passport')
Insert Into [dbo].[PermissionRecord] values('Admin area. Passport Create, edit, delete','Passport.CreateEditDelete','Passport')

-------- Passport
CREATE TABLE [dbo].[Passport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantId] int NOT NULL,
	[PassportNumber] nvarchar(400) NOT NULL,
	[IssuingCountry] nvarchar(400) NOT NULL,
	[IssueDate] [datetime2](7) NOT NULL,
    [ExpiryDate] [datetime2](7) NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[BirthPlace] nvarchar(400) NULL,
	[PlaceOfIssue] nvarchar(400) NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[UploadedAt] [datetime2](7) NOT NULL,
	[UploadedBy] nvarchar(400) NOT NULL,
	[FileId] int NOT NULL default 0
 CONSTRAINT [PK_Passport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


--- Permission Education menu
Insert Into [dbo].[PermissionRecord] values('Admin area. Access Education','Education.AccessEducation','Education')
Insert Into [dbo].[PermissionRecord] values('Admin area. Education Create, edit, delete','Education.CreateEditDelete','Education')

-------- Education
CREATE TABLE [dbo].[Education](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantId] int NOT NULL,
	[StandardId] int NOT NULL,
	[CourseName] nvarchar(400) NOT NULL,
	[FieldOfStudy] nvarchar(400) NOT NULL,
	[Institution] nvarchar(400) NOT NULL,
	[University] nvarchar(400) NOT NULL,
	[Address] nvarchar(400) null,
	[City] nvarchar(400) null,
	[CountryCode] nvarchar(400) null,
	[GraduationYear] int NOT NULL,
	[GPA] decimal(18,4) NOT NULL,
	[IsHighest] [bit] NOT NULL,	
	[UploadedAt] [datetime2](7) NOT NULL,
	[UploadedBy] nvarchar(400) NOT NULL,
	[Certificate1Id] int NOT NULL default 0,
	[Certificate2Id] int NOT NULL default 0
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--- Permission Work menu
Insert Into [dbo].[PermissionRecord] values('Admin area. Access Work','Work.AccessWork','Work')
Insert Into [dbo].[PermissionRecord] values('Admin area. Work Create, edit, delete','Work.CreateEditDelete','Work')

-------- Work
CREATE TABLE [dbo].[Work](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantId] int NOT NULL,
	[EmploymentStatusId] int NOT NULL,
	[JobTitle] nvarchar(400) NOT NULL,
	[EmployerOrBusiness] nvarchar(400) NOT NULL,	
	[Address] nvarchar(400) null,
	[City] nvarchar(400) null,
	[CountryCode] nvarchar(400) null,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[AnnunalIncomeAmount] decimal(18,4) NOT NULL,
	[TaxFiled] [bit] NOT NULL,
	[TaxDeclaredIncome] decimal(18,4) NOT NULL,
	[TaxCurrency] nvarchar(400) null,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] nvarchar(400) NULL,
	[OfferLetterId] int NOT NULL default 0,
	[RelievingLetterId] int NOT NULL default 0
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--- Permission Finance menu
Insert Into [dbo].[PermissionRecord] values('Admin area. Access Finance','Finance.AccessFinance','Finance')
Insert Into [dbo].[PermissionRecord] values('Admin area. Finance Create, edit, delete','Finance.CreateEditDelete','Finance')

-------- Finance
CREATE TABLE [dbo].[Finance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantId] int NOT NULL,
	[RecordTypeId] int NOT NULL,
	[BankName] nvarchar(400) NOT NULL,
	[AccountMask] nvarchar(400) NOT NULL,	
	[Currency] decimal(18,4) NOT NULL,
	[PeriodStart] [datetime2](7) NULL,
	[PeriodEnd] [datetime2](7) NULL,
	[AvgBalance] decimal(18,4) NOT NULL,
	[AssetTypeId] int NOT NULL,
	[Amount] decimal(18,4) NOT NULL,
	[Notes] nvarchar(400) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] nvarchar(400) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] nvarchar(400) NULL,
	[DocumentId] int NOT NULL default 0	
 CONSTRAINT [PK_Finance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--- Permission Health menu
Insert Into [dbo].[PermissionRecord] values('Admin area. Access Health','Health.AccessHealth','Health')
Insert Into [dbo].[PermissionRecord] values('Admin area. Health Health Create, edit, delete','Health.CreateEditDelete','Health')

-------- Health
CREATE TABLE [dbo].[Health](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantId] int NOT NULL,
	[RelevantConditionId] int NOT NULL,
	[Notes] nvarchar(400) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] nvarchar(400) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] nvarchar(400) NULL,
	[Record1Id] int NOT NULL default 0,
	[Record2Id] int NOT NULL default 0
 CONSTRAINT [PK_Health] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


--- Permission ChangePassword menu
Insert Into [dbo].[PermissionRecord] values('Admin area. Access ChangePassword','ChangePassword.AccessChangePassword','ChangePassword')