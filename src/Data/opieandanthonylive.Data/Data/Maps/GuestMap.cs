using Ccr.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
  public class GuestMap
    : IEntityTypeConfiguration<Guest>
  {
    public void Configure(
      EntityTypeBuilder<Guest> builder)
    {
      builder.ToTable("Guests");

      builder.HasKey(t => t.GuestID);
      builder.Property(t => t.GuestID)
        .IsRequired()
        .ValueGeneratedOnAdd();

      builder.Property(t => t.LegacyGuestID)
        .IsOptional();

      builder.Property(t => t.Description)
        .IsOptional()
        .HasMaxLength(400);

      builder.Property(t => t.FirstName)
        .IsRequired()
        .HasMaxLength(30);

      builder.Property(t => t.MiddleName)
        .IsOptional()
        .HasMaxLength(30);

      builder.Property(t => t.LastName)
        .IsOptional()
        .HasMaxLength(30);

      builder.Property(t => t.AlternateName)
        .IsOptional()
        .HasMaxLength(200);
      
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

      //builder.HasMany(t => t.ShowAppearances)
      //       .WithOne(t => t.Guest)
      //       .HasForeignKey(t => t.GuestID);
    }
  }
}
