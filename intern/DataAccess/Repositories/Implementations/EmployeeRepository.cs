using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstractions;
using DataAccess.Repositories.Implementations.Generic;

namespace DataAccess.Repositories.Implementations;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }
}
