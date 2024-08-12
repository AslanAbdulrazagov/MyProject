using Core.Entities;

namespace Business.Services.Interfaces;

public interface IEmployeeService
{

    Task<ResultDto> CreateAsync(EmployeePostDto dto);

    Task<ResultDto> UpdateAsync(EmployeePutDto dto);
    Task<ResultDto> DeleteAsync(int id);
    Task<EmployeeGetDto> GetByIdAsync(int id);
    Task<List<EmployeeGetDto>> GetAllAsync();
}
