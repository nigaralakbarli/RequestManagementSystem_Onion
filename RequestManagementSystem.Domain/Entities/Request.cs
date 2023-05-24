using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestManagementSystem.Domain.Entities;

public class Request : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

    [NotMapped]
    public IFormFile? FileUpload { get; set; }
    public string? FileUploadPath { get; set; }

    public int CreateUserId { get; set; }
    public int? ExecutorUserId { get; set; }
    public int CategoryId { get; set; }
    public int RequestTypeId { get; set; }
    public int RequestStatusId { get; set; }
    public int PriorityId { get; set; }


    #region Navigation Properties
    public virtual User CreateUser { get; set; }
    public virtual Priority Priority { get; set; }
    public virtual Category Category { get; set; }
    public virtual User? ExecutorUser { get; set; }
    public virtual RequestStatus RequestStatus { get; set; }
    public virtual RequestType RequestType { get; set; }
    public virtual Report Report { get; set; }
    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual RequestDetail? RequestDetail { get; set; }
    #endregion
}
