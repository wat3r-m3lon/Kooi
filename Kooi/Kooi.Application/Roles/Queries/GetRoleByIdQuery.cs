
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.Roles.Queries
{
    public sealed record GetRoleByIdQuery(
        Guid Id
        ) : IRequest<ErrorOr<BaseResponse<GetRoleResponse>>>;
}
