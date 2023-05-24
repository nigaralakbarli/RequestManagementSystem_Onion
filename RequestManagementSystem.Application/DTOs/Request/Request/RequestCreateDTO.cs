using Microsoft.AspNetCore.Http;

namespace RequestManagementSystem.Application.DTOs.Request.Request;

public class RequestCreateDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile? FileUpload { get; set; }
    public int CategoryId { get; set; }
    public int RequestTypeId { get; set; }
    public int PriorityId { get; set; }
}
