using AutoMapper;
using Core.Entities;

namespace Business.Profiles;

public class AppUserProfile:Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, RegisterDto>().ReverseMap();   
    }
}
