
using ErrorOr;
using Kooi.Application.Data;
using Kooi.Application.Services;
using Kooi.Domain.Models.Tours;
using Kooi.Domain.Repositories;
using MediatR;
using Kooi.Domain.Common.Errors;

namespace Kooi.Application.Tours.Commands
{
    internal sealed class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, ErrorOr<Guid>>
    {
        private readonly ITourRepository _tourRepository;
        private readonly ITourAuditLogRepository _tourAuditLogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        public CreateTourCommandHandler(
            ITourRepository tourRepository, 
            ITourAuditLogRepository tourAuditLogRepository, 
            IUnitOfWork unitOfWork, 
            IDateTimeProvider dateTimeProvider)
        {
            _tourRepository = tourRepository;
            _tourAuditLogRepository = tourAuditLogRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }
        public async Task<ErrorOr<Guid>> Handle(CreateTourCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var tourResult = await _tourRepository.CreateTourAsync(Tour.Create(
                    command.Name,
                    command.RouteId,
                    command.Required
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                var tourAuditLogRestult = await _tourAuditLogRepository.CreateTourAuditLogAsync(TourAuditLog.Create(
                    tourResult,
                    command.UserId,
                    _dateTimeProvider.Now,
                    false
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.CommitTransaction();
                return tourResult;
            }
            catch (Exception)
            {
                return Errors.Tour.CreationFailed;
            }
        }

    }
}
