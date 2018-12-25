using Ccr.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain.Archive;

namespace opieandanthonylive.Data.Maps.Archive
{
  public class ArchiveFileMap
    : IEntityTypeConfiguration<ArchiveFile>
  {
    public void Configure(
      EntityTypeBuilder<ArchiveFile> builder)
    {
      builder.ToTable("ArchiveFiles");

      builder.HasKey(t => t.ArchiveFileID);
      builder.Property(t => t.ArchiveFileID)
        .IsRequired()
        .ValueGeneratedOnAdd();

      builder.Property(t => t.FileName)
        .IsRequired()
        .HasMaxLength(200);

      builder.Property(t => t.Identifier)
        .IsRequired()
        .HasMaxLength(200);

      builder.Property(t => t.FilePathUrl)
        .IsRequired()
        .HasMaxLength(500);

      builder.Property(t => t.AirDate)
        .IsRequired();

      builder.Property(t => t.Title)
        .IsRequired()
        .HasMaxLength(500);

      builder.Property(t => t.LastModifiedDate)
        .IsOptional();

      builder.Property(t => t.ApproximateBytes)
        .IsRequired();
    }
  }
}
