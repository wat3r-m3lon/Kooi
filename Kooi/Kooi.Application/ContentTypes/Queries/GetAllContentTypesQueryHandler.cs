using Kooi.Application.Responses;
using Kooi.Contracts.Lookups;
using Kooi.Domain.Models.Lookups;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.ContentTypes.Queries
{
    internal class GetAllContentTypesQueryHandler : IRequestHandler<GetAllContentTypesQuery, BaseResponse<List<GetContentTypeResponse>>>
    {
        IContentTypesRepository _repository;
        public GetAllContentTypesQueryHandler(IContentTypesRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<GetContentTypeResponse>>> Handle(GetAllContentTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllContentTypesAsync();
            List<GetContentTypeResponse> responses = new List<GetContentTypeResponse>();
            foreach (ContentType contentType in result)
            {
                var response = new GetContentTypeResponse(
                    contentType.Id,
                    contentType.Type
                    );
                responses.Add(response);
            }
            return new BaseResponse<List<GetContentTypeResponse>>(responses);
        }
    }
}
