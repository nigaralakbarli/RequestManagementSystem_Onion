using AutoMapper;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Request.Request;
using RequestManagementSystem.Application.DTOs.Request.Response;
using RequestManagementSystem.Application.DTOs.RequestDetail.Request;
using RequestManagementSystem.Application.DTOs.RequestDetail.Response;
using RequestManagementSystem.Application.Helper.FileHelper;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RequestManagementSystem.Application.Services;

public class RequestService : IRequestService
{
    private readonly IRequestRepository _requestRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly IAuthService _authService;
    private readonly IUserCategoryRepository _userCategoryRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IRequestDetailRepository _requestDetailRepository;
    private readonly IActionRepository _actionRepository;
    private readonly IRequestStatusRepository _requestStatusRepository;

    public RequestService(
        IRequestRepository requestRepository,
        IMapper mapper,
        IFileService fileService,
        IAuthService authService,
        IUserCategoryRepository userCategoryRepository,
        ICommentRepository commentRepository,
        IRequestDetailRepository requestDetailRepository,
        IActionRepository actionRepository,
        IRequestStatusRepository requestStatusRepository)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
        _fileService = fileService;
        _authService = authService;
        _userCategoryRepository = userCategoryRepository;
        _commentRepository = commentRepository;
        _requestDetailRepository = requestDetailRepository;
        _actionRepository = actionRepository;
        _requestStatusRepository = requestStatusRepository;
    }
    public bool CreateRequest(RequestCreateDTO requestCreateDTO)
    {

        var requestDto = _requestRepository
            .Find(c => c.Title.Trim().ToUpper() == requestCreateDTO.Title.TrimEnd().ToUpper());
        if (requestDto != null)
        {
            var request = _mapper.Map<Request>(requestCreateDTO);

            if (request.FileUpload != null && request.FileUpload.Length > 0)
            {
                request.FileUploadPath = _fileService.Upload(request.FileUpload, "Files");
            }
            request.RequestStatusId = 1; // set status to "open" 
            request.CreateUserId = _authService.GetCurrentUser().Id;
            _requestRepository.Add(request);

            var action = new Domain.Entities.Action
            {
                RequestStatusId = request.RequestStatusId,
                UserId = request.CreateUserId,
            };
            request.Actions.Add(action);
            return true;
        }
        return false;
    }
    public Request GetRequestEntityById(int requestId)
    {
        return _requestRepository.GetById(requestId);
    }
    public bool DeleteRequest(int requestId)
    {
        var request = _requestRepository.GetById(requestId);
        if (request != null)
        {
            _requestRepository.Remove(request);
            return true;
        }
        return false;
    }

    public byte[] DownloadFile(string filePath)
    {
        byte[] fileBytes = File.ReadAllBytes(filePath);
        return fileBytes;
    }

    public List<Request> Filter(RequestFilterDTO listRequest, List<Request> requestList)
    {
        var filters = new Dictionary<string, Func<List<Request>, string, List<Request>>>
                {
                    { "Id", (list, value) => list.Where(e => e.Id.ToString().Contains(value)).ToList() },
                    { "Category", (list, value) => list.Where(e => e.Category.Name.Trim().ToLower().Contains(value.Trim().ToLower())).ToList() },
                    { "Title", (list, value) => list.Where(e => e.Title.Trim().ToLower().Contains(value.Trim().ToLower())).ToList() },
                    { "Description", (list, value) => list.Where(e => e.Description.Trim().ToLower().Contains(value.Trim().ToLower())).ToList() },
                    { "CreateUser", (list, value) => list.Where(e => e.CreateUser.Name.Trim().ToLower().Contains(value.Trim().ToLower())).ToList() },
                    { "ExecutorUser", (list, value) => list.Where(e => e.ExecutorUser.Name.Trim().ToLower().Contains(value.Trim().ToLower())).ToList() },
                    { "CreateAt", (list, value) => list.Where(e => e.CreatedAt.ToString().Trim().ToLower().Contains(value.Trim().ToLower())).ToList() },
                    { "RequestStatus", (list, value) => list.Where(e => e.RequestStatus.Name.Trim().ToLower().Contains(value.Trim().ToLower())).ToList() },
                };

        foreach (var kvp in filters)
        {
            var key = kvp.Key;
            var value = typeof(RequestFilterDTO).GetProperty(key)?.GetValue(listRequest)?.ToString();

            if (!string.IsNullOrEmpty(value))
            {
                requestList = kvp.Value(requestList, value);
            }
        }

        return requestList.Skip((listRequest.pageIndex - 1) * listRequest.pageSize)
                          .Take(listRequest.pageSize)
                          .ToList();
    }

    public List<Request> GetAllRequestsByCategory(int? categoryId)
    {
        var userId = _authService.GetCurrentUser().Id;
        var categories = _userCategoryRepository.Find(uc => uc.UserId == userId && (uc.IsCreatable == true || uc.IsExecutable == true)).Select(o => o.CategoryId).ToList();


        if (categoryId == 0)
        {
            return  _requestRepository.Find(r => categories.Contains(r.CategoryId)).OrderBy(r => r.Id).ToList();
            
        }
        else
        {
            return  _requestRepository.Find(r => r.CategoryId == categoryId && categories.Contains(r.CategoryId)).OrderBy(r => r.Id).ToList();
        }
    }

    public List<RequestResponseDTO> GetAllRequestsByCategory_StatusWithFilter(RequestFilterDTO listRequest)
    {
        var userId = _authService.GetCurrentUser().Id;
        var categories = _userCategoryRepository.Find(uc => uc.UserId == userId && (uc.IsCreatable == true || uc.IsExecutable == true)).Select(o => o.CategoryId).ToList();
        var requests = new List<Request>();

        if (listRequest.CategoryId == null && listRequest.StatusId == null)
        {
            requests = _requestRepository.Find(r => categories.Contains(r.CategoryId)).OrderBy(r => r.Id).ToList();
            var filtered = Filter(listRequest, requests);
            return _mapper.Map<List<RequestResponseDTO>>(filtered);
        }
        else
        {
            if (listRequest.StatusId == null)
            {
                requests = _requestRepository.Find(r => categories.Contains(r.CategoryId) && r.CategoryId == listRequest.CategoryId).OrderBy(r => r.Id).ToList();
                var filtered = Filter(listRequest, requests);
                return _mapper.Map<List<RequestResponseDTO>>(filtered);
            }

            else if (listRequest.CategoryId == null)
            {
                requests = _requestRepository.Find(r => categories.Contains(r.CategoryId) && r.RequestStatusId == listRequest.StatusId).OrderBy(r => r.Id).ToList();
                var filtered = Filter(listRequest, requests);
                return _mapper.Map<List<RequestResponseDTO>>(filtered);
            }
            else
            {
                requests = _requestRepository.Find(r => r.CategoryId == listRequest.CategoryId && r.RequestStatusId == listRequest.StatusId && categories.Contains(r.CategoryId)).OrderBy(r => r.Id).ToList();
                var filtered = Filter(listRequest, requests);
                return _mapper.Map<List<RequestResponseDTO>>(filtered);
            }
        }
    }

    public Comment GetCommentById(int commentId)
    {
        return _commentRepository.Find(c => c.Id == commentId).FirstOrDefault();
    }

    public int GetCommentCount(int requestId)
    {
        return _commentRepository.Find(c => c.RequestId == requestId).ToList().Count();
    }

    public RequestDetailResponseDTO GetDetails(int requestId)
    {
        var detail = _requestDetailRepository.Find(d => d.RequestId == requestId).FirstOrDefault();
        return _mapper.Map<RequestDetailResponseDTO>(detail);
    }

    public List<RequestHistoryDTO> GetHistory(int requestId)
    {
        var actions = _actionRepository.Find(a => a.RequestId == requestId).ToList();
        return _mapper.Map<List<RequestHistoryDTO>>(actions);
    }

    public List<Request> GetMyRequestsByStatus()
    {
        var userId = _authService.GetCurrentUser().Id;
        var categories = _userCategoryRepository.Find(uc => uc.UserId == userId && (uc.IsExecutable == true || uc.IsCreatable == true)).Select(o => o.CategoryId).ToList();
        return _requestRepository.Find(r => (r.CreateUserId == userId || r.ExecutorUserId == userId) && categories.Contains(r.CategoryId)).OrderBy(r => r.Id).ToList();
    }

    public List<RequestResponseDTO> GetMyRequestsByStatusWithFilter(int? statusId, RequestFilterDTO listRequest)
    {
        var userId = _authService.GetCurrentUser().Id;
        var categories = _userCategoryRepository.Find(uc => uc.UserId == userId && (uc.IsExecutable == true || uc.IsCreatable == true)).Select(o => o.CategoryId).ToList();
        var requests = new List<Request>();

        if (statusId == null)
        {
            requests = _requestRepository.Find(r => (r.CreateUserId == userId || r.ExecutorUserId == userId) && categories.Contains(r.CategoryId)).OrderBy(r => r.Id).ToList();
            var filtered =  Filter(listRequest,requests);
            return _mapper.Map<List<RequestResponseDTO>>(filtered);

        }
        else
        {
            if (statusId == 1)
            {
                var categoriesForOpen = _userCategoryRepository.Find(uc => uc.UserId == userId && uc.IsExecutable == true).Select(o => o.CategoryId).ToList();
                requests = _requestRepository.Find(r => r.RequestStatusId == statusId && (categoriesForOpen.Contains(r.CategoryId) || r.CreateUserId == userId)).OrderBy(r => r.Id).ToList();
                var filtered = Filter(listRequest, requests);
                return _mapper.Map<List<RequestResponseDTO>>(filtered);

            }
            else
            {
                requests = _requestRepository.Find(r => r.ExecutorUserId == userId && r.RequestStatusId == statusId).OrderBy(r => r.Id).ToList();
                var filtered = Filter(listRequest, requests);
                return _mapper.Map<List<RequestResponseDTO>>(filtered);
            }

        }
    }

    public List<RequestStatusCountDTO> GetMyRequestsStatusCount()
    {
        var requests = GetMyRequestsByStatus();
        var statuses = _requestStatusRepository.GetAll().Select(s => new RequestStatusCountDTO { Status = s.Name, Count = 0 }).ToList();
        if (requests.Any())
        {
            var groupedRequests = requests.GroupBy(r => r.RequestStatus.Name);
            foreach (var group in groupedRequests)
            {
                var status = statuses.FirstOrDefault(s => s.Status == group.Key);
                if (status != null)
                {
                    status.Count = group.Count();
                }
            }
        }
        return statuses;
    }

    public RequestResponseDTO GetRequestById(int requestId)
    {
        return _mapper.Map<RequestResponseDTO>(_requestRepository.GetById(requestId));
    }

    public List<RequestResponseDTO> GetRequests(int pageIndex, int pageSize)
    {
        var requests = _requestRepository.GetAll().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return _mapper.Map<List<RequestResponseDTO>>(requests);
    }

    public List<RequestStatusCountDTO> GetStatusCountForCategory(int categoryId)
    {
        var requests = GetAllRequestsByCategory(categoryId);

        var statuses = _requestStatusRepository.GetAll().Select(s => new RequestStatusCountDTO { Status = s.Name, Count = 0 }).ToList();
        if (requests.Any())
        {
            var groupedRequests = requests.GroupBy(r => r.RequestStatus.Name);
            foreach (var group in groupedRequests)
            {
                var status = statuses.FirstOrDefault(s => s.Status == group.Key);
                if (status != null)
                {
                    status.Count = group.Count();
                }
            }
        }
        return statuses;
    }

    public void UpdateDetails(RequestDetailUpdateDTO requestDetail)
    {
        var detail = _mapper.Map<RequestDetail>(requestDetail);
        _requestDetailRepository.Update(detail); 
    }

    public bool UpdateRequest(RequestUpdateDTO requestUpdateDTO)
    {
        var request = _requestRepository.GetById(requestUpdateDTO.Id);
        if (request != null)
        {
            var mapped = _mapper.Map<Request>(requestUpdateDTO);
            _requestRepository.Update(mapped);
            return true;
        }
        return false;
    }

    public bool UpdateRequestStatus(int requestId, int newStatusId)
    {
        var request = _requestRepository.GetById(requestId);
        if (request == null)
        {
            throw new ArgumentException("Invalid request ID");
        }

        if (newStatusId == 2)
        {
            request.ExecutorUserId = _authService.GetCurrentUser().Id;

        }

        request.RequestStatusId = newStatusId;

        var newAction = new Domain.Entities.Action
        {
            RequestId = requestId,
            UserId = request.ExecutorUserId,
            RequestStatusId = newStatusId
        };

        request.Actions.Add(newAction);
        return true;
    }
}
