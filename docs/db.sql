-- we don't know how to generate database opieandanthonylive10 (class Database) :(
create table ArchiveFileTypeInfos
(
  ArchiveFileTypeInfoID int identity,
  Extension             nvarchar(20)  not null,
  Description           nvarchar(200) not null,
  constraint PK_ArchiveFileTypeInfos
  primary key (ArchiveFileTypeInfoID)
)
go

create table AudibleMediaItems
(
  AudibleMediaItemID     int identity,
  ItemTypeClassification nvarchar(30)  not null,
  Title                  nvarchar(200) not null,
  By                     nvarchar(100) not null,
  NarratedBy             nvarchar(100) not null,
  FullShowMetadataUrl    nvarchar(500) not null,
  PlaybackLength         time          not null,
  ReleaseDate            datetime2     not null,
  AverageRating          float,
  NumberOfRatings        int           not null,
  constraint PK_AudibleMediaItems
  primary key (AudibleMediaItemID)
)
go

create table ContentCreators
(
  ContentCreatorID   int identity,
  ContentCreatorName nvarchar(50) not null,
  constraint PK_ContentCreators
  primary key (ContentCreatorID)
)
go

create table EmbeddedContentSources
(
  EmbeddedContentSourceID   int identity,
  EmbeddedContentSourceName nvarchar(50) not null,
  constraint PK_EmbeddedContentSources
  primary key (EmbeddedContentSourceID)
)
go

create unique index UIX_EmbeddedContentSource_EmbeddedContentSourceName
  on EmbeddedContentSources (EmbeddedContentSourceName)
go

create table Genders
(
  GenderID     int identity,
  Abbreviation nvarchar(5)   not null,
  GenderName   nvarchar(200) not null,
  constraint PK_Genders
  primary key (GenderID)
)
go

create unique index UIX_Gender_GenderName
  on Genders (GenderName)
go

create table GuestAppearanceTypes
(
  GuestAppearanceTypeID int identity,
  AppearanceTypeName    nvarchar(150) not null,
  constraint PK_GuestAppearanceTypes
  primary key (GuestAppearanceTypeID)
)
go

create unique index IX_GuestAppearanceType_AppearanceTypeName
  on GuestAppearanceTypes (AppearanceTypeName)
go

create table ShowRundownAuthors
(
  ShowRundownAuthorID int identity,
  AuthorName          nvarchar(150) not null,
  constraint PK_ShowRundownAuthors
  primary key (ShowRundownAuthorID)
)
go

create index IX_ShowRundownAuthor_AuthorName
  on ShowRundownAuthors (AuthorName)
go

create table Shows
(
  ShowID   int identity,
  ShowName nvarchar(300) not null,
  constraint PK_Shows
  primary key (ShowID)
)
go

create table ArchiveAlbums
(
  ArchiveAlbumID   int identity,
  Identifier       nvarchar(200) not null,
  ContentCreatorID int,
  Description      nvarchar(500),
  DatePublished    datetime2     not null,
  YearNumber       int           not null,
  MonthNumber      int           not null,
  constraint PK_ArchiveAlbums
  primary key (ArchiveAlbumID),
  constraint FK_ArchiveAlbums_ContentCreators_ContentCreatorID
  foreign key (ContentCreatorID) references ContentCreators
)
go

create index IX_ArchiveAlbums_ContentCreatorID
  on ArchiveAlbums (ContentCreatorID)
go

create table Guests
(
  FirstName         nvarchar(30) not null,
  MiddleName        nvarchar(30),
  LastName          nvarchar(30),
  GenderID          int,
  AlternateName     nvarchar(200),
  GuestID           int identity,
  LegacyGuestID     int,
  Description       nvarchar(400),
  TwitterHandle     nvarchar(200),
  WebsiteUrl        nvarchar(400),
  HeadshotImagePath nvarchar(400),
  constraint PK_Guests
  primary key (GuestID),
  constraint FK_Guests_Genders_GenderID
  foreign key (GenderID) references Genders
)
go

create index IX_Guests_GenderID
  on Guests (GenderID)
go

create table Hosts
(
  FirstName         nvarchar(max),
  MiddleName        nvarchar(max),
  LastName          nvarchar(max),
  GenderID          int,
  AlternateName     nvarchar(200),
  HostID            int identity,
  Description       nvarchar(400),
  TwitterHandle     nvarchar(200),
  WebsiteUrl        nvarchar(400),
  HeadshotImagePath nvarchar(400),
  constraint PK_Hosts
  primary key (HostID),
  constraint FK_Hosts_Genders_GenderID
  foreign key (GenderID) references Genders
)
go

create index IX_Hosts_GenderID
  on Hosts (GenderID)
go

create table ShowMediaEntries
(
  ShowMediaEntryID         int identity,
  ShowID                   int,
  AirDate                  datetime2     not null,
  Title                    nvarchar(400) not null,
  EmbeddedContentSourceUrl nvarchar(1000),
  EmbeddedContentSourceID  int,
  constraint PK_ShowMediaEntries
  primary key (ShowMediaEntryID),
  constraint FK_ShowMediaEntries_Shows_ShowID
  foreign key (ShowID) references Shows,
  constraint FK_ShowMediaEntries_EmbeddedContentSources_EmbeddedContentSourceID
  foreign key (EmbeddedContentSourceID) references EmbeddedContentSources
)
go

create index IX_ShowMediaEntries_EmbeddedContentSourceID
  on ShowMediaEntries (EmbeddedContentSourceID)
go

create index IX_ShowMediaEntries_ShowID
  on ShowMediaEntries (ShowID)
