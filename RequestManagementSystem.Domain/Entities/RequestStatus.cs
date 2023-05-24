namespace RequestManagementSystem.Domain.Entities;

public class RequestStatus : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<Action> Actions { get; set; }
}
