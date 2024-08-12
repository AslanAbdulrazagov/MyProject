using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstractions;
using DataAccess.Repositories.Implementations.Generic;

namespace DataAccess.Repositories.Implementations;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }
}