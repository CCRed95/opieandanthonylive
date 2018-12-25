using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace opieandanthonylive.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ArchiveFileTypeInfos",
                schema: "dbo",
                columns: table => new
                {
                    ArchiveFileTypeInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Extension = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveFileTypeInfos", x => x.ArchiveFileTypeInfoID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudibleMediaItems",
                schema: "dbo",
                columns: table => new
                {
                    AudibleMediaItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemTypeClassification = table.Column<string>(maxLength: 30, nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    By = table.Column<string>(maxLength: 100, nullable: false),
                    NarratedBy = table.Column<string>(maxLength: 100, nullable: false),
                    FullShowMetadataUrl = table.Column<string>(maxLength: 500, nullable: false),
                    PlaybackLength = table.Column<TimeSpan>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    AverageRating = table.Column<double>(nullable: true),
                    NumberOfRatings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudibleMediaItems", x => x.AudibleMediaItemID);
                });

            migrationBuilder.CreateTable(
                name: "ContentCreators",
                schema: "dbo",
                columns: table => new
                {
                    ContentCreatorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentCreatorName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentCreators", x => x.ContentCreatorID);
                });

            migrationBuilder.CreateTable(
                name: "EmbeddedContentSources",
                schema: "dbo",
                columns: table => new
                {
                    EmbeddedContentSourceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmbeddedContentSourceName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmbeddedContentSources", x => x.EmbeddedContentSourceID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "dbo",
                columns: table => new
                {
                    GenderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(maxLength: 5, nullable: false),
                    GenderName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "GuestAppearanceTypes",
                schema: "dbo",
                columns: table => new
                {
                    GuestAppearanceTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppearanceTypeName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestAppearanceTypes", x => x.GuestAppearanceTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ShowRundownAuthors",
                schema: "dbo",
                columns: table => new
                {
                    ShowRundownAuthorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowRundownAuthors", x => x.ShowRundownAuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                schema: "dbo",
                columns: table => new
                {
                    ShowID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowName = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveAlbums",
                schema: "dbo",
                columns: table => new
                {
                    ArchiveAlbumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<string>(maxLength: 200, nullable: false),
                    ContentCreatorID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DatePublished = table.Column<DateTime>(nullable: false),
                    YearNumber = table.Column<int>(nullable: false),
                    MonthNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveAlbums", x => x.ArchiveAlbumID);
                    table.ForeignKey(
                        name: "FK_ArchiveAlbums_ContentCreators_ContentCreatorID",
                        column: x => x.ContentCreatorID,
                        principalSchema: "dbo",
                        principalTable: "ContentCreators",
                        principalColumn: "ContentCreatorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                schema: "dbo",
                columns: table => new
                {
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    GenderID = table.Column<int>(nullable: true),
                    AlternateName = table.Column<string>(maxLength: 200, nullable: true),
                    GuestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LegacyGuestID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    TwitterHandle = table.Column<string>(maxLength: 200, nullable: true),
                    WebsiteUrl = table.Column<string>(maxLength: 400, nullable: true),
                    HeadshotImagePath = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestID);
                    table.ForeignKey(
                        name: "FK_Guests_Genders_GenderID",
                        column: x => x.GenderID,
                        principalSchema: "dbo",
                        principalTable: "Genders",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                schema: "dbo",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    GenderID = table.Column<int>(nullable: true),
                    AlternateName = table.Column<string>(maxLength: 200, nullable: true),
                    HostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    TwitterHandle = table.Column<string>(maxLength: 200, nullable: true),
                    WebsiteUrl = table.Column<string>(maxLength: 400, nullable: true),
                    HeadshotImagePath = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.HostID);
                    table.ForeignKey(
                        name: "FK_Hosts_Genders_GenderID",
                        column: x => x.GenderID,
                        principalSchema: "dbo",
                        principalTable: "Genders",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShowMediaEntries",
                schema: "dbo",
                columns: table => new
                {
                    ShowMediaEntryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowID = table.Column<int>(nullable: true),
                    AirDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 400, nullable: false),
                    EmbeddedContentSourceUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    EmbeddedContentSourceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowMediaEntries", x => x.ShowMediaEntryID);
                    table.ForeignKey(
                        name: "FK_ShowMediaEntries_EmbeddedContentSources_EmbeddedContentSourceID",
                        column: x => x.EmbeddedContentSourceID,
                        principalSchema: "dbo",
                        principalTable: "EmbeddedContentSources",
                        principalColumn: "EmbeddedContentSourceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowMediaEntries_Shows_ShowID",
                        column: x => x.ShowID,
                        principalSchema: "dbo",
                        principalTable: "Shows",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShowHosts",
                schema: "dbo",
                columns: table => new
                {
                    ShowHostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowID = table.Column<int>(nullable: false),
                    HostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowHosts", x => new { x.ShowID, x.HostID });
                    table.ForeignKey(
                        name: "FK_ShowHosts_Hosts_HostID",
                        column: x => x.HostID,
                        principalSchema: "dbo",
                        principalTable: "Hosts",
                        principalColumn: "HostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowHosts_Shows_ShowID",
                        column: x => x.ShowID,
                        principalSchema: "dbo",
                        principalTable: "Shows",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowMediaSegmentContentTags",
                schema: "dbo",
                columns: table => new
                {
                    ShowMediaContentTagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowMediaEntryID = table.Column<int>(nullable: true),
                    SegmentTimeStart = table.Column<long>(nullable: true),
                    SegmentTimeEnd = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowMediaSegmentContentTags", x => x.ShowMediaContentTagID);
                    table.ForeignKey(
                        name: "FK_ShowMediaSegmentContentTags_ShowMediaEntries_ShowMediaEntryID",
                        column: x => x.ShowMediaEntryID,
                        principalSchema: "dbo",
                        principalTable: "ShowMediaEntries",
                        principalColumn: "ShowMediaEntryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveFiles",
                schema: "dbo",
                columns: table => new
                {
                    ArchiveFileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 200, nullable: false),
                    ArchiveFileTypeInfoID = table.Column<int>(nullable: true),
                    ShowID = table.Column<int>(nullable: true),
                    ArchiveAlbumID = table.Column<int>(nullable: true),
                    ShowRundownID = table.Column<int>(nullable: true),
                    Identifier = table.Column<string>(maxLength: 200, nullable: false),
                    FilePathUrl = table.Column<string>(maxLength: 500, nullable: false),
                    AirDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ApproximateBytes = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveFiles", x => x.ArchiveFileID);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_ArchiveAlbums_ArchiveAlbumID",
                        column: x => x.ArchiveAlbumID,
                        principalSchema: "dbo",
                        principalTable: "ArchiveAlbums",
                        principalColumn: "ArchiveAlbumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_ArchiveFileTypeInfos_ArchiveFileTypeInfoID",
                        column: x => x.ArchiveFileTypeInfoID,
                        principalSchema: "dbo",
                        principalTable: "ArchiveFileTypeInfos",
                        principalColumn: "ArchiveFileTypeInfoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_Shows_ShowID",
                        column: x => x.ShowID,
                        principalSchema: "dbo",
                        principalTable: "Shows",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShowRundowns",
                schema: "dbo",
                columns: table => new
                {
                    ShowRundownID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowRundownName = table.Column<string>(maxLength: 200, nullable: false),
                    ShowRundownContent = table.Column<string>(maxLength: 500, nullable: true),
                    ArchiveFileID = table.Column<int>(nullable: true),
                    ShowRundownAuthorID = table.Column<int>(nullable: true),
                    AirDate = table.Column<DateTime>(nullable: false),
                    DetailsUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowRundowns", x => x.ShowRundownID);
                    table.ForeignKey(
                        name: "FK_ShowRundowns_ArchiveFiles_ArchiveFileID",
                        column: x => x.ArchiveFileID,
                        principalSchema: "dbo",
                        principalTable: "ArchiveFiles",
                        principalColumn: "ArchiveFileID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowRundowns_ShowRundownAuthors_ShowRundownAuthorID",
                        column: x => x.ShowRundownAuthorID,
                        principalSchema: "dbo",
                        principalTable: "ShowRundownAuthors",
                        principalColumn: "ShowRundownAuthorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestAppearances",
                schema: "dbo",
                columns: table => new
                {
                    GuestAppearanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuestID = table.Column<int>(nullable: true),
                    ShowMediaEntryID = table.Column<int>(nullable: true),
                    SegmentTimeStart = table.Column<long>(nullable: true),
                    SegmentTimeEnd = table.Column<long>(nullable: true),
                    ArchiveFileID = table.Column<int>(nullable: true),
                    ShowRundownID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestAppearances", x => x.GuestAppearanceID);
                    table.ForeignKey(
                        name: "FK_GuestAppearances_ArchiveFiles_ArchiveFileID",
                        column: x => x.ArchiveFileID,
                        principalSchema: "dbo",
                        principalTable: "ArchiveFiles",
                        principalColumn: "ArchiveFileID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestAppearances_Guests_GuestID",
                        column: x => x.GuestID,
                        principalSchema: "dbo",
                        principalTable: "Guests",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestAppearances_ShowMediaEntries_ShowMediaEntryID",
                        column: x => x.ShowMediaEntryID,
                        principalSchema: "dbo",
                        principalTable: "ShowMediaEntries",
                        principalColumn: "ShowMediaEntryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestAppearances_ShowRundowns_ShowRundownID",
                        column: x => x.ShowRundownID,
                        principalSchema: "dbo",
                        principalTable: "ShowRundowns",
                        principalColumn: "ShowRundownID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveAlbums_ContentCreatorID",
                schema: "dbo",
                table: "ArchiveAlbums",
                column: "ContentCreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ArchiveAlbumID",
                schema: "dbo",
                table: "ArchiveFiles",
                column: "ArchiveAlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ArchiveFileTypeInfoID",
                schema: "dbo",
                table: "ArchiveFiles",
                column: "ArchiveFileTypeInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ShowID",
                schema: "dbo",
                table: "ArchiveFiles",
                column: "ShowID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ShowRundownID",
                schema: "dbo",
                table: "ArchiveFiles",
                column: "ShowRundownID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UIX_EmbeddedContentSource_EmbeddedContentSourceName",
                schema: "dbo",
                table: "EmbeddedContentSources",
                column: "EmbeddedContentSourceName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UIX_Gender_GenderName",
                schema: "dbo",
                table: "Genders",
                column: "GenderName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearances_ArchiveFileID",
                schema: "dbo",
                table: "GuestAppearances",
                column: "ArchiveFileID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearances_GuestID",
                schema: "dbo",
                table: "GuestAppearances",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearances_ShowMediaEntryID",
                schema: "dbo",
                table: "GuestAppearances",
                column: "ShowMediaEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearances_ShowRundownID",
                schema: "dbo",
                table: "GuestAppearances",
                column: "ShowRundownID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearanceType_AppearanceTypeName",
                schema: "dbo",
                table: "GuestAppearanceTypes",
                column: "AppearanceTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_GenderID",
                schema: "dbo",
                table: "Guests",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_GenderID",
                schema: "dbo",
                table: "Hosts",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowHosts_HostID",
                schema: "dbo",
                table: "ShowHosts",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowMediaEntries_EmbeddedContentSourceID",
                schema: "dbo",
                table: "ShowMediaEntries",
                column: "EmbeddedContentSourceID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowMediaEntries_ShowID",
                schema: "dbo",
                table: "ShowMediaEntries",
                column: "ShowID");

            migrationBuilder.CreateIndex(
                name: "UIX_ShowMediaEntry_Title",
                schema: "dbo",
                table: "ShowMediaEntries",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShowMediaSegmentContentTags_ShowMediaEntryID",
                schema: "dbo",
                table: "ShowMediaSegmentContentTags",
                column: "ShowMediaEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowRundownAuthor_AuthorName",
                schema: "dbo",
                table: "ShowRundownAuthors",
                column: "AuthorName");

            migrationBuilder.CreateIndex(
                name: "IX_ShowRundowns_ArchiveFileID",
                schema: "dbo",
                table: "ShowRundowns",
                column: "ArchiveFileID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowRundowns_ShowRundownAuthorID",
                schema: "dbo",
                table: "ShowRundowns",
                column: "ShowRundownAuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_ShowRundowns_ShowRundownID",
                schema: "dbo",
                table: "ArchiveFiles",
                column: "ShowRundownID",
                principalSchema: "dbo",
                principalTable: "ShowRundowns",
                principalColumn: "ShowRundownID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveAlbums_ContentCreators_ContentCreatorID",
                schema: "dbo",
                table: "ArchiveAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ArchiveAlbums_ArchiveAlbumID",
                schema: "dbo",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ArchiveFileTypeInfos_ArchiveFileTypeInfoID",
                schema: "dbo",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_Shows_ShowID",
                schema: "dbo",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ShowRundowns_ShowRundownID",
                schema: "dbo",
                table: "ArchiveFiles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AudibleMediaItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GuestAppearances",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GuestAppearanceTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShowHosts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShowMediaSegmentContentTags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Guests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Hosts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShowMediaEntries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmbeddedContentSources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContentCreators",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ArchiveAlbums",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ArchiveFileTypeInfos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Shows",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShowRundowns",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ArchiveFiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShowRundownAuthors",
                schema: "dbo");
        }
    }
}
