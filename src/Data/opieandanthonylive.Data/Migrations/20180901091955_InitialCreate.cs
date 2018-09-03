using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace opieandanthonylive.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchiveFileTypeInfos",
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
                name: "AudibleMediaItems",
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
                name: "ArchiveAlbums",
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
                        principalTable: "ContentCreators",
                        principalColumn: "ContentCreatorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
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
                        principalTable: "Genders",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
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
                        principalTable: "Genders",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShowMediaEntries",
                columns: table => new
                {
                    ShowMediaEntryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowID = table.Column<int>(nullable: true),
                    AirDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 400, nullable: false),
                    Url = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowMediaEntries", x => x.ShowMediaEntryID);
                    table.ForeignKey(
                        name: "FK_ShowMediaEntries_Shows_ShowID",
                        column: x => x.ShowID,
                        principalTable: "Shows",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShowHosts",
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
                        principalTable: "Hosts",
                        principalColumn: "HostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowHosts_Shows_ShowID",
                        column: x => x.ShowID,
                        principalTable: "Shows",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveFiles",
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
                        principalTable: "ArchiveAlbums",
                        principalColumn: "ArchiveAlbumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_ArchiveFileTypeInfos_ArchiveFileTypeInfoID",
                        column: x => x.ArchiveFileTypeInfoID,
                        principalTable: "ArchiveFileTypeInfos",
                        principalColumn: "ArchiveFileTypeInfoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_Shows_ShowID",
                        column: x => x.ShowID,
                        principalTable: "Shows",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShowRundowns",
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
                        principalTable: "ArchiveFiles",
                        principalColumn: "ArchiveFileID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowRundowns_ShowRundownAuthors_ShowRundownAuthorID",
                        column: x => x.ShowRundownAuthorID,
                        principalTable: "ShowRundownAuthors",
                        principalColumn: "ShowRundownAuthorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestAppearances",
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
                        principalTable: "ArchiveFiles",
                        principalColumn: "ArchiveFileID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestAppearances_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestAppearances_ShowMediaEntries_ShowMediaEntryID",
                        column: x => x.ShowMediaEntryID,
                        principalTable: "ShowMediaEntries",
                        principalColumn: "ShowMediaEntryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestAppearances_ShowRundowns_ShowRundownID",
                        column: x => x.ShowRundownID,
                        principalTable: "ShowRundowns",
                        principalColumn: "ShowRundownID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveAlbums_ContentCreatorID",
                table: "ArchiveAlbums",
                column: "ContentCreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ArchiveAlbumID",
                table: "ArchiveFiles",
                column: "ArchiveAlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ArchiveFileTypeInfoID",
                table: "ArchiveFiles",
                column: "ArchiveFileTypeInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ShowID",
                table: "ArchiveFiles",
                column: "ShowID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ShowRundownID",
                table: "ArchiveFiles",
                column: "ShowRundownID");

            migrationBuilder.CreateIndex(
                name: "UIX_EmbeddedContentSource_EmbeddedContentSourceName",
                table: "EmbeddedContentSources",
                column: "EmbeddedContentSourceName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UIX_Gender_GenderName",
                table: "Genders",
                column: "GenderName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearances_ArchiveFileID",
                table: "GuestAppearances",
                column: "ArchiveFileID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearances_GuestID",
                table: "GuestAppearances",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearances_ShowMediaEntryID",
                table: "GuestAppearances",
                column: "ShowMediaEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearances_ShowRundownID",
                table: "GuestAppearances",
                column: "ShowRundownID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAppearanceType_AppearanceTypeName",
                table: "GuestAppearanceTypes",
                column: "AppearanceTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_GenderID",
                table: "Guests",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_GenderID",
                table: "Hosts",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowHosts_HostID",
                table: "ShowHosts",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowMediaEntries_ShowID",
                table: "ShowMediaEntries",
                column: "ShowID");

            migrationBuilder.CreateIndex(
                name: "UIX_ShowMediaEntry_Title",
                table: "ShowMediaEntries",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShowRundownAuthor_AuthorName",
                table: "ShowRundownAuthors",
                column: "AuthorName");

            migrationBuilder.CreateIndex(
                name: "IX_ShowRundowns_ArchiveFileID",
                table: "ShowRundowns",
                column: "ArchiveFileID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowRundowns_ShowRundownAuthorID",
                table: "ShowRundowns",
                column: "ShowRundownAuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_ShowRundowns_ShowRundownID",
                table: "ArchiveFiles",
                column: "ShowRundownID",
                principalTable: "ShowRundowns",
                principalColumn: "ShowRundownID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveAlbums_ContentCreators_ContentCreatorID",
                table: "ArchiveAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ArchiveAlbums_ArchiveAlbumID",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ArchiveFileTypeInfos_ArchiveFileTypeInfoID",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_Shows_ShowID",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ShowRundowns_ShowRundownID",
                table: "ArchiveFiles");

            migrationBuilder.DropTable(
                name: "AudibleMediaItems");

            migrationBuilder.DropTable(
                name: "EmbeddedContentSources");

            migrationBuilder.DropTable(
                name: "GuestAppearances");

            migrationBuilder.DropTable(
                name: "GuestAppearanceTypes");

            migrationBuilder.DropTable(
                name: "ShowHosts");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "ShowMediaEntries");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "ContentCreators");

            migrationBuilder.DropTable(
                name: "ArchiveAlbums");

            migrationBuilder.DropTable(
                name: "ArchiveFileTypeInfos");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "ShowRundowns");

            migrationBuilder.DropTable(
                name: "ArchiveFiles");

            migrationBuilder.DropTable(
                name: "ShowRundownAuthors");
        }
    }
}
