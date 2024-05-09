using ErrorOr;
using Kooi.Application.Abstractions.Authentication;
using MediatR;

namespace Kooi.Application.Users.Authentication.Commands
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
    {
      
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IJwtProvider jwtProvider)
        {
          
           _jwtProvider = jwtProvider;
        }
        
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _jwtProvider.GetCredentialsAsync(request.Email, request.Password);
        }
    }
}
