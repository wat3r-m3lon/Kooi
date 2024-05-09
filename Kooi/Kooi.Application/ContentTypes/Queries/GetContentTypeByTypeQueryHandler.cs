
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.ContentTypes.Queries
{
    internal class GetContentTypeByTypeQueryHandler : IRequestHandler<GetContentTypeByTypeQuery, ErrorOr<BaseResponse<GetContentTypeResponse>>>
    {
        IContentTypesRepository _repository;
        public GetContentTypeByTypeQueryHandler(IContentTypesRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<BaseResponse<GetContentTypeResponse>>> Handle(GetContentTypeByTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetContentTypeByTypeAsync(request.Type);
            if (!result.IsError)
            {
                var getContentTypeResponse = new GetContentTypeResponse(result.Value.Id, result.Value.Type);
                return new BaseResponse<GetContentTypeResponse>(getContentTypeResponse);
            }
            return result.Errors;
        }
    }
}
