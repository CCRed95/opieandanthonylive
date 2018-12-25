using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
  public class GenderMap
    : IEntityTypeConfiguration<Gender>
  {
    public void Configure(
      EntityTypeBuilder<Gender> builder)
    {
      builder.ToTable("Genders");

      builder.HasKey(t => t.GenderID);
      builder.Property(t => t.GenderID)
             .IsRequired()
             .ValueGeneratedOnAdd();

      builder.Property(t => t.GenderName)
             .IsRequired()
             .HasMaxLength(200);

      builder.Property(t => t.Abbreviation)
             .IsRequired()
             .HasMaxLength(5);

      builder.HasIndex(t => t.GenderName)
             .HasName("UIX_Gender_GenderName")
             .IsUnique();
    }
  }
}
