using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestManagementSystem.Domain.Entities;

public class Comment : BaseEntity
{
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public string Text { get; set; } = string.Empty;
    [NotMapped]
    public IFormFile? FileUpload { get; set; }
    public string? FileUploadPath { get; set; }
    public DateTime Date { get; set; }



    #region Navigation Properties
    public virtual Request Request { get; set; }
    public virtual User User { get; set; }
    #endregion
}
