
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Alignments.Queries
{
    internal class GetAlignmentByIdQueryHandler : IRequestHandler<GetAlignmentByIdQuery, ErrorOr<BaseResponse<GetAlignmentResponse>>>
    {
        IAlignmentsRepository _repository;
        public GetAlignmentByIdQueryHandler(IAlignmentsRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<BaseResponse<GetAlignmentResponse>>> Handle(GetAlignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAlignmentByIdAsync(request.Id);
            if (!result.IsError)
            {
                var getAlignmentResponse = new GetAlignmentResponse(result.Value.Id, result.Value.Name);
                return new BaseResponse<GetAlignmentResponse>(getAlignmentResponse);
            }
            return result.Errors;
        }
    }
}
