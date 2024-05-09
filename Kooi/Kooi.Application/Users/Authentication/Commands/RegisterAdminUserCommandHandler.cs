using Kooi.Application.Abstractions.Authentication;
using MediatR;
using ErrorOr;
using Kooi.Domain.Repositories;
using Kooi.Domain.Models.Users;
using Kooi.Application.Services;
using Kooi.Domain.Common.Errors;

namespace Kooi.Application.Users.Authentication.Commands
{
    internal sealed class RegisterAdminUserCommandHandler : IRequestHandler<RegisterAdminUserCommand, ErrorOr<AuthenticationResult>>

    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAdminUsersRepository _adminUsersRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public RegisterAdminUserCommandHandler(IAuthenticationService authenticationService, IAdminUsersRepository adminUsersRepository, IUsersRepository usersRepository, IDateTimeProvider dateTimeProvider)
        {
            _authenticationService = authenticationService;
            _adminUsersRepository = adminUsersRepository;
            _usersRepository = usersRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterAdminUserCommand command, CancellationToken cancellationToken)
        {
            if (await _adminUsersRepository.AdminUserEmailExistsAsync(command.Email))
            {
                return Errors.User.EmailInvalid;
            }
            var result = await _authenticationService.RegisterAsync(command.Email, command.Password);
            var id = await _usersRepository.CreateUserAsync(User.Create(command.NetwrokId, _dateTimeProvider.Now, _dateTimeProvider.Now));
            if (!result.IsError && !id.IsError)
            {
                await _adminUsersRepository.CreateAdminUserAsync(AdminUser.Create(command.Email, result.Value.Token, id.Value, command.RoleId, command.Fullname));

            }
            return result;
        }
    }
}
