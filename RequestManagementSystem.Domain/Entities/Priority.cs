namespace RequestManagementSystem.Domain.Entities;

public class Priority : BaseEntity
{
    public string Level { get; set; } = null!;
    public virtual ICollection<Request> Requests { get; set; }
}
