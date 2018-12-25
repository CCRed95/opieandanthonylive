using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
  public class EmbeddedContentSourceMap
    : IEntityTypeConfiguration<EmbeddedContentSource>
  {
    public void Configure(
      EntityTypeBuilder<EmbeddedContentSource> builder)
    {
      builder.ToTable("EmbeddedContentSources");

      builder.HasKey(t => t.EmbeddedContentSourceID);
      builder.Property(t => t.EmbeddedContentSourceID)
             .IsRequired()
             .ValueGeneratedOnAdd();

      builder.Property(t => t.EmbeddedContentSourceName)
             .IsRequired()
             .HasMaxLength(50);

      builder.HasIndex(t => t.EmbeddedContentSourceName)
             .HasName("UIX_EmbeddedContentSource_EmbeddedContentSourceName")
             .IsUnique();
    }
  }
}
