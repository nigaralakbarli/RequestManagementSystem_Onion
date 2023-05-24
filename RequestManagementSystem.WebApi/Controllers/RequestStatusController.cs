using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.RequestStatus.Request;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Application.Services;
using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("RequestStatus")]
    [ApiController]
    public class RequestStatusController : ControllerBase
    {
        private readonly IRequestStatusService _requestStatusService;

        public RequestStatusController(IRequestStatusService requestStatusService)
        {
            _requestStatusService = requestStatusService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetRequestStatuses()
        {
            return Ok(_requestStatusService.GetRequestStatuses());
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetRequestStatusById(int requestStatusId)
        {
            return Ok(_requestStatusService.GetRequestStatusById(requestStatusId));
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult CreateRequestStatus(RequestStatusRequestDTO requestStatusRequestDTO)
        {
            if (!_requestStatusService.CreateRequestStatus(requestStatusRequestDTO))
            {
                return BadRequest();
            }
            return Ok("Successfully created");
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult UpdateRequestStatus(RequestStatusRequestDTO requestStatusRequestDTO)
        {
            if (_requestStatusService.UpdateRequestStatus(requestStatusRequestDTO))
            {
                return Ok("Successfully updated");
            }
            return NotFound();
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteRequestStatus(int requestStatusId)
        {
            if (_requestStatusService.DeleteRequestStatus(requestStatusId))
            {
                return Ok("Successfully deleted");
            }
            return NotFound();
        }
    }
}
