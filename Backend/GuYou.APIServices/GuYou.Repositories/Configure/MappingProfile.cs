using AutoMapper;
using GuYou.Repositories.DTOs;
using GuYou.Repositories.Models;
using Microsoft.AspNetCore.Identity;

namespace GuYou.Repositories.Configure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<IdentityUser, UserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<IdentityRole, RoleResponse>().ReverseMap();
        }
    }

}