go

create unique index UIX_ShowMediaEntry_Title
  on ShowMediaEntries (Title)
go

create table ShowHosts
(
  ShowHostID int identity,
  ShowID     int not null,
  HostID     int not null,
  constraint PK_ShowHosts
  primary key (ShowID, HostID),
  constraint FK_ShowHosts_Shows_ShowID
  foreign key (ShowID) references Shows
    on delete cascade,
  constraint FK_ShowHosts_Hosts_HostID
  foreign key (HostID) references Hosts
    on delete cascade
)
go

create index IX_ShowHosts_HostID
  on ShowHosts (HostID)
go

create table ShowMediaSegmentContentTags
(
  ShowMediaContentTagID int identity,
  ShowMediaEntryID      int,
  SegmentTimeStart      bigint,
  SegmentTimeEnd        bigint,
  constraint PK_ShowMediaSegmentContentTags
  primary key (ShowMediaContentTagID),
  constraint FK_ShowMediaSegmentContentTags_ShowMediaEntries_ShowMediaEntryID
  foreign key (ShowMediaEntryID) references ShowMediaEntries
)
go

create index IX_ShowMediaSegmentContentTags_ShowMediaEntryID
  on ShowMediaSegmentContentTags (ShowMediaEntryID)
go

create table ArchiveFiles
(
  ArchiveFileID         int identity,
  FileName              nvarchar(200) not null,
  ArchiveFileTypeInfoID int,
  ShowID                int,
  ArchiveAlbumID        int,
  ShowRundownID         int,
  Identifier            nvarchar(200) not null,
  FilePathUrl           nvarchar(500) not null,
  AirDate               datetime2     not null,
  Title                 nvarchar(500) not null,
  LastModifiedDate      datetime2,
  ApproximateBytes      float         not null,
  constraint PK_ArchiveFiles
  primary key (ArchiveFileID),
  constraint FK_ArchiveFiles_ArchiveFileTypeInfos_ArchiveFileTypeInfoID
  foreign key (ArchiveFileTypeInfoID) references ArchiveFileTypeInfos,
  constraint FK_ArchiveFiles_Shows_ShowID
  foreign key (ShowID) references Shows,
  constraint FK_ArchiveFiles_ArchiveAlbums_ArchiveAlbumID
  foreign key (ArchiveAlbumID) references ArchiveAlbums
)
go

create index IX_ArchiveFiles_ArchiveAlbumID
  on ArchiveFiles (ArchiveAlbumID)
go

create index IX_ArchiveFiles_ArchiveFileTypeInfoID
  on ArchiveFiles (ArchiveFileTypeInfoID)
go

create index IX_ArchiveFiles_ShowID
  on ArchiveFiles (ShowID)
go

create index IX_ArchiveFiles_ShowRundownID
  on ArchiveFiles (ShowRundownID)
go

create table ShowRundowns
(
  ShowRundownID       int identity,
  ShowRundownName     nvarchar(200) not null,
  ShowRundownContent  nvarchar(500),
  ArchiveFileID       int,
  ShowRundownAuthorID int,
  AirDate             datetime2     not null,
  DetailsUrl          nvarchar(max) not null,
  constraint PK_ShowRundowns
  primary key (ShowRundownID),
  constraint FK_ShowRundowns_ArchiveFiles_ArchiveFileID
  foreign key (ArchiveFileID) references ArchiveFiles,
  constraint FK_ShowRundowns_ShowRundownAuthors_ShowRundownAuthorID
  foreign key (ShowRundownAuthorID) references ShowRundownAuthors
)
go

alter table ArchiveFiles
  add constraint FK_ArchiveFiles_ShowRundowns_ShowRundownID
foreign key (ShowRundownID) references ShowRundowns
go

create index IX_ShowRundowns_ArchiveFileID
  on ShowRundowns (ArchiveFileID)
go

create index IX_ShowRundowns_ShowRundownAuthorID
  on ShowRundowns (ShowRundownAuthorID)
go

create table GuestAppearances
(
  GuestAppearanceID int identity,
  GuestID           int,
  ShowMediaEntryID  int,
  SegmentTimeStart  bigint,
  SegmentTimeEnd    bigint,
  ArchiveFileID     int,
  ShowRundownID     int,
  constraint PK_GuestAppearances
  primary key (GuestAppearanceID),
  constraint FK_GuestAppearances_Guests_GuestID
  foreign key (GuestID) references Guests,
  constraint FK_GuestAppearances_ShowMediaEntries_ShowMediaEntryID
  foreign key (ShowMediaEntryID) references ShowMediaEntries,
  constraint FK_GuestAppearances_ArchiveFiles_ArchiveFileID
  foreign key (ArchiveFileID) references ArchiveFiles,
  constraint FK_GuestAppearances_ShowRundowns_ShowRundownID
  foreign key (ShowRundownID) references ShowRundowns
)
go

create index IX_GuestAppearances_ArchiveFileID
  on GuestAppearances (ArchiveFileID)
go

create index IX_GuestAppearances_GuestID
  on GuestAppearances (GuestID)
go

create index IX_GuestAppearances_ShowMediaEntryID
  on GuestAppearances (ShowMediaEntryID)
go

create index IX_GuestAppearances_ShowRundownID
  on GuestAppearances (ShowRundownID)
go

create table [__EFMigrationsHistory]
(
  MigrationId    nvarchar(150) not null,
  ProductVersion nvarchar(32)  not null,
  constraint PK___EFMigrationsHistory
  primary key (MigrationId)
)
go

