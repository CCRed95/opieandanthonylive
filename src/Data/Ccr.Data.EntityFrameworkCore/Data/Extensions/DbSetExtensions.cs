using System.Data.Common;
using System.Reflection;
using System.Text;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Ccr.Data.Extensions
{
  public enum IdentityGeneratorState
  {
    OFF,
    ON
  }

  public static class DbSetExtensions
  {
    public static DbContext ResolveContext<TEntity>(
      this DbSet<TEntity> @this)
        where TEntity
          : class
    {
      var resolvedContext = @this
        .GetType()
        .GetField(
          "_context",
          BindingFlags.NonPublic | BindingFlags.Instance)
        .GetValue(@this);

      return resolvedContext.As<DbContext>();
    }

    public static void AddWithSqlIdentity<TEntity>(
      this DbSet<TEntity> @this,
      [NotNull] TEntity entity)
        where TEntity
          : class
    {
      var context = @this.ResolveContext();

      var connection = context
        .GetSingularDbConnection();

      @this.SetSqlServerIdentityGeneratorState(
          connection,
          IdentityGeneratorState.ON);

      @this.Add(entity);
      var changes = context.SaveChanges();

      @this.SetSqlServerIdentityGeneratorState(
        connection,
        IdentityGeneratorState.OFF);
    }


    public static void AddRangeWithSqlIdentity<TEntity>(
      this DbSet<TEntity> @this,
      [NotNull, ItemNotNull] TEntity[] entities)
        where TEntity
          : class
    {
      var context = @this.ResolveContext();

      var connection = context
        .GetSingularDbConnection();

      @this.SetSqlServerIdentityGeneratorState(
        connection,
        IdentityGeneratorState.ON);

      @this.AddRange(entities);
      var changes = context.SaveChanges();

      @this.SetSqlServerIdentityGeneratorState(
        connection,
        IdentityGeneratorState.OFF);
    }


    public static void SetSqlServerIdentityGeneratorState<TEntity>(
      this DbSet<TEntity> @this,
      DbConnection connection,
      IdentityGeneratorState identityGeneratorState)
        where TEntity
          : class
    {
      var context = @this.ResolveContext();

      var annotations = context
        .Model
        .FindEntityType(
          typeof(TEntity).FullName)
        .Relational();

      var sqlCommandText = new StringBuilder()
        .Append($"SET IDENTITY_INSERT ")
        .Append($"dbo.{annotations.TableName} ")
        .Append($"{identityGeneratorState}")
        .ToString();

      using (var command = connection.CreateCommand())
      {
        command.CommandText = sqlCommandText;
        var result = command.ExecuteNonQuery();
      }
    }
  }
}


//public static void SetIdentityInsert<TContext, TEntity>(
//  this DbConnection @this,
//  TContext context,
//  Expression<Func<TContext, DbSet<TEntity>>> setExpression,
//  bool status)
//    where TEntity
//      : class
//    where TContext
//      : DbContext
//{
//  var mapping = context.Model.FindEntityType(
//    typeof(TEntity).FullName)
//    .Relational();

//  var sqlCommand = $"SET IDENTITY_INSERT dbo.{mapping.TableName} {(status ? "ON" : "OFF")}";

//  using (var command = @this.CreateCommand())
//  {
//    command.CommandText = sqlCommand;
//    var result = command.ExecuteNonQuery();
//  }
//}