namespace RequestManagementSystem.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; }
    public bool IsActive { get; set; }
    public DateTime Expires { get; set; }
    //public DateTime CreateTime { get; set; } = DateTime.UtcNow; // FromBase
    public int UserId { get; set; }
    public virtual User User { get; set; }
}
