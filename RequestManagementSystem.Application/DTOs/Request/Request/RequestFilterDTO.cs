namespace RequestManagementSystem.Application.DTOs.Request.Request;

public class RequestFilterDTO
{
    public int pageIndex { get; set; } = 1;
    public int pageSize { get; set; } = 10;
    public int? CategoryId { get; set; }
    public int? StatusId { get; set; }
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? CreateUser { get; set; }
    public string? ExecutorUser { get; set; }
    public string? RequestStatus { get; set; }
    public string? CreateAt { get; set; }
}
