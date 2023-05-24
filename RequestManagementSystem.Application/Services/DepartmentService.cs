using AutoMapper;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.DTOs.Department.Response;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;

namespace RequestManagementSystem.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentService(
        IDepartmentRepository departmentRepository,
        IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public bool CreateDepartment(DepartmentRequestDTO departmentRequestDTO)
    {
        var department = _departmentRepository.Find(c => c.Name.Trim().ToUpper() == departmentRequestDTO.Name.TrimEnd().ToUpper());
        if(department != null)
        {
            var mapped = _mapper.Map<Department>(departmentRequestDTO);
            _departmentRepository.Add(mapped);
            return true;
        }
        return false;
    }

    public List<DepartmentResponseDTO> GetDepartments()
    {
        return _mapper.Map<List<DepartmentResponseDTO>>(_departmentRepository.GetAll());
    }

    public DepartmentResponseDTO GetDepartmentById(int departmentId)
    {
        return _mapper.Map<DepartmentResponseDTO>(_departmentRepository.GetById(departmentId));
    }

    public bool DeleteDepartment(int departmentId)
    {
        var department = _departmentRepository.GetById(departmentId);
        if (department != null)
        {
            _departmentRepository.Remove(department);
            return true;
        }
        return false;
    }

    public bool UpdateDepartment(DepartmentRequestDTO departmentRequestDTO)
    {
        var department = _departmentRepository.GetById(departmentRequestDTO.Id);
        if (department != null)
        {
            var mapped = _mapper.Map<Department>(departmentRequestDTO);
            _departmentRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
