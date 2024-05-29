using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class GenericProfile : Profile   
{
    public GenericProfile()
    {  
        CreateMap<UserEntity,UserDto>();
        CreateMap<RoleEntity,RoleDto>();
        CreateMap<UserRoleEntity,UserRoleDto>();
    }
}