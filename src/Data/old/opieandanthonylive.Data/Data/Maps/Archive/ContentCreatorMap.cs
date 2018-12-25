using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain.Archive;

namespace opieandanthonylive.Data.Maps.Archive
{
  public class ContentCreatorMap
    : IEntityTypeConfiguration<ContentCreator>
  {
    public void Configure(
      EntityTypeBuilder<ContentCreator> builder)
    {
      builder.ToTable("ContentCreators");

      builder.HasKey(t => t.ContentCreatorID);
      builder.Property(t => t.ContentCreatorID)
        .IsRequired()
        .ValueGeneratedOnAdd();

      builder.Property(t => t.ContentCreatorName)
        .IsRequired()
        .HasMaxLength(50);
    }
  }
}
