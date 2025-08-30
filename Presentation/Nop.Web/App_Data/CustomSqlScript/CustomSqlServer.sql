--- Permission Profile menu
Insert Into [dbo].[PermissionRecord] values('Admin area. Access Profile','Profile.AccessProfile','Profile')


-------- Profile
CREATE TABLE [dbo].[Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantId] [nvarchar](400) NOT NULL,
    [GivenName] nvarchar(400) null,
	[FamilyName] nvarchar(400) null,
    [DateOfBirth] [datetime2](7) NULL,
	[GenderCode] nvarchar(400) null,
	[PrimaryCitizenship] nvarchar(400) null,
	[Citizenship1] nvarchar(400) null,
	[Citizenship2] nvarchar(400) null,
	[Email] [nvarchar](400) NOT NULL,
	[Mobile1] nvarchar(400) null,
	[Mobile2] nvarchar(400) null,
	[WhtasppMobile] nvarchar(400) null,
    [Address1Line1] nvarchar(400) null,
	[Address1Line2] nvarchar(400) null,
	[Address1City] nvarchar(400) null,
	[Address1StateProvince] nvarchar(400) null,
	[Address1PostalCode] nvarchar(400) null,
	[Address1Country] nvarchar(400) null,
	[Address2Line1] nvarchar(400) null,
	[Address2Line2] nvarchar(400) null,
	[Address2City] nvarchar(400) null,
	[Address2StateProvince] nvarchar(400) null,
	[Address2PostalCode] nvarchar(400) null,
	[Address2Country] nvarchar(400) null,
	[MaritalStatusCode] nvarchar(400) null,
	[HasSponsor] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
    [UpdatedAt] [datetime2](7) NOT NULL,
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