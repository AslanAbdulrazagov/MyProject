using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class EmployeeGetDto
{
    public string Fullname { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Phone]
    public string PhoneNumber { get; set; } = null!;
    public DepartmentRelationDto Department { get; set; } = null!;
    public int DepartmentId { get; set; }
    public Address? Address { get; set; } = null!;
    public int? AddressId { get; set; }
}
