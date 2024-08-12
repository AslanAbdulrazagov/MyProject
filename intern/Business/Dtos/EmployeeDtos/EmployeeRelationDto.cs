using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class EmployeeRelationDto
{
    public string Fullname { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Phone]
    public string PhoneNumber { get; set; } = null!;
    public int DepartmentId { get; set; }
    public int? AddressId { get; set; }
}
