using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Users;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Users.Authentication.Queries
{
    internal class GetAdminUserByFirebaseIdQueryHandler : IRequestHandler<GetAdminUserByFirebaseIdQuery, ErrorOr<BaseResponse<GetAdminUserResponse>>>
    {

        private readonly IAdminUsersRepository _userssRepository;
        public GetAdminUserByFirebaseIdQueryHandler(IAdminUsersRepository userssRepository)
        {
            _userssRepository = userssRepository;
        }

        public async Task<ErrorOr<BaseResponse<GetAdminUserResponse>>> Handle(GetAdminUserByFirebaseIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userssRepository.GetAdminUserByIdAsync(request.FirebaseId);
            if (!result.IsError)
            {
                var user = result.Value;
                var userResponse = new GetAdminUserResponse(
                  user.Id,
                  user.Email,
                  user.FirebaseId,
                  user.UserId,
                  user.RoleId,
                  user.Fullname);
                return new BaseResponse<GetAdminUserResponse>(userResponse);
            }
            return result.Errors;
        }
    }
}
