using Ccr.Data.Extensions;
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

      builder.HasKey(t => t.ShowMediaSegmentContentTagID);
      builder.Property(t => t.ShowMediaSegmentContentTagID)
				.IsRequired()
        .ValueGeneratedOnAdd();
      
      builder.Property(t => t.SegmentTimeStart)
        .IsOptional();

      builder.Property(t => t.SegmentTimeEnd)
        .IsOptional();

    }
  }
}