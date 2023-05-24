using AutoMapper;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.DTOs.RequestType.Request;
using RequestManagementSystem.Application.DTOs.RequestType.Response;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;

namespace RequestManagementSystem.Application.Services;

public class RequestTypeService : IRequestTypeService
{
    private readonly IRequestTypeRepository _requestTypeRepository;
    private readonly IMapper _mapper;

    public RequestTypeService(
        IRequestTypeRepository requestTypeRepository,
        IMapper mapper)
    {
        _requestTypeRepository = requestTypeRepository;
        _mapper = mapper;
    }

    public bool CreateRequestType(RequestTypeRequestDTO requestTypeRequestDTO)
    {
        var requestType = _requestTypeRepository.Find(c => c.Name.Trim().ToUpper() == requestTypeRequestDTO.Name.TrimEnd().ToUpper());
        if(requestType != null)
        {
            var mapped = _mapper.Map<RequestType>(requestTypeRequestDTO);
            _requestTypeRepository.Add(mapped);
            return true;
        }
        return false;
    }

    public List<RequestTypeResponseDTO> GetRequestTypes()
    {
        return _mapper.Map<List<RequestTypeResponseDTO>>(_requestTypeRepository.GetAll());  
    }

    public RequestTypeResponseDTO GetRequestTypeById(int requestTypeId)
    {
        return _mapper.Map<RequestTypeResponseDTO>(_requestTypeRepository.GetById(requestTypeId));
    }

    public bool DeleteRequestType(int requestTypeId)
    {
        var requestType = _requestTypeRepository.GetById(requestTypeId);
        if (requestType != null)
        {
            _requestTypeRepository.Remove(requestType);
            return true;
        }
        return false;
    }

    public bool UpdateRequestType(RequestTypeRequestDTO requestTypeRequestDTO)
    {
        var requestType = _requestTypeRepository.GetById(requestTypeRequestDTO.Id);
        if (requestType != null)
        {
            var mapped = _mapper.Map<RequestType>(requestTypeRequestDTO);
            _requestTypeRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
