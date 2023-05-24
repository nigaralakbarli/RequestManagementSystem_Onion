namespace RequestManagementSystem.Domain.Entities;

public class RequestType : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
}
