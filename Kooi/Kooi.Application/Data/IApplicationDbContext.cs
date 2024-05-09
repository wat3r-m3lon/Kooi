using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Kooi.Application.Data
{
    public interface IApplicationDbContext
    {
        DatabaseFacade DatabaseFacade { get; }
    }
}