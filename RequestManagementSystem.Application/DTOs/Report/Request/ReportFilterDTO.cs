namespace RequestManagementSystem.Application.DTOs.Report.Request;

public class ReportFilterDTO
{
    public int pageIndex { get; set; } = 1;
    public int pageSize { get; set; } = 2;
    public string? RequestId { get; set; }
    public string? CreateUser { get; set; }
    public string? Category { get; set; }
    public string? CreatedAt { get; set; }
    public string? InitialExecutionDate { get; set; }
    public string? ExecutionTime { get; set; }
    public string? ExecutorUser { get; set; }
    public string? ClosedAt { get; set; }
    public string? Status { get; set; }
}
