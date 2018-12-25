using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain.Archive;

namespace opieandanthonylive.Data.Maps.Archive
{
  public class ArchiveFileTypeInfoMap
    : IEntityTypeConfiguration<ArchiveFileTypeInfo>
  {
    public void Configure(
      EntityTypeBuilder<ArchiveFileTypeInfo> builder)
    {
      builder.ToTable("ArchiveFileTypeInfos");

      builder.HasKey(t => t.ArchiveFileTypeInfoID);
      builder.Property(t => t.ArchiveFileTypeInfoID)
        .IsRequired()
        .ValueGeneratedOnAdd();

      builder.Property(t => t.Extension)
        .IsRequired()
        .HasMaxLength(20);

      builder.Property(t => t.Description)
        .IsRequired()
        .HasMaxLength(200);
    }
  }
}
