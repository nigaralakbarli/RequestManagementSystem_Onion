namespace RequestManagementSystem.Domain.Entities;

public class RequestDetail : BaseEntity
{
    public int PriorityId { get; set; }
    public int CategoryId { get; set; }
    public string Result { get; set; }
    public string Solution { get; set; }
    public double ExecutionTime { get; set; }
    public double PlannedExecutionTime { get; set; }
    public int DetailTypeId { get; set; }
    public virtual DetailType? DetailType { get; set; }
    public string UserName { get; set; }
    public string SolmanRequestNumber { get; set; }
    public int ContactMethodId { get; set; }
    public virtual ContactMethod? ContactMethod { get; set; }
    public bool Routine { get; set; }
    public string Code { get; set; }
    public string RootCause { get; set; }


    public virtual Request Request { get; set; }
    public int RequestId { get; set; }
}
