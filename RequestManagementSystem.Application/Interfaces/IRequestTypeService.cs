using RequestManagementSystem.Application.DTOs.Priority.Request;
using RequestManagementSystem.Application.DTOs.RequestType.Request;
using RequestManagementSystem.Application.DTOs.RequestType.Response;

namespace RequestManagementSystem.Application.Interfaces;

public interface IRequestTypeService
{
    List<RequestTypeResponseDTO> GetRequestTypes();
    RequestTypeResponseDTO GetRequestTypeById(int requestTypeId);
    bool CreateRequestType(RequestTypeRequestDTO requestTypeRequestDTO);
    bool DeleteRequestType(int requestTypeId);
    bool UpdateRequestType(RequestTypeRequestDTO requestTypeRequestDTO);    

}
