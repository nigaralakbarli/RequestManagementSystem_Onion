using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Domain.Entities;

public class Action : BaseEntity
{
    //public DateTime Date { get; set; }
    public int RequestId { get; set; }
    public int RequestStatusId { get; set; }
    public int? UserId { get; set; }


    #region Navigation Properties
    public virtual Request Request { get; set; }
    public virtual RequestStatus RequestStatus { get; set; }
    public virtual User User { get; set; }
    #endregion
}
