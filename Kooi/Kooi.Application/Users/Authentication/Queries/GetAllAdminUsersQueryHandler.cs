
using Kooi.Application.Responses;
using Kooi.Application.Users.Authentication.Queries;
using Kooi.Contracts.Users;
using Kooi.Domain.Models.Users;
using Kooi.Domain.Repositories;
using MediatR;


namespace Kooi.Application.Users.Aurthentication.Queries
{
    internal class GetAllAdminUsersQueryHandler : IRequestHandler<GetAllAdminUsersQuery, BaseResponse<List<GetAdminUserResponse>>>
    {
        private readonly IAdminUsersRepository _usersRepository;

        public GetAllAdminUsersQueryHandler(IAdminUsersRepository userssRepository)
        {
            _usersRepository = userssRepository;
        }
        public async Task<BaseResponse<List<GetAdminUserResponse>>> Handle(GetAllAdminUsersQuery request, CancellationToken cancellationToken)
        {
            List<AdminUser> users = await _usersRepository.GetAllAdminUsersAsync();
            List<GetAdminUserResponse> responses = new List<GetAdminUserResponse>();
            foreach (var user in users)
            {
                var userResponse = new GetAdminUserResponse(
                user.Id,
                user.Email,
                user.FirebaseId,
                user.UserId,
                user.RoleId,
                user.Fullname);
                responses.Add(userResponse);
            }
            return new BaseResponse<List<GetAdminUserResponse>>(responses);
        }
    }
}
