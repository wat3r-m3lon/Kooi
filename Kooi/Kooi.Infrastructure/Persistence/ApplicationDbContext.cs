using Kooi.Application.Data;
using Kooi.Domain.Models.Routes;
using Kooi.Domain.Models.Tours;
using Kooi.Domain.Models.Tooltips;
using Kooi.Domain.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using Kooi.Domain.Models.Lookups;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        private readonly IPublisher _publisher;
        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        public DbSet<Tooltip> Tooltips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<TooltipInstruction> TooltipInstructions { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourStep> TourSteps { get; set; }
        public DbSet<TourAuditLog> TourAuditLog { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Alignment> Alignments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Side> Sides { get; set; }

        public DatabaseFacade DatabaseFacade => throw new NotImplementedException();
    }
}
