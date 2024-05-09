using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.ContentTypes.Queries
{
    public sealed record GetAllContentTypesQuery : IRequest<BaseResponse<List<GetContentTypeResponse>>> { };
}
