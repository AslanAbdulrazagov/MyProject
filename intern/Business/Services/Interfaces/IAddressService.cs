using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IAddressService
    {
        Task<ResultDto> CreateAsync(AddressPostDto dto);
        Task<ResultDto> UpdateAsync(AddressPutDto dto);
        Task<ResultDto> DeleteAsync(int id);
        Task<AddressGetDto> GetByIdAsync(int id);
        Task<List<AddressGetDto>> GetAllAsync();
    }
}
