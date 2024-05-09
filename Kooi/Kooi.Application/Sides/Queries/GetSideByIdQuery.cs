
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.Sides.Queries
{
    public sealed record GetSideByIdQuery(
        Guid Id
        ) : IRequest<ErrorOr<BaseResponse<GetSideResponse>>>;
}
