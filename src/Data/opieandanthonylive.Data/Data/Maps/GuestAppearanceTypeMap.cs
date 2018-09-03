using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
  public class GuestAppearanceTypeMap
    : IEntityTypeConfiguration<GuestAppearanceType>
  {
    public void Configure(
      EntityTypeBuilder<GuestAppearanceType> builder)
    {
      builder.ToTable("GuestAppearanceTypes");

      builder.HasKey(t => t.GuestAppearanceTypeID);
      builder.Property(t => t.GuestAppearanceTypeID)
        .IsRequired()
        .ValueGeneratedOnAdd();

      builder.Property(t => t.AppearanceTypeName)
        .IsRequired()
        .HasMaxLength(150);

      builder.HasIndex(t => t.AppearanceTypeName)
        .HasName("IX_GuestAppearanceType_AppearanceTypeName")
        .IsUnique();
    }
  }
}
