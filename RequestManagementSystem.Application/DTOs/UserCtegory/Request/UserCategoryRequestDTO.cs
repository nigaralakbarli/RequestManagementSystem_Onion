namespace RequestManagementSystem.Application.DTOs.UserCtegory.Request;

public class UserCategoryRequestDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public bool IsCreatable { get; set; }
    public bool IsExecutable { get; set; }
}
