namespace RequestManagementSystem.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<UserCategory>? UserCategories { get; set; }
}
