
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Models.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Roles.Queries
{
    internal class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, BaseResponse<List<GetRoleResponse>>>
    {
        IRolesRepository _repository;
        public GetAllRolesQueryHandler(IRolesRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<GetRoleResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllRolesAsync();
            List<GetRoleResponse> responses = new List<GetRoleResponse>();
            foreach (Role role in result)
            {
                var response = new GetRoleResponse(
                    role.Id,
                    role.Name
                    );
                responses.Add(response);
            }
            return new BaseResponse<List<GetRoleResponse>>(responses);
        }
    }
}
