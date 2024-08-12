using AutoMapper;
using Business.Services.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultDto> CreateAsync(DepartmentPostDto dto)
        {
            var isExist = await _repository.IsExistAsync(x => x.Name.ToLower() == dto.Name.ToLower());

            if (isExist)
                throw new AlreadyExistException($"{dto.Name} this department already exists");

            var department = _mapper.Map<Department>(dto);

            await _repository.CreateAsync(department);
            await _repository.SaveChangesAsync();

            return new("Department successfully added");
        }

        public async Task<ResultDto> DeleteAsync(int id)
        {
            var department = await _repository.GetSingleAsync(x => x.Id == id);

            if (department is null)
                throw new NotFoundException();

            _repository.Delete(department);
            await _repository.SaveChangesAsync();
            return new("Department was deleted");
        }

        public async Task<List<DepartmentGetDto>> GetAllAsync()
        {
            var departments = await _repository.GetAll().ToListAsync();
            var result = _mapper.Map<List<DepartmentGetDto>>(departments);
            return result;
        }

        public async Task<DepartmentGetDto> GetByIdAsync(int id)
        {
            var existDepartment = await _repository.GetSingleAsync(x => x.Id == id);

            if (existDepartment is null)
                throw new NotFoundException();

            var result = _mapper.Map<DepartmentGetDto>(existDepartment);
            return result;
        }

        public async Task<ResultDto> UpdateAsync(DepartmentPutDto dto)
        {
            var existDepartment = await _repository.GetSingleAsync(x => x.Id == dto.Id);

            if (existDepartment is null)
                throw new NotFoundException($"{dto.Id}-this department is not found");

            var isExist = await _repository.IsExistAsync(x => x.Name.ToLower() == dto.Name.ToLower() && x.Id != dto.Id);
            if (isExist)
                throw new AlreadyExistException($"{dto.Name}-Name already exists");

            _mapper.Map(dto, existDepartment);
            existDepartment.Name = dto.Name;
            _repository.Update(existDepartment);
            await _repository.SaveChangesAsync();

            return new($"{existDepartment.Name}-department is successfully updated");
        }
    }
}
