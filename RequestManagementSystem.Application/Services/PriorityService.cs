using AutoMapper;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.DTOs.Priority.Request;
using RequestManagementSystem.Application.DTOs.Priority.Response;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;

namespace RequestManagementSystem.Application.Services;

public class PriorityService : IPriorityService
{
    private readonly IPriorityRepository _priorityRepository;
    private readonly IMapper _mapper;

    public PriorityService(
        IPriorityRepository priorityRepository,
        IMapper mapper)
    {
        _priorityRepository = priorityRepository;
        _mapper = mapper;
    }

    public bool CreatePriority(PriorityRequestDTO priorityRequestDTO)
    {
        var priority = _priorityRepository.
            Find(c => c.Level.Trim().ToUpper() == priorityRequestDTO.Level.TrimEnd().ToUpper());
        if (priority != null)
        {
            var mapped = _mapper.Map<Priority>(priorityRequestDTO);
            _priorityRepository.Add(mapped);
            return true;
        }
        return false;
    }
    public List<PriorityResponseDTO> GetPriorities()
    {
        return _mapper.Map<List<PriorityResponseDTO>>(_priorityRepository.GetAll());
    }
    public PriorityResponseDTO GetPriorityById(int priorityId)
    {
        return _mapper.Map<PriorityResponseDTO>(_priorityRepository.GetById(priorityId));
    }
    public bool DeletePriority(int priorityId)
    {
        var priority = _priorityRepository.GetById(priorityId);
        if(priority != null)
        {
            _priorityRepository.Remove(priority);
            return true;
        }
        return false;
    }
    public bool UpdatePriority(PriorityRequestDTO priorityRequestDTO)
    {
        var priority = _priorityRepository.GetById(priorityRequestDTO.Id);
        if (priority != null)
        {
            var mapped = _mapper.Map<Priority>(priorityRequestDTO);
            _priorityRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
