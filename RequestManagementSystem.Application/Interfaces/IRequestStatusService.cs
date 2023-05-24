using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.RequestStatus.Request;
using RequestManagementSystem.Application.DTOs.RequestStatus.Response;

namespace RequestManagementSystem.Application.Interfaces;

public interface IRequestStatusService
{
    List<RequestStatusResponseDTO> GetRequestStatuses();
    RequestStatusResponseDTO GetRequestStatusById(int requestStatusId);
    bool CreateRequestStatus(RequestStatusRequestDTO requestStatusRequestDTO);
    bool UpdateRequestStatus(RequestStatusRequestDTO requestStatusRequestDTO);
    bool DeleteRequestStatus(int requestStatusId);
}
