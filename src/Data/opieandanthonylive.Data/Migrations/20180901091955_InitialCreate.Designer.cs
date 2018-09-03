﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using opieandanthonylive.Data.Context;

namespace opieandanthonylive.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20180901091955_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Archive.ArchiveAlbum", b =>
                {
                    b.Property<int>("ArchiveAlbumID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentCreatorID");

                    b.Property<DateTime>("DatePublished");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("MonthNumber");

                    b.Property<int>("YearNumber");

                    b.HasKey("ArchiveAlbumID");

                    b.HasIndex("ContentCreatorID");

                    b.ToTable("ArchiveAlbums");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Archive.ArchiveFile", b =>
                {
                    b.Property<int>("ArchiveFileID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AirDate");

                    b.Property<double>("ApproximateBytes");

                    b.Property<int?>("ArchiveAlbumID");

                    b.Property<int?>("ArchiveFileTypeInfoID");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("FilePathUrl")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<int?>("ShowID");

                    b.Property<int?>("ShowRundownID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("ArchiveFileID");

                    b.HasIndex("ArchiveAlbumID");

                    b.HasIndex("ArchiveFileTypeInfoID");

                    b.HasIndex("ShowID");

                    b.HasIndex("ShowRundownID");

                    b.ToTable("ArchiveFiles");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Archive.ArchiveFileTypeInfo", b =>
                {
                    b.Property<int>("ArchiveFileTypeInfoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ArchiveFileTypeInfoID");

                    b.ToTable("ArchiveFileTypeInfos");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Archive.ContentCreator", b =>
                {
                    b.Property<int>("ContentCreatorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentCreatorName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ContentCreatorID");

                    b.ToTable("ContentCreators");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Audible.AudibleMediaItem", b =>
                {
                    b.Property<int>("AudibleMediaItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("AverageRating");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FullShowMetadataUrl")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("ItemTypeClassification")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("NarratedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("NumberOfRatings");

                    b.Property<TimeSpan>("PlaybackLength");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("AudibleMediaItemID");

                    b.ToTable("AudibleMediaItems");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.EmbeddedContentSource", b =>
                {
                    b.Property<int>("EmbeddedContentSourceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmbeddedContentSourceName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("EmbeddedContentSourceID");

                    b.HasIndex("EmbeddedContentSourceName")
                        .IsUnique()
                        .HasName("UIX_EmbeddedContentSource_EmbeddedContentSourceName");

                    b.ToTable("EmbeddedContentSources");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("GenderID");

                    b.HasIndex("GenderName")
                        .IsUnique()
                        .HasName("UIX_Gender_GenderName");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Guest", b =>
                {
                    b.Property<int>("GuestID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternateName")
                        .HasMaxLength(200);

                    b.Property<string>("Description")
                        .HasMaxLength(400);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int?>("GenderID");

                    b.Property<string>("HeadshotImagePath")
                        .HasMaxLength(400);

                    b.Property<string>("LastName")
                        .HasMaxLength(30);

                    b.Property<int?>("LegacyGuestID");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(30);

                    b.Property<string>("TwitterHandle")
                        .HasMaxLength(200);

                    b.Property<string>("WebsiteUrl")
                        .HasMaxLength(400);

                    b.HasKey("GuestID");

                    b.HasIndex("GenderID");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.GuestAppearance", b =>
                {
                    b.Property<int>("GuestAppearanceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArchiveFileID");

                    b.Property<int?>("GuestID");

                    b.Property<long?>("SegmentTimeEnd");

                    b.Property<long?>("SegmentTimeStart");

                    b.Property<int?>("ShowMediaEntryID");

                    b.Property<int?>("ShowRundownID");

                    b.HasKey("GuestAppearanceID");

                    b.HasIndex("ArchiveFileID");

                    b.HasIndex("GuestID");

                    b.HasIndex("ShowMediaEntryID");

                    b.HasIndex("ShowRundownID");

                    b.ToTable("GuestAppearances");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.GuestAppearanceType", b =>
                {
                    b.Property<int>("GuestAppearanceTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppearanceTypeName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("GuestAppearanceTypeID");

                    b.HasIndex("AppearanceTypeName")
                        .IsUnique()
                        .HasName("IX_GuestAppearanceType_AppearanceTypeName");

                    b.ToTable("GuestAppearanceTypes");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Host", b =>
                {
                    b.Property<int>("HostID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternateName")
                        .HasMaxLength(200);

                    b.Property<string>("Description")
                        .HasMaxLength(400);

                    b.Property<string>("FirstName");

                    b.Property<int?>("GenderID");

                    b.Property<string>("HeadshotImagePath")
                        .HasMaxLength(400);

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("TwitterHandle")
                        .HasMaxLength(200);

                    b.Property<string>("WebsiteUrl")
                        .HasMaxLength(400);

                    b.HasKey("HostID");

                    b.HasIndex("GenderID");

                    b.ToTable("Hosts");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Show", b =>
                {
                    b.Property<int>("ShowID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShowName")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("ShowID");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.ShowHost", b =>
                {
                    b.Property<int>("ShowID");

                    b.Property<int>("HostID");

                    b.Property<int>("ShowHostID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ShowID", "HostID");

                    b.HasIndex("HostID");

                    b.ToTable("ShowHosts");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.ShowMediaEntry", b =>
                {
                    b.Property<int>("ShowMediaEntryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AirDate");

                    b.Property<int?>("ShowID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Url")
                        .HasMaxLength(1000);

                    b.HasKey("ShowMediaEntryID");

                    b.HasIndex("ShowID");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasName("UIX_ShowMediaEntry_Title");

                    b.ToTable("ShowMediaEntries");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.ShowRundown", b =>
                {
                    b.Property<int>("ShowRundownID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AirDate");

                    b.Property<int?>("ArchiveFileID");

                    b.Property<string>("DetailsUrl")
                        .IsRequired();

                    b.Property<int?>("ShowRundownAuthorID");

                    b.Property<string>("ShowRundownContent")
                        .HasMaxLength(500);

                    b.Property<string>("ShowRundownName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("ShowRundownID");

                    b.HasIndex("ArchiveFileID");

                    b.HasIndex("ShowRundownAuthorID");

                    b.ToTable("ShowRundowns");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.ShowRundownAuthor", b =>
                {
                    b.Property<int>("ShowRundownAuthorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("ShowRundownAuthorID");

                    b.HasIndex("AuthorName")
                        .HasName("IX_ShowRundownAuthor_AuthorName");

                    b.ToTable("ShowRundownAuthors");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Archive.ArchiveAlbum", b =>
                {
                    b.HasOne("opieandanthonylive.Data.Domain.Archive.ContentCreator", "ContentCreator")
                        .WithMany()
                        .HasForeignKey("ContentCreatorID");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Archive.ArchiveFile", b =>
                {
                    b.HasOne("opieandanthonylive.Data.Domain.Archive.ArchiveAlbum", "ArchiveAlbum")
                        .WithMany("ArchiveFiles")
                        .HasForeignKey("ArchiveAlbumID");

                    b.HasOne("opieandanthonylive.Data.Domain.Archive.ArchiveFileTypeInfo", "ArchiveFileTypeInfo")
                        .WithMany()
                        .HasForeignKey("ArchiveFileTypeInfoID");

                    b.HasOne("opieandanthonylive.Data.Domain.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowID");

                    b.HasOne("opieandanthonylive.Data.Domain.ShowRundown", "ShowRundown")
                        .WithMany()
                        .HasForeignKey("ShowRundownID");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Guest", b =>
                {
                    b.HasOne("opieandanthonylive.Data.Domain.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.GuestAppearance", b =>
                {
                    b.HasOne("opieandanthonylive.Data.Domain.Archive.ArchiveFile")
                        .WithMany("GuestAppearances")
                        .HasForeignKey("ArchiveFileID");

                    b.HasOne("opieandanthonylive.Data.Domain.Guest", "Guest")
                        .WithMany("ShowAppearances")
                        .HasForeignKey("GuestID");

                    b.HasOne("opieandanthonylive.Data.Domain.ShowMediaEntry", "ShowMediaEntry")
                        .WithMany("GuestAppearances")
                        .HasForeignKey("ShowMediaEntryID");

                    b.HasOne("opieandanthonylive.Data.Domain.ShowRundown")
                        .WithMany("GuestAppearances")
                        .HasForeignKey("ShowRundownID");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.Host", b =>
                {
                    b.HasOne("opieandanthonylive.Data.Domain.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.ShowHost", b =>
                {
                    b.HasOne("opieandanthonylive.Data.Domain.Host", "Host")
                        .WithMany("ShowHosts")
                        .HasForeignKey("HostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("opieandanthonylive.Data.Domain.Show", "Show")
                        .WithMany("ShowHosts")
                        .HasForeignKey("ShowID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.ShowMediaEntry", b =>
                {
                    b.HasOne("opieandanthonylive.Data.Domain.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowID");
                });

            modelBuilder.Entity("opieandanthonylive.Data.Domain.ShowRundown", b =>
                {
                    b.HasOne("opieandanthonylive.Data.Domain.Archive.ArchiveFile", "ArchiveFile")
                        .WithMany()
                        .HasForeignKey("ArchiveFileID");

                    b.HasOne("opieandanthonylive.Data.Domain.ShowRundownAuthor", "ShowRundownAuthor")
                        .WithMany()
                        .HasForeignKey("ShowRundownAuthorID");
                });
#pragma warning restore 612, 618
        }
    }
}
