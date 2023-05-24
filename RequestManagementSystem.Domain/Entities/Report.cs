namespace RequestManagementSystem.Domain.Entities;

public class Report : BaseEntity
{
    public virtual Request Request { get; set; }
    public int RequestId { get; set; }
    public int CreateUserId { get; set; }
    public int CategoryId { get; set; }
    //public DateTime CreatedAt { get; set; } //service
    public DateTime InitialExecutionDate { get; set; }
    public TimeSpan ExecutionTime { get; set; }
    public int? ExecutorUserId { get; set; }
    public DateTime ClosedAt { get; set; }
    public int RequestStatusId { get; set; }
}
