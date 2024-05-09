
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Models.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Sides.Queries
{
    internal class GetAllSidesQueryHandler : IRequestHandler<GetAllSidesQuery, BaseResponse<List<GetSideResponse>>>
    {
        ISidesRepository _repository;
        public GetAllSidesQueryHandler(ISidesRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<GetSideResponse>>> Handle(GetAllSidesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllSidesAsync();
            List<GetSideResponse> responses = new List<GetSideResponse>();
            foreach (Side side in result)
            {
                var response = new GetSideResponse(
                    side.Id,
                    side.Name
                    );
                responses.Add(response);
            }
            return new BaseResponse<List<GetSideResponse>>(responses);
        }
    }
}
