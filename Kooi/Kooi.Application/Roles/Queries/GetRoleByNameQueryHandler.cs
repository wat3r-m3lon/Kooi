
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Roles.Queries
{
    internal class GetRoleByNameQueryHandler : IRequestHandler<GetRoleByNameQuery, ErrorOr<BaseResponse<GetRoleResponse>>>
    {
        IRolesRepository _repository;
        public GetRoleByNameQueryHandler(IRolesRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<BaseResponse<GetRoleResponse>>> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetRoleByNameAsync(request.Type);
            if (!result.IsError)
            {
                var getRoleResponse = new GetRoleResponse(result.Value.Id, result.Value.Name);
                return new BaseResponse<GetRoleResponse>(getRoleResponse);
            }
            return result.Errors;
        }
    }
}
