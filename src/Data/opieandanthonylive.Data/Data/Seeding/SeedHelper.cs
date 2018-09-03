using System;
using System.Linq;
using System.Reflection;
using Ccr.Dnc.Data.EntityFrameworkCore;
using Ccr.Dnc.Data.EntityFrameworkCore.Infrastucture;
using Ccr.Dnc.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using opieandanthonylive.Data.Context;

namespace opieandanthonylive.Data.Seeding
{
  public static class SeedHelper
  {
    public static TResult[] GetStaticFieldValuesOfType<TResult>(
      this object @this)
    {
      if (@this == null)
        throw new NullReferenceException(
          $"Could not get properties in null object");

      var fieldInfos = typeof(TResult).GetFields(
        BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

      var returnVal = fieldInfos
        .Select(t => t.GetValue(null))
        .OfType<TResult>()
        .ToArray();

      return returnVal;
    }

    public static TResult[] GetStaticFieldValuesOfType2<TResult>()
    {
      var fieldInfos = typeof(TResult)
        .GetFields(
          BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

      var returnVal = fieldInfos
        .Select(t => t.GetValue(null))
        .OfType<TResult>()
        .ToArray();

      return returnVal;
    }

    //public static void SeedWithIdentities<TEntity, TContext>(
    //  this TContext context,
    //  Expression<Func<TContext, DbSet<TEntity>>> setExpression,
    //  Expression<Func<TEntity, IComparable>> primaryKeyExpression)
    //    where TEntity : class
    //    where TContext : DbContext
    //{
    //  var orderbyCompiled = primaryKeyExpression.Compile();

    //  var entities =
    //    typeof(TEntity)
    //      .GetStaticFieldValuesOfType<TEntity>()
    //      .OrderBy(t => orderbyCompiled)
    //      .ToArray();

    //  context.AddRangeWithIdentities(
    //    setExpression,
    //    entities);
    //}


    //public static void Seed<TEntity>(
    //  this CoreContext context,
    //  Expression<Func<CoreContext, DbSet<TEntity>>> setExpression,
    //  Expression<Func<TEntity, IComparable>> primaryKeyExpression)
    //    where TEntity : class
    //{
    //  var orderbyCompiled = primaryKeyExpression.Compile();

    //  var entities =
    //    typeof(TEntity)
    //      .GetStaticFieldValuesOfType<TEntity>()
    //      .OrderBy(t => orderbyCompiled)
    //      .ToArray();

    //  var setCompiled = setExpression.Compile();
    //  var set = setCompiled(context);


    //  set.AddRange(entities);
    //}

    public static void Seed<TEntity>(
      this DbSet<TEntity> @this)
        where TEntity
          : EntityBase
    {
      var context = @this.ResolveContext();

      using (var unitOfWork = new UnitOfWork<CoreContext>())
      {
        var repository = unitOfWork.GetRepository<TEntity, int>();


        //foreach(var

        //repository.AddOrUpdate();
        //r.AddOrUpdate();
        //var instances = repo.FetchAll();

      }
    }

  }
}
