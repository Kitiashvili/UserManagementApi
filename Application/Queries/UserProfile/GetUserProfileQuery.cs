using Application.DTOs;
using MediatR;

namespace Application.Queries.UserProfile;

public sealed class GetUserProfileQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }
}