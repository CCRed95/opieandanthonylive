using Ccr.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
	public class ShowMediaEntryMap
		: IEntityTypeConfiguration<ShowMediaEntry>
	{
    public void Configure(
      EntityTypeBuilder<ShowMediaEntry> builder)
	  {
	    builder.ToTable("ShowMediaEntries");

	    builder.HasKey(t => t.ShowMediaEntryID);
	    builder.Property(t => t.ShowMediaEntryID)
	      .IsRequired()
	      .ValueGeneratedOnAdd();

      //Property(t => t.ShowID)
      //	.IsRequired()
      //	.HasColumnAnnotation("ForeignKey",
      //		new ForeignKeyAttribute("ShowID"));

      //HasRequired(t => t.Show)
      //	.WithMany(show => show.Hosts)
      //	.HasForeignKey(t => t.ShowID);

	    builder.Property(t => t.AirDate)
	      .IsRequired();

      builder.Property(t => t.Title)
        .IsRequired()
        .HasMaxLength(400);

	    builder.Property(t => t.EmbeddedContentSourceUrl)
	      .IsOptional()
	      .HasMaxLength(1000);

      builder.HasIndex(t => t.Title)
        .HasName("UIX_ShowMediaEntry_Title")
        .IsUnique();

    }
	}
}
