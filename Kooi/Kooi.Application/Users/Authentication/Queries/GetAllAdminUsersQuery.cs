
using Kooi.Application.Responses;
using Kooi.Contracts.Users;
using MediatR;

namespace Kooi.Application.Users.Authentication.Queries
{
    public sealed record GetAllAdminUsersQuery() : IRequest<BaseResponse<List<GetAdminUserResponse>>> 
    {
    }
}

