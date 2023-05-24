namespace RequestManagementSystem.Application.DTOs.User.Request;

public class UserCategoryCreateDTO
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public bool IsCreatable { get; set; }
    public bool IsExecutable { get; set; }
}
