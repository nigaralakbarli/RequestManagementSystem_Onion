using Microsoft.AspNetCore.Http;

namespace RequestManagementSystem.Application.DTOs.Comment.Request;

public class CommentRequestDTO
{
    public int RequestId { get; set; }
    public string Text { get; set; }
    public IFormFile? FileUpload { get; set; }
}
