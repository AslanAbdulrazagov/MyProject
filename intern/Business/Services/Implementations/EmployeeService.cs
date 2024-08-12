using AutoMapper;
using Business.Exceptions;
using Business.Services.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResultDto> CreateAsync(EmployeePostDto dto)
    {
        var isExist = await _repository.IsExistAsync(x => x.Email.ToLower() == dto.Email.ToLower());


        if (isExist)
            throw new AlreadyExistException($"{dto.Email} this email is already exist");

        Employee employee = _mapper.Map<Employee>(dto);

        await _repository.CreateAsync(employee);
        await _repository.SaveChangesAsync();


        return new("Employee successfully added");
    }

    public async Task<ResultDto> DeleteAsync(int id)
    {
        var employee = await _repository.GetSingleAsync(x => x.Id == id);

        if (employee is null)
            throw new NotFoundException();

        _repository.Delete(employee);
        await _repository.SaveChangesAsync();
        return new("Employee was deleted");
    }

    public async Task<List<EmployeeGetDto>> GetAllAsync()
    {
        var employees = await _repository.GetAll("Department", "Address").ToListAsync();


        //List<EmployeeGetDto> result = new();

        //employees.ForEach(employee =>
        //{
        //    DepartmentRelationDto department = new()
        //    {
        //        Name = employee.Department.Name,
        //        Id = employee.DepartmentId,
        //    };
        //    EmployeeGetDto dto = new()
        //    {
        //        Fullname = employee.Fullname,
        //        Email = employee.Email,
        //        AddressId = employee.AddressId,
        //        DepartmentId = employee.DepartmentId,
        //        PhoneNumber = employee.PhoneNumber,
        //        Department = department,

        //    };

        //    result.Add(dto);
        //});

        var result = _mapper.Map<List<EmployeeGetDto>>(employees);

        return result;
    }

    public async Task<EmployeeGetDto> GetByIdAsync(int id)
    {
        var existEmployee = await _repository.GetSingleAsync(x => x.Id == id);

        if (existEmployee is null)
            throw new NotFoundException();

        var result = _mapper.Map<EmployeeGetDto>(existEmployee);
        return result;


    }

    public async Task<ResultDto> UpdateAsync(EmployeePutDto dto)
    {
        var existEmployee = await _repository.GetSingleAsync(x => x.Id == dto.Id);

        if (existEmployee is null)
            throw new NotFoundException($"{dto.Id}-this employee is not found");

        var isExist = await _repository.IsExistAsync(x => x.Email.ToLower() == dto.Email.ToLower() && x.Id != dto.Id);
        if (isExist)
            throw new AlreadyExistException($"{dto.Email}-Email already exist");

        existEmployee.Email = dto.Email;
        existEmployee.PhoneNumber = dto.PhoneNumber;
        existEmployee.Fullname = dto.Fullname;
        existEmployee.DepartmentId = dto.DepartmentId;


        _repository.Update(existEmployee);
        await _repository.SaveChangesAsync();

        return new($"{existEmployee.Fullname}-employee is successfully updated");

    }


    //public async Task<List<EmployeeGetDto>> GetEmployeesByDepartmentId(int departmentId)
    //{
    //    var employees = await _repository.GetFilter(x => x.DepartmentId == departmentId, "Department").ToListAsync();

    //    var dtos = _mapper.Map<List<EmployeeGetDto>>(employees);
    //    return dtos;
    //}
}
