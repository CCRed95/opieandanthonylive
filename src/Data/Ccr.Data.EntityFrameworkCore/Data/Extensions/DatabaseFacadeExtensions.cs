using System;
using System.Linq;
using System.Reflection;
using Ccr.Data.EntityFrameworkCore;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Ccr.Data.Extensions
{
  public static class DatabaseFacadeExtensions
  {
    public static void EnsureSeed<TContext>(
      [NotNull] this TContext @this)
        where TContext
          : DbContext
    {
      @this.Database.EnsureCreated();

      var assembly = Assembly.GetAssembly(
        @this.GetType());

      var seedableEntityTypes = assembly
        .GetExportedTypes()
        .Where(
          t =>
            t.IsClass &&
            t.Implements<ISeedableEntity>())
        .ToArray();

      foreach (var seedableEntityType in seedableEntityTypes)
      {
        var dbContextType = @this.GetType();
        var setMethod = dbContextType.GetMethod(
          "Set",
          new Type[] { });

        var genericMethod = setMethod
          .MakeGenericMethod(
            seedableEntityType);

        var dbSet = genericMethod
          .Invoke(
            @this, 
            null);

        var staticSet =
          seedableEntityType
            .GetFields(
              BindingFlags.Public | BindingFlags.Static)
            .Select(
              t => t.GetValue(null))
            .Where(
              t => t.GetType() == seedableEntityType);

        var extensionMethod = typeof(Enumerable)
          .GetMethod(
            nameof(Enumerable.Cast));

        var genericExtensionMethod = extensionMethod
          .MakeGenericMethod(
            seedableEntityType);

        var convertedStaticSet = genericExtensionMethod
          .Invoke(
            null, 
            new object[] {staticSet});

        var addRangeMethod = typeof(DbSetExtensions)
          .GetMethod(
            "AddRangeWithSqlIdentity");

        var genericAddRangeMethod = addRangeMethod
          .MakeGenericMethod(
            seedableEntityType);

        var toArrayMethod = typeof(Enumerable)
          .GetMethod(
            nameof(Enumerable.ToArray));

        var toArrayGenericMethod = toArrayMethod
          .MakeGenericMethod(
            seedableEntityType);

        var enumeratedArray = toArrayGenericMethod
          .Invoke(
            null, 
            new[] {convertedStaticSet});

        genericAddRangeMethod.Invoke(
          null, 
          new[]
        {
          dbSet,
          enumeratedArray
        });
      }
    }
  }
}