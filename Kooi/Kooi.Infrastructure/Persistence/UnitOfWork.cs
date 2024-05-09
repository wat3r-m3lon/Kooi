using Kooi.Application.Data;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Kooi.Infrastructure.Persistence
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

    }
}
