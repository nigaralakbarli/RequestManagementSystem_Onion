using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Comment.Request;
using RequestManagementSystem.Application.DTOs.Comment.Response;
using RequestManagementSystem.Application.DTOs.Request.Request;
using RequestManagementSystem.Application.DTOs.Request.Response;
using RequestManagementSystem.Application.DTOs.RequestDetail.Request;
using RequestManagementSystem.Application.DTOs.RequestDetail.Response;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly ICommentService _commentService;
        private readonly IReportService _reportService;

        public RequestController(
            IRequestService requestService,
            ICommentService commentService,
            IReportService reportService)
        {
            _requestService = requestService;
            _commentService = commentService;
            _reportService = reportService;
        }

        [Route("/GetAll")]
        [HttpGet]
        public IActionResult GetRequests(int pageIndex = 1, int pageSize = 2)
        {
            return Ok(_requestService.GetRequests(pageIndex, pageSize));
        }

        [Route("/Create")]
        [HttpPost]
        public IActionResult CreateRequest([FromForm][Required] RequestCreateDTO requestCreate)
        {
           if(!_requestService.CreateRequest(requestCreate))
           {
                return BadRequest("Request already exist");
           }
           return Ok("Successfully created");
        }


        [Route("/Update")]
        [HttpPut]
        public IActionResult UpdateRequest(int requestId, [FromBody] RequestUpdateDTO requestUpdateDTO)
        {
            if (_requestService.UpdateRequest(requestUpdateDTO))
            {
                return Ok();
            }
            return NotFound();
        }

        [Route("/ChangeStatus")]
        [HttpPut]
        public IActionResult ChangeStatus([FromQuery] RequestChangeStatusDTO requestChangeStatusDTO)
        {
            if(!_requestService.UpdateRequestStatus(requestChangeStatusDTO.RequestId, requestChangeStatusDTO.RequestStatusId))
            {
                return NotFound();
            }
            if (requestChangeStatusDTO.RequestStatusId == 6)
            {
                _reportService.Create(requestChangeStatusDTO.RequestId);
            }
            return NoContent();
        }

        [Route("/Delete")]
        [HttpDelete]
        public IActionResult DeleteRequest(int requestId)
        {

            if (!_requestService.DeleteRequest(requestId))
            {
                return Ok();
            }
            return NotFound();
        }


        [Route("/History")]
        [HttpGet]
        public IActionResult GetRequestHistory(int requestId)
        {
            return Ok(_requestService.GetHistory(requestId));
        }

        [Route("/AddComment")]
        [HttpPost]
        public IActionResult AddComment([FromForm] CommentRequestDTO comment)
        {
            _commentService.Create(comment);
            return Ok();
        }

        [Route("/CommentCount")]
        [HttpGet]
        public IActionResult GetCommentCount(int requestId)
        {
            var count = _requestService.GetCommentCount(requestId);
            return Ok(count);
        }

        [Route("/LastComment")]
        [HttpGet]
        public IActionResult GetLast(int requestId)
        {
            return Ok(_commentService.GetLast(requestId));
        }

        [Route("/UpdateDetail")]
        [HttpPut]
        public IActionResult UpdateDetail([FromForm] RequestDetailUpdateDTO detail)
        {
            _requestService.UpdateDetails(detail);
            return Ok();
        }

        [Route("/GetDetail")]
        [HttpGet]
        public IActionResult GetDetail(int requestId)
        {
            return Ok(_requestService.GetDetails(requestId));
        }

        [Route("/DownloadRequestFile")]
        [HttpGet]
        public IActionResult DownloadRequestFile(int requestDd)
        {
            // Get the entity with the specified id from your data store
            var request = _requestService.GetRequestEntityById(requestDd);

            if (request == null)
            {
                return NotFound();
            }

            // Download the file using the file path property in the entity
            byte[] fileBytes = _requestService.DownloadFile(request.FileUploadPath);

            // Return the file as a file download
            return File(fileBytes, "application/octet-stream", Path.GetFileName(request.FileUploadPath));
        }

        [Route("/DownloadCommentFile")]
        [HttpGet]
        public IActionResult DownloadCommentFile(int commentid)
        {
            // Get the entity with the specified id from your data store
            var commentFilePath = _requestService.GetCommentById(commentid).FileUploadPath;


            if (commentFilePath.IsNullOrEmpty())
            {
                return NotFound();
            }

            // Download the file using the file path property in the entity
            byte[] fileBytes = _requestService.DownloadFile(commentFilePath);

            // Return the file as a file download
            return File(fileBytes, "application/octet-stream", Path.GetFileName(commentFilePath));
        }

        //[Route("/AllRequestsStatusCount")]
        [HttpGet]
        public List<RequestStatusCountDTO> GetAllRequestsStatusCount([FromQuery] int categoryId)
        {
            return _requestService.GetStatusCountForCategory(categoryId);
        }

        [Route("MyRequestsStatusCount")]
        [HttpGet]
        public List<RequestStatusCountDTO> GetMyRequestsStatusCount()
        {
            return _requestService.GetMyRequestsStatusCount();
        }

        [Route("/AllRequestByCategory_Status")]
        [HttpGet]
        public IActionResult AllRequestByCategory_Status([FromBody] RequestFilterDTO requestFilterDTO)
        {
           return Ok(_requestService.GetAllRequestsByCategory_StatusWithFilter(requestFilterDTO));

        }

        //[Route("/MyRequestByStatus")]
        [HttpPost]
        public IActionResult MyRequestByStatus(int? statusId, [FromQuery] RequestFilterDTO requestFilterDTO)
        {
            return Ok (_requestService.GetMyRequestsByStatusWithFilter(statusId, requestFilterDTO));
        }

    }
}
