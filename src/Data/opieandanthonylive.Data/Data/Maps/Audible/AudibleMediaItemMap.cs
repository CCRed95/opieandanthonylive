using Ccr.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain.Audible;

namespace opieandanthonylive.Data.Maps.Audible
{
  public class AudibleMediaItemMap
    : IEntityTypeConfiguration<AudibleMediaItem>
  {
    public void Configure(
      EntityTypeBuilder<AudibleMediaItem> builder)
    {
      builder.ToTable("AudibleMediaItems");

      builder.HasKey(t => t.AudibleMediaItemID);
      builder.Property(t => t.AudibleMediaItemID)
        .IsRequired()
        .ValueGeneratedOnAdd();

      builder.Property(t => t.ItemTypeClassification)
        .IsRequired()
        .HasMaxLength(30);

      builder.Property(t => t.Title)
        .IsRequired()
        .HasMaxLength(200);

      builder.Property(t => t.By)
        .IsRequired()
        .HasMaxLength(100);

      builder.Property(t => t.NarratedBy)
        .IsRequired()
        .HasMaxLength(100);

      builder.Property(t => t.FullShowMetadataUrl)
        .IsRequired()
        .HasMaxLength(500);

      builder.Property(t => t.PlaybackLength)
        .IsRequired();

      builder.Property(t => t.ReleaseDate)
        .IsRequired();

      builder.Property(t => t.AverageRating)
        .IsOptional();

      builder.Property(t => t.NumberOfRatings)
        .IsRequired();
    }
  }
}
