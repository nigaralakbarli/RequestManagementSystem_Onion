using AutoMapper;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.DTOs.RequestStatus.Request;
using RequestManagementSystem.Application.DTOs.RequestStatus.Response;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;
using System.Net.Http.Headers;

namespace RequestManagementSystem.Application.Services;

public class RequestStatusService : IRequestStatusService
{
    private readonly IRequestStatusRepository _requestStatusRepository;
    private readonly IMapper _mapper;

    public RequestStatusService(
        IRequestStatusRepository requestStatusRepository,
        IMapper mapper)
    {
        _requestStatusRepository = requestStatusRepository;
        _mapper = mapper;
    }

    public bool CreateRequestStatus(RequestStatusRequestDTO requestStatusRequestDTO)
    {
        var requestStatus = _requestStatusRepository.Find(c => c.Name.Trim().ToUpper() == requestStatusRequestDTO.Name.TrimEnd().ToUpper());
        if(requestStatus != null)
        {
            var mapped = _mapper.Map<RequestStatus>(requestStatusRequestDTO);
            _requestStatusRepository.Add(mapped);
            return true;
        }
        return false;
    }

    public List<RequestStatusResponseDTO> GetRequestStatuses()
    {
        return _mapper.Map<List<RequestStatusResponseDTO>>(_requestStatusRepository.GetAll());
    }

    public RequestStatusResponseDTO GetRequestStatusById(int requestStatusId)
    {
        return _mapper.Map<RequestStatusResponseDTO>(_requestStatusRepository.GetById(requestStatusId));    
    }

    public bool DeleteRequestStatus(int requestStatusId)
    {
        var requestStatus = _requestStatusRepository.GetById(requestStatusId);
        if (requestStatus != null)
        {
            _requestStatusRepository.Remove(requestStatus);
            return true;
        }
        return false;
    }

    public bool UpdateRequestStatus(RequestStatusRequestDTO requestStatusRequestDTO)
    {
        var requestStatus = _requestStatusRepository.GetById(requestStatusRequestDTO.Id);
        if (requestStatus != null)
        {
            var mapped = _mapper.Map<RequestStatus>(requestStatusRequestDTO);
            _requestStatusRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
