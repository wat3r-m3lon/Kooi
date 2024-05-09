
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.Alignments.Queries
{
    public sealed record GetAlignmentByNameQuery(
        string Type
        ) : IRequest<ErrorOr<BaseResponse<GetAlignmentResponse>>>;
}
