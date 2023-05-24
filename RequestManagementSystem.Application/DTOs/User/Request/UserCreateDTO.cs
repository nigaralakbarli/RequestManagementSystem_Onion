namespace RequestManagementSystem.Application.DTOs.User.Request;

public class UserCreateDTO
{
    public string Name { get; set; }
    public string InternalNumber { get; set; }
    public string ContactNumber { get; set; }
    public string Password { get; set; }
    public string Position { get; set; }
    public int DepartmentId { get; set; }
    public string Role { get; set; }
}
