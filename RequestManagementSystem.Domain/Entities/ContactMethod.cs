namespace RequestManagementSystem.Domain.Entities;

public class ContactMethod : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<RequestDetail> RequestDetails { get; set; }
}
