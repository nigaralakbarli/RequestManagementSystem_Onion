using RequestManagementSystem.Application.DTOs.Priority.Request;
using RequestManagementSystem.Application.DTOs.Priority.Response;

namespace RequestManagementSystem.Application.Interfaces;

public interface IPriorityService
{
    List<PriorityResponseDTO> GetPriorities();
    PriorityResponseDTO GetPriorityById(int priorityId);
    bool CreatePriority(PriorityRequestDTO priorityRequestDTO);
    bool DeletePriority(int priorityId);
    bool UpdatePriority(PriorityRequestDTO priorityRequestDTO);
}
