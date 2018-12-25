using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Ccr.Dnc.Data.EntityFrameworkCore;
using Ccr.Dnc.Data.EntityFrameworkCore.Infrastucture;

namespace opieandanthonylive.Data.Domain.Complex
{
  public abstract class EntityBuilder
  {
    protected abstract Func<string, EntityBase> _builderFuncBase { get; }

    protected abstract Type EntityType { get; }


    private static readonly IList<EntityBuilder> _entityBuilders
      = new List<EntityBuilder>();

    private static IDictionary<Type, EntityBuilder> _builderMap
    {
      get => _entityBuilders
        .ToDictionary(
          t => t.EntityType,
          t => t);
    }


    static EntityBuilder()
    {
      AddBuilder(
        memberName => new Gender(
          memberName.Substring(0, 1),
          memberName));

      AddBuilder(
        memberName => new GuestAppearanceType(
          memberName));
      
      AddBuilder(memberName =>
      {
        return PersonFactory.CreatePerson<Host>(
          memberName);
      });
      AddBuilder(memberName =>
      {
        return new EmbeddedContentSource(
          memberName);
      });
      //AddBuilder(memberName =>
      //{
      //  return new Host(
      //    memberName);
      //});
    }


    public abstract EntityBase BuildBase(
      string text);


    public static void AddBuilder<TEntity>(
      Func<string, TEntity> _builderFunc)
        where TEntity
         : EntityBase
    {
      _entityBuilders.Add(
        new EntityBuilder<TEntity>(
          _builderFunc));
    }

    public static EntityBuilder<TEntity> GetBuilder<TEntity>()
      where TEntity
        : EntityBase
    {
      var _builderBase = GetBuilderBase(
        typeof(TEntity));

      return (EntityBuilder<TEntity>)_builderBase;
    }

    protected static EntityBuilder GetBuilderBase(
      Type entityType)
    {
      if (!_builderMap.TryGetValue(
        entityType, 
        out var entityBuilder))
      {
        throw new InvalidOperationException(
          "Builder type not found.");
      }
      return entityBuilder;
    }
  }

  public class EntityBuilder<TEntity>
    : EntityBuilder
      where TEntity
       : EntityBase
  {
    protected override Type EntityType => typeof(TEntity);


    protected override Func<string, EntityBase> _builderFuncBase
    {
      get => text => _builderFunc(text);
    }
    protected readonly Func<string, TEntity> _builderFunc;


    public EntityBuilder(
      Func<string, TEntity> builderFunc)
    {
      _builderFunc = builderFunc;
    }


    public TEntity Build(
      string text)
    {
      return _builderFunc(text);
    }

    public override EntityBase BuildBase(
      string text)
    {
      return Build(text);
    }
  }


  public class EntityFactory
  {
    public static TEntity Create<TEntity>(
      [CallerLineNumber] int callerLineNumber = 0,
      [CallerMemberName] string callerMemberName = "")
        where TEntity
          : EntityBase
    {
      return CreateImpl<TEntity>(
        callerLineNumber,
        callerMemberName);
    }

    internal static TEntity CreateImpl<TEntity>(
      int callerLineNumber = 0,
      string callerMemberName = "")
        where TEntity
          : EntityBase
    {
      var builder = EntityBuilder
        .GetBuilder<TEntity>();

      var builtEntity = builder
        .Build(callerMemberName);

      var storageCache = StaticEntityStorageCache
        .I.GetDeclarationCache<TEntity>();

      storageCache.RegisterEntity(
        callerLineNumber,
        builtEntity);

      return builtEntity;
    }
  }
}