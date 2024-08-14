using AutoMapper;
using CRM.Application.DTOs.User;
using CRM.Domain.Entities;

namespace CRM.Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDto>();
    }
}