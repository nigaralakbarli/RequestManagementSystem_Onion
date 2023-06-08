using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Request.Request;
using RequestManagementSystem.Application.DTOs.Request.Response;
using RequestManagementSystem.Application.DTOs.RequestDetail.Request;
using RequestManagementSystem.Application.DTOs.RequestDetail.Response;
using RequestManagementSystem.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RequestManagementSystem.Application.Interfaces;

public interface IRequestService
{
    List<RequestResponseDTO> GetRequests(int pageIndex, int pageSize);
    RequestResponseDTO GetRequestById(int requestId);
    Request GetRequestEntityById(int requestId);
    bool CreateRequest(RequestCreateDTO requestCreateDTO);
    bool UpdateRequest(RequestUpdateDTO requestUpdateDTO);
    bool DeleteRequest(int requestId);
    string UpdateRequestStatus(int requestId, int newStatusId);
    List<RequestHistoryDTO> GetHistory(int requestId);
    void UpdateDetails(RequestDetailUpdateDTO requestDetail);
    RequestDetailResponseDTO GetDetails(int requestId);
    byte[] DownloadFile(string filePath);
    Comment GetCommentById(int commentId);
    int GetCommentCount(int requestId);
    List<Request> Filter(RequestFilterDTO listRequest, List<Request> requestList);
    List<RequestResponseDTO> GetAllRequestsByCategory_StatusWithFilter(RequestFilterDTO requestFilterDTO);
    List<Request> GetAllRequestsByCategory(int? categoryId);
    List<RequestResponseDTO> GetMyRequestsByStatusWithFilter(int? statusId, RequestFilterDTO listRequest);
    List<Request> GetMyRequestsByStatus();
    List<RequestStatusCountDTO> GetStatusCountForCategory(int categoryId);
    List<RequestStatusCountDTO> GetMyRequestsStatusCount();
    bool IsValideStatus(int currentStatusId, int newStatusId);
}
