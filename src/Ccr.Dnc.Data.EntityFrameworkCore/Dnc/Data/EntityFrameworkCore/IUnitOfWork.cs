using System;
using Ccr.Dnc.Data.EntityFrameworkCore.Infrastucture;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ccr.Dnc.Data.EntityFrameworkCore
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
