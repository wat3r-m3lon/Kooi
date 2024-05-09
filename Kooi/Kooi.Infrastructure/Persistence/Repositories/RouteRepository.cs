using ErrorOr;
using Kooi.Domain.Models.Routes;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Kooi.Domain.Common.Errors;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class RouteRepository : IRouteRepository
    {
        private readonly ApplicationDbContext _context;
        public RouteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ErrorOr<Guid>> CreateRouteAsync(Route route)
        {
            await _context.AddAsync<Route>(route);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Errors.Route.CreationFailed;
            }
            return route.Id;
        }
    }
}
