using Kooi.Application.Responses;
using Kooi.Contracts.Tooltip;
using MediatR;

namespace Kooi.Application.Tooltips.Queries
{
    public sealed record GetAllTooltipsQuery : IRequest<BaseResponse<List<GetTooltipResponse>>>
    {
    }
}
