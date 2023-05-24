using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestManagementSystem.Domain.Entities;

public class User : BaseEntity
{
    public string? Name { get; set; }
    public string? InternalNumber { get; set; }
    public string? ContactNumber { get; set; }
    public string? Password { get; set; }

    [NotMapped]
    public IFormFile? Image { get; set; }
    public string? ImagePath { get; set; }

    public bool? AllowNotification { get; set; } = true;
    public string? Position { get; set; }
    public string Role { get; set; }
    public int? DepartmentId { get; set; }


    public virtual ICollection<Request> CreatedRequests { get; set; }
    public virtual ICollection<Request> ExecutedRequests { get; set; }
    public virtual Department Department { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<UserCategory>? UserCategories { get; set; }
}
