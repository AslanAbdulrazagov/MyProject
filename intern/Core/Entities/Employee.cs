using Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Employee:BaseEntity
{
    public string Fullname { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Phone]
    public string PhoneNumber { get; set; } = null!;
    public Department Department { get; set; }=null!;
    public int DepartmentId { get; set; }
    public Address? Address { get; set; } = null!;
    public int? AddressId { get; set; }


}
