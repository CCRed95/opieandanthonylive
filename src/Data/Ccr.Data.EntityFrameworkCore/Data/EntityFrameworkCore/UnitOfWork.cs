using System;
using System.Collections.Generic;
using System.Linq;
using Ccr.Data.EntityFrameworkCore.Infrastucture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ccr.Data.EntityFrameworkCore
{
  public class UnitOfWork<TContext>
    : IUnitOfWork
      where TContext
        : DbContext//, new()
  {
    private IDbContextTransaction _transaction;
    private readonly Dictionary<Type, object> _repositories;
    private readonly TContext _context;


    public UnitOfWork()
      : this(
        Activator.CreateInstance<TContext>())
    {
      _repositories = new Dictionary<Type, object>();
    }

    public UnitOfWork(
      TContext context)
    {
      _context = context;
    }

    public TRepository GetCustomRepository<TRepository, TEntity>()
      where TRepository
        : IRepository<TEntity>
      where TEntity
        : EntityBase
    {
      throw new NotImplementedException();
      //if (_repositories.Keys.Contains(typeof(TEntity)))
      //  return _repositories[typeof(TEntity)].As<TRepository>();

      //var repository =
      //  new IntrospectiveStaticContext<TRepository>()
      //  .InvokeCtorGeneric(
      //    MemberDescriptor.Any,
      //    new[] { typeof(TContext) },
      //    new object[] { _context });

      //_repositories.Add(typeof(TEntity), repository);
      //return repository;
    }

    public IRepository<TSet, TKey> GetRepository<TSet, TKey>()
      where TSet
        : EntityBase
      where TKey
        : IComparable
    {
      if (_repositories
        .Keys
        .Contains(
          typeof(TSet)))
        return _repositories[typeof(TSet)] as IRepository<TSet, TKey>;

      var repository = new Repository<TSet, TKey, TContext>(
        _context);

      _repositories.Add(
        typeof(TSet), 
        repository);

      return repository;
    }

    public IRepository<TSet> GetRepositoryBase<TSet>()
      where TSet 
        : EntityBase
    {
      if (_repositories
        .Keys
        .Contains(
          typeof(TSet)))
        return _repositories[typeof(TSet)] as IRepository<TSet>;

      var repository = new Repository<TSet, IComparable, TContext>(
        _context);

      _repositories.Add(
        typeof(TSet),
        repository);

      return repository;
    }

    /// <summary>
    /// Start Transaction
    /// </summary>
    /// <returns></returns>
    public IDbContextTransaction BeginTransaction()
    {
      if (null == _transaction)
      {
        //using (var connection = _context.GetSingularDbConnection())
        //{
        //}
        _transaction = _context
          .Database
          .BeginTransaction();
      }
      return _transaction;
    }

    public int Save()
    {
      return _context
        .SaveChanges();
    }

    #region IDisposable Members
    public void Dispose()
    {
      _transaction?.Dispose();
      _context?.Dispose();
    }

    #endregion
  }
}
