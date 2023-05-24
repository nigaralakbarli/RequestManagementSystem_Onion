using Microsoft.AspNetCore.Http;

namespace RequestManagementSystem.Application.DTOs.User.Request;

public class UserUpdateDTO
{
    public int Id { get; set; }
    public string? InternalNumber { get; set; }
    public string? ContactNumber { get; set; }
    public string? Password { get; set; }
    public IFormFile? Image { get; set; }
    public bool? AllowNotification { get; set; }
    public string? Position { get; set; }
    public int? DepartmentId { get; set; }
}
