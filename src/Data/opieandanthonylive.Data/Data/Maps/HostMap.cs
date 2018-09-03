using Ccr.Dnc.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
  public class HostMap
    : IEntityTypeConfiguration<Host>
  {
    public void Configure(
      EntityTypeBuilder<Host> builder)
    {
      builder.ToTable("Hosts");

      builder.HasKey(t => t.HostID);
      builder.Property(t => t.HostID)
             .IsRequired()
             .ValueGeneratedOnAdd();

      builder.Property(t => t.AlternateName)
             .IsOptional()
             .HasMaxLength(200);

      builder.Property(t => t.Description)
             .IsOptional()
             .HasMaxLength(400);

      builder.Property(t => t.GenderID)
             .IsOptional();

      builder.Property(t => t.TwitterHandle)
             .IsOptional()
             .HasMaxLength(200);

      builder.Property(t => t.WebsiteUrl)
             .IsOptional()
             .HasMaxLength(400);

      builder.Property(t => t.HeadshotImagePath)
             .IsOptional()
             .HasMaxLength(400);
    }
  }
}
