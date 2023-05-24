namespace RequestManagementSystem.Domain.Entities;

public class DetailType : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<RequestDetail> RequestDetails { get; set; }
}
