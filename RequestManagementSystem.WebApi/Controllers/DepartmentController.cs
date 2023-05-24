using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Application.Services;
using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [Route("/GetAll")]
        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_departmentService.GetDepartments());
        }

        [Route("/GetById")]
        [HttpGet]
        public IActionResult GetDepartmentById(int departmentId)
        {
            return Ok(_departmentService.GetDepartmentById(departmentId));
        }

        [Route("/Create")]
        [HttpPost]
        public IActionResult CreateDepartment(DepartmentRequestDTO departmentRequestDTO)
        {
            if (!_departmentService.CreateDepartment(departmentRequestDTO))
            {
                return BadRequest();
            }
            return Ok("Successfully created");
        }

        [Route("/Update")]
        [HttpPut]
        public IActionResult UpdateDepartment(DepartmentRequestDTO departmentRequestDTO)
        {
            if (_departmentService.UpdateDepartment(departmentRequestDTO))
            {
                return Ok("Successfully updated");
            }
            return NotFound();
        }

        [Route("/Delete")]
        [HttpDelete]
        public IActionResult DeleteDepartment(int departmentId)
        {
            if (_departmentService.DeleteDepartment(departmentId))
            {
                return Ok("Successfully deleted");
            }
            return NotFound();
        }
    }
}
