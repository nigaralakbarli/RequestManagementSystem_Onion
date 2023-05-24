namespace RequestManagementSystem.Domain.Entities;

public class UserCategory : BaseEntity
{
    public virtual User User { get; set; }
    public int UserId { get; set; }
    public virtual Category Category { get; set; }
    public int CategoryId { get; set; }
    public bool IsCreatable { get; set; }
    public bool IsExecutable { get; set; }
}
