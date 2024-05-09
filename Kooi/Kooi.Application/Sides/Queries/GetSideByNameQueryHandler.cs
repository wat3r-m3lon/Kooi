
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Sides.Queries
{
    internal class GetSideByNameQueryHandler : IRequestHandler<GetSideByNameQuery, ErrorOr<BaseResponse<GetSideResponse>>>
    {
        ISidesRepository _repository;
        public GetSideByNameQueryHandler(ISidesRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<BaseResponse<GetSideResponse>>> Handle(GetSideByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetSideByNameAsync(request.Type);
            if (!result.IsError)
            {
                var getSideResponse = new GetSideResponse(result.Value.Id, result.Value.Name);
                return new BaseResponse<GetSideResponse>(getSideResponse);
            }
            return result.Errors;
        }
    }
}
