using ApiCompras.Domain.Repositories;
using ApiCompras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApiCompras.Infra.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApiDbContext _db;
    private IDbContextTransaction _transaction;

    public UnitOfWork(ApiDbContext db)
    {
        _db = db;
    }

    public async Task BeginTransaction()
    {
        _transaction = await _db.Database.BeginTransactionAsync();        
    }

    public async Task Commit()
    {
        await _transaction.CommitAsync();
    }
    public async Task Rollback()
    {
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }    
}
