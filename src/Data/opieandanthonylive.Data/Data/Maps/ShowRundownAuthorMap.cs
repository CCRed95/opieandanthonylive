using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
  public class ShowRundownAuthorMap
    : IEntityTypeConfiguration<ShowRundownAuthor>
  {
    public void Configure(
      EntityTypeBuilder<ShowRundownAuthor> builder)
    {
      builder.ToTable("ShowRundownAuthors");

      builder.HasKey(t => t.ShowRundownAuthorID);
      builder.Property(t => t.ShowRundownAuthorID)
        .IsRequired()
        .ValueGeneratedOnAdd();

      builder.Property(t => t.AuthorName)
        .IsRequired()
        .HasMaxLength(150);

      builder.HasIndex(t => t.AuthorName)
        .HasName("IX_ShowRundownAuthor_AuthorName")
        .IsUnique(false);
    }
  }
}
