using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.DTOs.Department.Response;

namespace RequestManagementSystem.Application.Interfaces;

public interface IDepartmentService
{
    List<DepartmentResponseDTO> GetDepartments();
    DepartmentResponseDTO GetDepartmentById(int departmentId);
    bool CreateDepartment(DepartmentRequestDTO departmentRequestDTO);
    bool UpdateDepartment(DepartmentRequestDTO departmentRequestDTO);
    bool DeleteDepartment(int departmentId);

}
