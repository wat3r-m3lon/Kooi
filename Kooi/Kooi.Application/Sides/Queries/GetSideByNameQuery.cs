
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.Sides.Queries
{
    public sealed record GetSideByNameQuery(
        string Type
        ) : IRequest<ErrorOr<BaseResponse<GetSideResponse>>>;
}
