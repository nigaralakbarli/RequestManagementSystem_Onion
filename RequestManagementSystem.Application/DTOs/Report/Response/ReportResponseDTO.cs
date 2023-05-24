namespace RequestManagementSystem.Application.DTOs.Report.Response;

public class ReportResponseDTO
{
    public int RequestId { get; set; }
    public string CreateUser { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime InitialExecutionDate { get; set; }
    public TimeSpan ExecutionTime { get; set; }
    public string ExecutorUser { get; set; }
    public DateTime ClosedAt { get; set; }
    public string Status { get; set; }
}
