using System;
using System.Linq;
using System.Linq.Expressions;
using Ccr.Data.EntityFrameworkCore.Infrastucture;
using Ccr.Std.Core.Extensions;
using Microsoft.EntityFrameworkCore;

// ReSharper disable ArrangeAccessorOwnerBody
#pragma warning disable IDE1006 // Naming Styles

namespace Ccr.Data.EntityFrameworkCore
{
  /// <summary>
  ///   This is the base class for the generic <see cref="EntityPrimaryKeyResolver{TEntity,TKey,TContext}"/>
  ///   class. This defines common abstract base methods that are implemented in the generic class.
  /// </summary>
  public interface IEntityPrimaryKeyResolver
  {
    /// <summary>
    ///   Gets the <see cref="Type"/> of the entity that can be resolved by this resolver instance.
    /// </summary>
    Type EntityType { get; }


    /// <summary>
    ///   Gets the primary key property value as type <see cref="IComparable"/> from the entity type
    ///   instance provided by the <paramref name="_entityBase"/> parameter.
    /// </summary>
    /// <param name="_entityBase">
    ///   The instance of the entity in which to access the primary key from.
    /// </param>
    /// <returns>
    ///   The value of the entity's primary key property value, as type <see cref="IComparable"/>.
    /// </returns>
    IComparable GetPrimaryKeyBase(
      EntityBase _entityBase);


    /// <summary>
    ///   Sets the primary key property value as type <see cref="IComparable"/> to the entity type instance
    ///   provided by the <paramref name="_entityBase"/> parameter.
    /// </summary>
    /// <param name="_entityBase">
    ///   The instance of the entity in which to set the primary key value on.
    /// </param>
    /// <param name="_keyBase">
    ///   The value to set the primary key property to, as the type <see cref="IComparable"/>.
    /// </param>
    void SetPrimaryKeyBase(
      EntityBase _entityBase,
      IComparable _keyBase);
  }



