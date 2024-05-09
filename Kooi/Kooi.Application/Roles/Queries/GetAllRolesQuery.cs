
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.Roles.Queries
{
    public sealed record GetAllRolesQuery : IRequest<BaseResponse<List<GetRoleResponse>>> { };
}
