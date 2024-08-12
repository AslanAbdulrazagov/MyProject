using Core.Entities.Common;

namespace Core.Entities;

public class Address : BaseEntity
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
    public int EmployeId { get; set; }
}