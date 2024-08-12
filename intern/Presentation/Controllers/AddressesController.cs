using Business.Dtos;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressPostDto dto)
        {
            return Ok(await _addressService.CreateAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(AddressPutDto dto)
        {
            return Ok(await _addressService.UpdateAsync(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _addressService.GetAllAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _addressService.DeleteAsync(id));
        }
    }
}