  /// <summary>
  ///   The purpose of this type is to efficiently resolve the entity type <typeparamref name="TEntity"/>'s
  ///   primary key property getter and setter through Expression building and runtime Expression compilation.
  ///   Instances of this type serve as a cached adapter for get/set calls to the primary key property.
  /// </summary>
  /// <typeparam name="TEntity">
  ///   The entity type in which to create a single-pass resolve cached primary key resolver for.
  /// </typeparam>
  /// <typeparam name="TKey">
  ///   The type of the entity type <typeparamref name="TEntity"/>'s primary key property, usually in the
  ///   format '$entityType$ID'. This type must implement <see cref="IComparable"/>.
  /// </typeparam>
  /// <typeparam name="TContext">
  ///   The type of the Entity Framework Core 2.0 context type. This type must inherit <see cref="DbContext"/>
  /// </typeparam>
  internal class EntityPrimaryKeyResolver<TEntity, TKey, TContext>
    : IEntityPrimaryKeyResolver
      where TEntity
        : EntityBase
      where TKey
        : IComparable
      where TContext
        : DbContext
  {
    #region Fields
    /// <summary>
    ///   The <see cref="string"/> property name of the <typeparamref name="TEntity"/>'s primary key property.
    /// </summary>
    private readonly string _primaryKeyPropertyName;

    #endregion


    #region Properties
    /// <summary>
    ///   Returns the typeof ( <typeparamref name="TEntity"/> ).
    /// </summary>
    public Type EntityType => typeof(TEntity);



    /// <summary>
    ///   Backing field for the <see cref="PrimaryKeyGetterExpression"/> property.
    /// </summary>
    private Expression<Func<TEntity, TKey>> _primaryKeyGetterExpression;
    /// <summary>
    ///   First-pass expression builder with singleton-style value caching.
    /// </summary>
    public Expression<Func<TEntity, TKey>> PrimaryKeyGetterExpression
    {
      get => _primaryKeyGetterExpression ??
             (_primaryKeyGetterExpression = buildPrimaryKeyGetterExpression(_primaryKeyPropertyName));
    }

    /// <summary>
    ///   Backing field for the <see cref="PrimaryKeySetterExpression"/> property.
    /// </summary>
    private Expression<Action<TEntity, TKey>> _primaryKeySetterExpression;
    /// <summary>
    ///   First-pass expression builder with singleton-style value caching.
    /// </summary>
    public Expression<Action<TEntity, TKey>> PrimaryKeySetterExpression
    {
      get => _primaryKeySetterExpression ??
             (_primaryKeySetterExpression = buildPrimaryKeySetterExpression(_primaryKeyPropertyName));
    }


    /// <summary>
    ///   Backing field for the <see cref="PrimaryKeyGetterCompiledDelegate"/> property.
    /// </summary>
    private Func<TEntity, TKey> _primaryKeyGetterCompiledDelegate;
    /// <summary>
    ///   First-pass expression builder with singleton-style value caching.
    /// </summary>
    public Func<TEntity, TKey> PrimaryKeyGetterCompiledDelegate
    {
      get => _primaryKeyGetterCompiledDelegate ??
             (_primaryKeyGetterCompiledDelegate = PrimaryKeyGetterExpression.Compile());
    }

    /// <summary>
    ///   Backing field for the <see cref="PrimaryKeySetterCompiledDelegate"/> property.
    /// </summary>
    private Action<TEntity, TKey> _primaryKeySetterCompiledDelegate;
    /// <summary>
    ///   First-pass expression builder with singleton-style value caching.
    /// </summary>
    public Action<TEntity, TKey> PrimaryKeySetterCompiledDelegate
    {
      get => _primaryKeySetterCompiledDelegate ??
             (_primaryKeySetterCompiledDelegate = PrimaryKeySetterExpression.Compile());
    }

    #endregion


    #region Constructors
    /// <summary>
    ///   Creates an instance of the <see cref="EntityPrimaryKeyResolver{TEntity,TKey,TContext}"/> type,
    ///   associated with the <typeparamref name="TContext"/> type, which inherits the Entity Framework 
    ///   base type <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">
    ///   The instance of the <typeparamref name="TContext"/> Entity Framework type <see cref="DbContext"/> 
    ///   in which to associate the instance's primary key resolver with.
    /// </param>
    public EntityPrimaryKeyResolver(
      TContext context)
    {
      var entityType = context
        .Model
        .FindEntityType(typeof(TEntity));

      var primaryKey = entityType
        .FindPrimaryKey();

      var property = primaryKey
        .Properties
        .Select(t => t.Name);

      var keyName = property
        .Single();

      _primaryKeyPropertyName = keyName;

      #region Old EF6 implementation
      //var objectContext = ((IObjectContextAdapter)context)
      //	.ObjectContext;

      //var set = objectContext.CreateObjectSet<TEntity>();

      //var keyNames = set.EntitySet.ElementType
      //														.KeyMembers
      //														.Select(k => k.Name)
      //														.ToArray();
      //if (keyNames.Length != 1)
      //	throw new NotSupportedException();

      //_primaryKeyPropertyName = keyNames[0];
      #endregion
    }

    #endregion


    #region Methods
    /// <summary>
    ///   Dynamically builds a lambda expression expecting a <typeparamref name="TEntity"/> 
    ///   parameter, and returns a <typeparamref name="TKey"/> indicating the primary key 
    ///   property where the provided <typeparamref name="TEntity"/> inherits the base class 
    ///   <see cref="EntityBase"/>, and the <typeparamref name="TKey"/> implements the 
    ///   interface type <see cref="IComparable"/>.
    /// </summary>
    /// <param name="propertyName">
    ///   The <see cref="string"/> name of the property for the <typeparamref name="TEntity"/>
    ///   type's primary key property type. 
    /// </param>
    /// <returns>
    ///   Returns a dynamically built lambda expression accepting a <typeparamref name="TEntity"/>
    ///   parameter, and returning a <typeparamref name="TKey"/> indicating the primary key
    ///   property of the provided entity instance.
    /// </returns>
    protected static Expression<Func<TEntity, TKey>> buildPrimaryKeyGetterExpression(
      string propertyName)
    {
      var lambdaArgument = Expression.Parameter(
        typeof(TEntity), "t");

      var memberExpression = Expression.Property(
        lambdaArgument,
        propertyName);

      var lambdaExpression = Expression
        .Lambda<Func<TEntity, TKey>>(
          memberExpression,
          lambdaArgument);

      return lambdaExpression;
    }

    /// <summary>
    ///   Dynamically builds a lambda expression expecting a <typeparamref name="TEntity"/> and a 
    ///   <typeparamref name="TKey"/> parameter, and returning void.
    /// </summary>
    /// <param name="propertyName">
    ///   The <see cref="string"/> name of the property for the <typeparamref name="TEntity"/>
    ///   type's primary key property type. 
    /// </param>
    /// <returns>
    ///   Returns a dynamically built lambda expression accepting a <typeparamref name="TEntity"/>
    ///   and a <typeparamref name="TKey"/> parameter, and returning void, building a lambda 
    ///   expression whose body is a value assignment expression to set the primary key property 
    ///   of the provided entity instance.
    /// </returns>
    protected static Expression<Action<TEntity, TKey>> buildPrimaryKeySetterExpression(
      string propertyName)
    {
      var targetLambdaArgument = Expression.Parameter(
        typeof(TEntity), "t");

      var valueLambdaArgument = Expression.Parameter(
        typeof(TKey), "v");

      var memberExpression = Expression.Property(
        targetLambdaArgument,
        propertyName);

      var assignExpression = Expression.Assign(
        memberExpression,
        valueLambdaArgument);

      var lambdaExpression = Expression
        .Lambda<Action<TEntity, TKey>>(
          assignExpression,
          targetLambdaArgument,
          valueLambdaArgument);

      return lambdaExpression;
    }


    /// <summary>
    ///   Provides an explicit interface implementation for the <see cref="IEntityPrimaryKeyResolver"/> 
    ///   base getter method to provide access to the entity type's primary key property value.    
    /// </summary>
    /// <param name="entityBase">
    ///   The instance of the entity as the base type <see cref="EntityBase"/> in which to access the
    ///   primary key property value upon. This value must be of type <typeparamref name="TEntity"/>.
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///   Throws when the parameter <paramref name="entityBase"/> is not of the type or implicitly 
    ///   convertable to the type <typeparamref name="TEntity"/>.
    /// </exception>
    /// <returns>
    ///   Returns the primary key property value of the entity instance <paramref name="entityBase"/>
    ///   as the base primary key type <typeparamref name="TKey"/> boxed in a <see cref="IComparable"/>.
    /// </returns>
    IComparable IEntityPrimaryKeyResolver.GetPrimaryKeyBase(
      EntityBase entityBase)
    {
      var entity = entityBase as TEntity;
      if (entity == null)
        throw new InvalidOperationException(
          $"The type {entityBase.GetType().Name.SQuote()} is not supported from the base primary key " +
          $"getter method. The 'entityBase' parameter must be of type {typeof(TEntity).Name.SQuote()}.");

      return GetPrimaryKey(
        entity);
    }

    /// <summary>
    ///   Provides an explicit interface implementation for the <see cref="IEntityPrimaryKeyResolver"/> 
    ///   base setter method to provide access to the entity type's primary key property value.
    /// </summary>
    /// <param name="entityBase">
    ///   The instance of the entity as the base type <see cref="EntityBase"/> in which to set the
    ///   primary key property value on. This value must be of type <typeparamref name="TEntity"/>.
    /// </param>
    /// <param name="keyBase">
    ///   The value in which to set the primary key property value on the <paramref name="entityBase"/>
    ///   instance. This value must be of type <typeparamref name="TEntity"/>.
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///   Throws when the parameter <paramref name="entityBase"/> is not of the type or implicitly 
    ///   convertable to the type <typeparamref name="TEntity"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///   Throws when the parameter <paramref name="keyBase"/> is not of the type or implicitly 
    ///   convertable to the type <typeparamref name="TKey"/>.
    /// </exception>
    void IEntityPrimaryKeyResolver.SetPrimaryKeyBase(
      EntityBase entityBase,
      IComparable keyBase)
    {
      var entity = entityBase as TEntity;
      if (entity == null)
        throw new InvalidOperationException(
          $"The type {entityBase.GetType().Name.SQuote()} is not supported from the base primary key " +
          $"getter method. The 'entityBase' parameter must be of type {typeof(TEntity).Name.SQuote()}.");

      if (!(keyBase is TKey))
        throw new InvalidOperationException(
          $"The type {keyBase.GetType().Name.SQuote()} is not supported from the base primary key " +
          $"setter method. The 'keyBase' parameter must be of type {typeof(TKey).Name.SQuote()}.");

      var key = (TKey)keyBase;

      SetPrimaryKey(
        entity,
        key);
    }


    /// <summary>
    ///   Gets the primary key property value from the entity instance provided by the parameter 
    ///   <paramref name="entity"/>.
    /// </summary>
    /// <param name="entity">
    ///   The instance of the entity as the type <typeparamref name="TEntity"/>.
    /// </param>
    /// <returns>
    ///   Returns the primary key property value as the type <typeparamref name="TKey"/> from the entity 
    ///   instance provided by the parameter <paramref name="entity"/>.
    /// </returns>
    public TKey GetPrimaryKey(
      TEntity entity)
    {
      return PrimaryKeyGetterCompiledDelegate(
        entity);
    }

    /// <summary>
    ///   Sets the primary key property value of the entity instance specified by the <paramref 
    ///   name="entity"/> parameter to the value provided by the <paramref name="value"/> parameter.
    /// </summary>
    /// <param name="entity">
    ///   The instance of the type <typeparamref name="TEntity"/> in which to access to the primary key 
    ///   property value upon. 
    /// </param>
    /// <param name="value">
    ///   The value in which to set the primary key property value on the <paramref name="entity"/> 
    ///   instance.
    /// </param>
    public void SetPrimaryKey(
      TEntity entity,
      TKey value)
    {
      PrimaryKeySetterCompiledDelegate(
        entity,
        value);
    }
    

    /// <summary>
    ///   Dynamically builds a lambda expression expecting a <typeparamref name="TEntity"/> parameter
    ///   and returning <see cref="bool"/>.
    /// </summary>
    /// <param name="keyValue">
    ///   The primary key property value in which to create a value equality predicate expression with.
    /// </param>
    /// <returns>
    ///   Returns a dynamically built lambda expression accepting a <typeparamref name="TEntity"/> 
    ///   parameter and returning <see cref="bool"/>, whose body is a value equality predicate expression.
    /// </returns>
    public Expression<Func<TEntity, bool>> CreatePrimaryKeyExpressionPredicate(
      TKey keyValue)
    {
      var lambdaArgument = Expression.Parameter(
        typeof(TEntity),
        typeof(TEntity).Name);

      var binaryExpr = Expression.Equal(
        Expression.Property(lambdaArgument, _primaryKeyPropertyName),
        Expression.Constant(keyValue));

      var lambdaExpr = Expression.Lambda<Func<TEntity, bool>>(
        binaryExpr,
        lambdaArgument);

      return lambdaExpr;
    }

   
    /// <summary>
    ///   Dynamically builds a lambda expression expecting a <typeparamref name="TEntity"/> parameter
    ///   and returning <see cref="bool"/>.
    /// </summary>
    /// <param name="keyValue">
    ///   The primary key property value in which to create a value equality predicate expression with.
    /// </param>
    /// <returns>
    ///   Returns a dynamically built lambda expression accepting a <typeparamref name="TEntity"/> 
    ///   parameter and returning <see cref="bool"/>, whose body is a value equality predicate expression.
    /// </returns>
    public Expression<Func<TEntity, bool>> CreatePrimaryKeyExpressionPredicateBase(
      IComparable keyValue)
    {
      var lambdaArgument = Expression.Parameter(
        typeof(TEntity),
        typeof(TEntity).Name);

      var binaryExpr = Expression.Equal(
        Expression.Property(lambdaArgument, _primaryKeyPropertyName),
        Expression.Constant(keyValue));

      var lambdaExpr = Expression.Lambda<Func<TEntity, bool>>(
        binaryExpr,
        lambdaArgument);

      return lambdaExpr;
    }


    #endregion
  }
}
#pragma warning restore IDE1006 // Naming Styles