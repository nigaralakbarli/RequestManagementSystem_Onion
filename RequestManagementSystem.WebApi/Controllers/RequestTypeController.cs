using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.RequestType.Request;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Application.Services;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypeController : ControllerBase
    {
        private readonly IRequestTypeService _requestTypeService;

        public RequestTypeController(IRequestTypeService requestTypeService)
        {
            _requestTypeService = requestTypeService;
        }

        [Route("/GetAll")]
        [HttpGet]
        public IActionResult GetRequestTypes()
        {
            return Ok(_requestTypeService.GetRequestTypes());
        }

        [Route("/GetById")]
        [HttpGet]
        public IActionResult GetRequestTypeById(int requestTypeId)
        {
            return Ok(_requestTypeService.GetRequestTypeById(requestTypeId));
        }

        [Route("/Create")]
        [HttpPost]
        public IActionResult CreateRequestType(RequestTypeRequestDTO requestTypeRequestDTO)
        {
            if (!_requestTypeService.CreateRequestType(requestTypeRequestDTO))
            {
                return BadRequest();
            }
            return Ok("Successfully created");
        }

        [Route("/Update")]
        [HttpPut]
        public IActionResult UpdateRequestType(RequestTypeRequestDTO requestTypeRequestDTO)
        {
            if (_requestTypeService.UpdateRequestType(requestTypeRequestDTO))
            {
                return Ok("Successfully updated");
            }
            return NotFound();
        }

        [Route("/Delete")]
        [HttpDelete]
        public IActionResult DeleteRequestType(int requestTypeId)
        {
            if (_requestTypeService.DeleteRequestType(requestTypeId))
            {
                return Ok("Successfully deleted");
            }
            return NotFound();
        }
    }
}
