

using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Tooltip;
using MediatR;

namespace Kooi.Application.Tooltips.Queries
{
    public sealed record GetTooltipByIdQuery(
        Guid Id
        ) : IRequest<ErrorOr<BaseResponse<GetTooltipResponse>>>;
}
