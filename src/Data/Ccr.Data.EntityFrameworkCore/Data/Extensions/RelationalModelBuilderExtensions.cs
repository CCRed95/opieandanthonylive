using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Ccr.Data.Extensions
{
	public static class RelationalModelBuilderExtensions
	{
		/// <summary>
		///		Configures the default schema that database objects should be created in, if no schema
		///		is explicitly configured.
		/// </summary>
		/// <param name="modelBuilder">
		///		The model builder.
		/// </param>
		/// <returns>
		///		The same builder instance so that multiple calls can be chained.
		/// </returns>
		public static ModelBuilder WithConfiguration<TEntity, TConfigMap>(
			[NotNull] this ModelBuilder modelBuilder)
				where TConfigMap
					: IEntityTypeConfiguration<TEntity>, 
						new()
				where TEntity 
					: class
		{
			modelBuilder.IsNotNull(nameof(modelBuilder));

			var map = new TConfigMap();
			modelBuilder.ApplyConfiguration(map);

			return modelBuilder;
		}
	}
}