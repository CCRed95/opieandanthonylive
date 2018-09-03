using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Maps
{
  public class ShowHostMap
    : IEntityTypeConfiguration<ShowHost>
  {
    public void Configure(
      EntityTypeBuilder<ShowHost> builder)
    {
      builder.ToTable("ShowHosts");
      
      builder.HasKey(t => new { t.ShowID, t.HostID});

      builder.Property(t => t.ShowHostID)
             .IsRequired()
             .ValueGeneratedOnAdd();

      builder.HasOne(sh => sh.Show)
             .WithMany(s => s.ShowHosts)
             .HasForeignKey(sh => sh.ShowID);

      builder.HasOne(sh => sh.Host)
             .WithMany(h => h.ShowHosts)
             .HasForeignKey(sh => sh.HostID);
    }
  }
}
