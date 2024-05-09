
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Roles.Queries
{
    internal class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, ErrorOr<BaseResponse<GetRoleResponse>>>
    {
        IRolesRepository _repository;
        public GetRoleByIdQueryHandler(IRolesRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<BaseResponse<GetRoleResponse>>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetRoleByIdAsync(request.Id);
            if (!result.IsError)
            {
                var getRoleResponse = new GetRoleResponse(result.Value.Id, result.Value.Name);
                return new BaseResponse<GetRoleResponse>(getRoleResponse);
            }
            return result.Errors;
        }
    }
}
