using AutoMapper;
using Core.Entities;

namespace Business.Profiles;

public class DepartmentAutoMapper :Profile
{
    public DepartmentAutoMapper()
    {
        CreateMap<Department,DepartmentGetDto>().ReverseMap();
        CreateMap<Department,DepartmentRelationDto>().ReverseMap();
        CreateMap<Department,DepartmentPostDto>().ReverseMap();
        CreateMap<Department,DepartmentPutDto>().ReverseMap();
    }
}
