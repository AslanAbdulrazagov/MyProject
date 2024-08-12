using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<ResultDto> CreateAsync(DepartmentPostDto dto);
        Task<ResultDto> UpdateAsync(DepartmentPutDto dto);
        Task<ResultDto> DeleteAsync(int id);
        Task<DepartmentGetDto> GetByIdAsync(int id);
        Task<List<DepartmentGetDto>> GetAllAsync();
    }
}
