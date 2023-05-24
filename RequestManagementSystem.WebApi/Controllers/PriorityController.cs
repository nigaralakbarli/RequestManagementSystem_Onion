using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Priority.Request;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Application.Services;
using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityService _priorityService;

        public PriorityController(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }


        [Route("/GetAll")]
        [HttpGet]
        public IActionResult GetPriorities()
        {
            return Ok(_priorityService.GetPriorities());
        }

        [Route("/GetById")]
        [HttpGet]
        public IActionResult GetPriorityById(int priorityId)
        {
            return Ok(_priorityService.GetPriorityById(priorityId));
        }

        [Route("/Create")]
        [HttpPost]
        public IActionResult CreatePriority(PriorityRequestDTO priorityRequestDTO)
        {
            if (!_priorityService.CreatePriority(priorityRequestDTO))
            {
                return BadRequest();
            }
            return Ok("Successfully created");
        }

        [Route("/Update")]
        [HttpPut]
        public IActionResult UpdatePriority(PriorityRequestDTO priorityRequestDTO)
        {
            if (_priorityService.UpdatePriority(priorityRequestDTO))
            {
                return Ok("Successfully updated");
            }
            return NotFound();
        }

        [Route("/Delete")]
        [HttpDelete]
        public IActionResult DeletePriority(int priorityId)
        {
            if (_priorityService.DeletePriority(priorityId))
            {
                return Ok("Successfully deleted");
            }
            return NotFound();
        }
    }
}
