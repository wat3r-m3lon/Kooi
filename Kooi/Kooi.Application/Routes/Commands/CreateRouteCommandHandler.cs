using ErrorOr;
using Kooi.Domain.Models.Routes;
using Kooi.Domain.Repositories;
using MediatR;
  
namespace Kooi.Application.Routes.Commands
{
    internal sealed class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, ErrorOr<Guid>>
    {
        private readonly IRouteRepository _routeRepository;
        public CreateRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public async Task<ErrorOr<Guid>> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            return await _routeRepository.CreateRouteAsync(Route.Create(request.Uri));
        }
    }
}
