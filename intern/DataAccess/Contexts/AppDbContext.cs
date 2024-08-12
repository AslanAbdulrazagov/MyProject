using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
}
