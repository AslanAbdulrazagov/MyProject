namespace Business.Dtos;

public class RegisterDto
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}
