
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.Sides.Queries
{
    public sealed record GetAllSidesQuery : IRequest<BaseResponse<List<GetSideResponse>>> { };
}
