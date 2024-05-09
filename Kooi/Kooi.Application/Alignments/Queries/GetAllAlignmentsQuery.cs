
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using MediatR;

namespace Kooi.Application.Alignments.Queries
{
    public sealed record GetAllAlignmentsQuery : IRequest<BaseResponse<List<GetAlignmentResponse>>> { };
}
