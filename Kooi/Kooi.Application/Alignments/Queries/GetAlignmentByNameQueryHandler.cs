
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Alignments.Queries
{
    internal class GetAlignmentByNameQueryHandler : IRequestHandler<GetAlignmentByNameQuery, ErrorOr<BaseResponse<GetAlignmentResponse>>>
    {
        IAlignmentsRepository _repository;
        public GetAlignmentByNameQueryHandler(IAlignmentsRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<BaseResponse<GetAlignmentResponse>>> Handle(GetAlignmentByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAlignmentByNameAsync(request.Type);
            if (!result.IsError)
            {
                var getAlignmentResponse = new GetAlignmentResponse(result.Value.Id, result.Value.Name);
                return new BaseResponse<GetAlignmentResponse>(getAlignmentResponse);
            }
            return result.Errors;
        }
    }
}
