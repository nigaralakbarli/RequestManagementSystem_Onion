namespace RequestManagementSystem.Application.DTOs.UserCtegory.Response;

public class UserCategoryResponseDTO
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public bool IsCreatable { get; set; }
    public bool IsExecutable { get; set; }
}
