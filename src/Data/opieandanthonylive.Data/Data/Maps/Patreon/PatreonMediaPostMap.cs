using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using opieandanthonylive.Data.Domain.Patreon;

namespace opieandanthonylive.Data.Maps.Patreon
{
	public class PatreonMediaPostMap
		: IEntityTypeConfiguration<PatreonMediaPost>
	{
		public void Configure(
			EntityTypeBuilder<PatreonMediaPost> builder)
		{
			builder.ToTable("PatreonMediaPosts");

			builder.HasKey(t => t.PatreonMediaPostID);
			builder.Property(t => t.PatreonMediaPostID)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(t => t.Title)
				.IsRequired()
				.HasMaxLength(300);

			builder.Property(t => t.Summary)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(t => t.Body)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(t => t.DateTime)
				.IsRequired();

			builder.Property(t => t.FilePath)
				.IsRequired()
				.HasMaxLength(400);
		}
	}


	public class ShoutEngineMediaPostMap
		: IEntityTypeConfiguration<ShoutEngineMediaPost>
	{
		public void Configure(
			EntityTypeBuilder<ShoutEngineMediaPost> builder)
		{
			builder.ToTable("ShoutEngineMediaPosts");

			builder.HasKey(t => t.ShoutEngineMediaPostID);
			builder.Property(t => t.ShoutEngineMediaPostID)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(t => t.Title)
				.IsRequired()
				.HasMaxLength(300);

			builder.Property(t => t.Summary)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(t => t.Body)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(t => t.DateTime)
				.IsRequired();

			builder.Property(t => t.FilePath)
				.IsRequired()
				.HasMaxLength(400);
		}
	}

	
}
