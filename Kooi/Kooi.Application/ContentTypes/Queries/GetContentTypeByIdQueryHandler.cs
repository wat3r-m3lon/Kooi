
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.ContentTypes.Queries
{
    internal class GetContentTypeByIdQueryHandler : IRequestHandler<GetContentTypeByIdQuery, ErrorOr<BaseResponse<GetContentTypeResponse>>>
    {
        IContentTypesRepository _repository;
        public GetContentTypeByIdQueryHandler(IContentTypesRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<BaseResponse<GetContentTypeResponse>>> Handle(GetContentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetContentTypeByIdAsync(request.Id);
            if (!result.IsError)
            {
                var getContentTypeResponse = new GetContentTypeResponse(result.Value.Id, result.Value.Type);
                return new BaseResponse<GetContentTypeResponse>(getContentTypeResponse);
            }
            return result.Errors;
        }
    }
}
