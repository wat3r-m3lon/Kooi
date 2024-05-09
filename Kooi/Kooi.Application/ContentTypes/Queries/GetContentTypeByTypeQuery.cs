
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.ContentTypes.Queries
{
    public sealed record GetContentTypeByTypeQuery(
        string Type
        ) : IRequest<ErrorOr<BaseResponse<GetContentTypeResponse>>>;
}
