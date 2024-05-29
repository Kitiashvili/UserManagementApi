using Application.DTOs;
using MediatR;

namespace Application.Queries.GetUsers;

public sealed class GetUsersQuery : IRequest<List<UserDto>>
{
    
}