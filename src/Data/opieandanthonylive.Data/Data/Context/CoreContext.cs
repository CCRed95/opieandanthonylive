using Ccr.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using opieandanthonylive.Data.Domain;
using opieandanthonylive.Data.Domain.Archive;
using opieandanthonylive.Data.Domain.Audible;
using opieandanthonylive.Data.Domain.Patreon;
using opieandanthonylive.Data.Maps;
using opieandanthonylive.Data.Maps.Archive;
using opieandanthonylive.Data.Maps.Audible;
using opieandanthonylive.Data.Maps.Patreon;

namespace opieandanthonylive.Data.Context
{
  public class CoreContext
    : IdentityDbContext<IdentityUser>
  {
    public DbSet<ArchiveAlbum> ArchiveAlbums { get; set; }

    public DbSet<ArchiveFile> ArchiveFiles { get; set; }

    public DbSet<ArchiveFileTypeInfo> ArchiveFileTypeInfos { get; set; }

    public DbSet<ContentCreator> ContentCreators { get; set; }
    
    public DbSet<AudibleMediaItem> AudibleMediaItems { get; set; }

    public DbSet<EmbeddedContentSource> EmbeddedContentSources { get; set; }
    
    public DbSet<Gender> Genders { get; set; }

    public DbSet<Guest> Guests { get; set; }

    public DbSet<GuestAppearance> GuestAppearances { get; set; }

    public DbSet<GuestAppearanceType> GuestAppearanceTypes { get; set; }

    public DbSet<Host> Hosts { get; set; }

    public DbSet<Show> Shows { get; set; }

    public DbSet<ShowMediaSegmentContentTag> ShowMediaSegmentContentTags { get; set; }

    public DbSet<ShowHost> ShowHosts { get; set; }

    public DbSet<ShowMediaEntry> ShowMediaEntries { get; set; }

    public DbSet<ShowRundown> ShowRundowns { get; set; }

    public DbSet<ShowRundownAuthor> ShowRundownAuthors { get; set; }

	  public DbSet<PatreonMediaPost> PatreonMediaPosts { get; set; }


		public CoreContext()
      : this(
        new DbContextOptionsBuilder<CoreContext>().Options)
    {
    }

    public CoreContext(
      DbContextOptions options)
      : base(
          options)
    {
    }


    protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder)
    {
			base.OnConfiguring(optionsBuilder);

			// var s = Configuration.GetConnectionString("DefaultConnectionString");

			optionsBuilder.UseSqlServer(
				"Data Source=184.168.47.17;Initial Catalog=opieandanthonylive15;Persist Security Info=True;User ID=oa_backend;Password=S7glr@78");
    }

    protected override void OnModelCreating(
      ModelBuilder modelBuilder)
    {
	    base.OnModelCreating(modelBuilder);

	    modelBuilder
		    .HasDefaultSchema("dbo")
		    .WithConfiguration<ArchiveAlbum, ArchiveAlbumMap>()
		    .WithConfiguration<ArchiveFile, ArchiveFileMap>()
		    .WithConfiguration<ArchiveFileTypeInfo, ArchiveFileTypeInfoMap>()
		    .WithConfiguration<ContentCreator, ContentCreatorMap>()
		    .WithConfiguration<AudibleMediaItem, AudibleMediaItemMap>()
		    .WithConfiguration<EmbeddedContentSource, EmbeddedContentSourceMap>()
		    .WithConfiguration<Gender, GenderMap>()
		    .WithConfiguration<Guest, GuestMap>()
		    .WithConfiguration<GuestAppearance, GuestAppearanceMap>()
		    .WithConfiguration<GuestAppearanceType, GuestAppearanceTypeMap>()
		    .WithConfiguration<Host, HostMap>()
		    .WithConfiguration<Show, ShowMap>()
		    .WithConfiguration<ShowMediaSegmentContentTag, ShowMediaSegmentContentTagMap>()
		    .WithConfiguration<ShowHost, ShowHostMap>()
		    .WithConfiguration<ShowMediaEntry, ShowMediaEntryMap>()
		    .WithConfiguration<ShowRundown, ShowRundownMap>()
		    .WithConfiguration<ShowRundownAuthor, ShowRundownAuthorMap>()
		    .WithConfiguration<PatreonMediaPost, PatreonMediaPostMap>()
		    .WithConfiguration<ShoutEngineMediaPost, ShoutEngineMediaPostMap>();

			modelBuilder.Entity<GuestAppearance>(builder =>
      {
        builder
          .HasOne(t => t.ShowMediaEntry)
          .WithMany(t => t.GuestAppearances)
          .HasForeignKey(t => t.ShowMediaEntryID);
      });

      //modelBuilder.Entity<Guest>(builder =>
      //{
      //  builder.HasOne(t => t.ShowAppearances)
      //    .WithMany(t => t.)
      //    .HasForeignKey(t => t.ShowMediaEntryID);

      //});

      modelBuilder.Entity<ShowHost>(builder =>
      {
        builder.HasKey(t => new {t.ShowID, t.HostID});

        builder.HasOne(sh => sh.Show)
               .WithMany(s => s.ShowHosts)
               .HasForeignKey(sh => sh.ShowID);

        builder.HasOne(sh => sh.Host)
               .WithMany(h => h.ShowHosts)
               .HasForeignKey(sh => sh.HostID);
      });
			
      //modelBuilder.Entity<Guest>(builder =>
      //{
      //  builder.HasOne(t => t.ShowAppearances)
      //   .WithOne(t => t.)
      //         .HasForeignKey(t => t.ShowMediaEntryID);

      //});
    }
		// protected override void OnModelCreating(
    //    DbModelBuilder modelBuilder)
    //{
    //	base.OnModelCreating(modelBuilder);

    //  modelBuilder
    //      .Configurations
    //      .AddFromAssembly(
    //        GetType()
    //          .Assembly);

    //    modelBuilder
    //      .Conventions
    //      .Add(new DataTypePropertyAttributeConvention());

    //  //  modelBuilder
    //		//.Entity<GuestAppearance>()
    //		//.HasRequired(t => t.ShowRundown)
    //		//.WithMany(t => t.GuestApperances)
    //		//.HasForeignKey(t => t.ShowRundownID);
    //}
  }
}
