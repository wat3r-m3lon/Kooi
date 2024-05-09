
using MediatR;
using ErrorOr;
using Kooi.Domain.Repositories;
using Kooi.Domain.Models.Users;
using Kooi.Application.Services;

namespace Kooi.Application.Users.Authentication.Commands
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<Guid>>

    {
        private readonly IUsersRepository _usersRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateUserCommandHandler(IUsersRepository usersRepository, IDateTimeProvider dateTimeProvider)
        {
            _usersRepository = usersRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<ErrorOr<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            return await _usersRepository.CreateUserAsync(User.Create(command.NetworkId, _dateTimeProvider.Now, _dateTimeProvider.Now)) ;
        }
    }
}
