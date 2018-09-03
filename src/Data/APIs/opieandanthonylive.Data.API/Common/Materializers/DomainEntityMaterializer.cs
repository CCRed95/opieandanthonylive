using System;
using System.Collections.Generic;

namespace opieandanthonylive.Common.Materializers
{
  public interface IDomainEntityMaterializer
  {
    object MaterializeBase(
      object data);
  }

  public abstract class DomainEntityMaterializer<
    TEntity, 
    TData> 
      : IDomainEntityMaterializer
  {
    object IDomainEntityMaterializer.MaterializeBase(
      object data)
    {
      return Materialize((TData) data);
    }

    public abstract TEntity Materialize(
      TData data);
  }

  public static class EntityMaterializerContext
  {
    public static IDictionary<(Type, Type), IDomainEntityMaterializer> _mapping 
      = new Dictionary<(Type, Type), IDomainEntityMaterializer>();
    

    public static void Register<TDomainEntityMaterializer, TEntity, TData>(
      TDomainEntityMaterializer instance)
      where TDomainEntityMaterializer
        : DomainEntityMaterializer<
          TEntity,
          TData>
    {
      _mapping.Add(
        (typeof(TEntity), typeof(TData)), 
        instance);
    }
  }
}
