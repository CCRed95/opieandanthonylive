using System;
using Ccr.Data.EntityFrameworkCore.Infrastucture;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ccr.Data.EntityFrameworkCore
{
	public interface IUnitOfWork
    : IDisposable
	{
		IRepository<TSet> GetRepositoryBase<TSet>() 
			where TSet 
        : EntityBase;

	  IDbContextTransaction BeginTransaction();

		int Save();
	}
}
