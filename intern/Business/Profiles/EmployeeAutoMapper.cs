using AutoMapper;
using Core.Entities;

namespace Business.Profiles;

public class EmployeeAutoMapper : Profile
{
    public EmployeeAutoMapper()
    {
        CreateMap<Employee, EmployeeGetDto>().ReverseMap();
        CreateMap<Employee, EmployeePostDto>().ReverseMap();
        CreateMap<Employee, EmployeePutDto>().ReverseMap();                                         
        CreateMap<Employee, EmployeeRelationDto>().ReverseMap();

    }
}
