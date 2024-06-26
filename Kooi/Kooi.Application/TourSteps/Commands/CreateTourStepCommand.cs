﻿
using ErrorOr;
using MediatR;

namespace Kooi.Application.TourSteps.Commands
{
    public sealed record CreateTourStepCommand(
        Guid TourId,
        int Sequence,
        Guid AlignId,
        Guid SideId,
        string Title,
        Guid ContenTtypeId,
        string Description,
        bool ShowProgress,
        string ProgressText,
        string NextBtnText,
        string PrevBtnText,
        string DoneBtnText,
        string ElementIdentifier,
        Guid IconId,
        Guid IconSideId,
        Guid IconAlignId,
        Guid RouteId
        ):IRequest<ErrorOr<Guid>>;
}
