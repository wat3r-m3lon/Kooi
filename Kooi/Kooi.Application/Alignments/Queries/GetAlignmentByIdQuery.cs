
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.Alignments.Queries
{
    public sealed record GetAlignmentByIdQuery(
        Guid Id
        ) : IRequest<ErrorOr<BaseResponse<GetAlignmentResponse>>>;
}
