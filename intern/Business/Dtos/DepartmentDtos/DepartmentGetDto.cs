namespace Business.Dtos;

public class DepartmentGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<EmployeeRelationDto> Employees { get; set; }= new List<EmployeeRelationDto>();
}
