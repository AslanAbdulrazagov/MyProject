using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstractions;
using DataAccess.Repositories.Implementations.Generic;

namespace DataAccess.Repositories.Implementations;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext context) : base(context)
    {
    }
}