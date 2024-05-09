
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Models.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Alignments.Queries
{
    internal class GetAllAlignmentsQueryHandler : IRequestHandler<GetAllAlignmentsQuery, BaseResponse<List<GetAlignmentResponse>>>
    {
        IAlignmentsRepository _repository;
        public GetAllAlignmentsQueryHandler(IAlignmentsRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<GetAlignmentResponse>>> Handle(GetAllAlignmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAlignmentsAsync();
            List<GetAlignmentResponse> responses = new List<GetAlignmentResponse>();
            foreach (Alignment alignment in result)
            {
                var response = new GetAlignmentResponse(
                    alignment.Id,
                    alignment.Name
                    );
                responses.Add(response);
            }
            return new BaseResponse<List<GetAlignmentResponse>>(responses);
        }
    }
}
