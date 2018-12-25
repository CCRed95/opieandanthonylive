using Ccr.Dnc.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
  public class ShowMediaSegmentContentTagMap
    : IEntityTypeConfiguration<ShowMediaSegmentContentTag>
  {
    public void Configure(
      EntityTypeBuilder<ShowMediaSegmentContentTag> builder)
    {
      builder.ToTable("ShowMediaSegmentContentTags");

      builder.HasKey(t => t.ShowMediaContentTagID);
      builder.Property(t => t.ShowMediaContentTagID)
        .IsRequired()
        .ValueGeneratedOnAdd();
      
      builder.Property(t => t.SegmentTimeStart)
        .IsOptional();

      builder.Property(t => t.SegmentTimeEnd)
        .IsOptional();

    }
  }
}