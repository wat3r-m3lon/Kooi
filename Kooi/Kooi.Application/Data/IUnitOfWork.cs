using Microsoft.EntityFrameworkCore;

namespace Kooi.Application.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public void BeginTransaction();
   
        public void CommitTransaction();
    }
}
