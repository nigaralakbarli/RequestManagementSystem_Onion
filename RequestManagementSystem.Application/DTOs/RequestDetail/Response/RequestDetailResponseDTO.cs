namespace RequestManagementSystem.Application.DTOs.RequestDetail.Response;

public class RequestDetailResponseDTO
{
    public int PriorityId { get; set; }
    public int CategoryId { get; set; }
    public string Result { get; set; }
    public string Solution { get; set; }
    public double ExecutionTime { get; set; }
    public double PlannedExecutionTime { get; set; }
    public int DetailTypeId { get; set; }
    public string UserName { get; set; }
    public string SolmanRequestNumber { get; set; }
    public int ContactMethodId { get; set; }
    public bool Routine { get; set; }
    public string Code { get; set; }
    public string RootCause { get; set; }
}
