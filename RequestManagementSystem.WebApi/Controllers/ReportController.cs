using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Application.DTOs.Report.Request;
using RequestManagementSystem.Application.DTOs.Report.Response;
using RequestManagementSystem.Application.Interfaces;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(
            IReportService reportService)
        {
            _reportService = reportService;
        }

        [Route("/GetReports")]
        [HttpGet]
        public IActionResult GetReports(int pageIndex = 1, int pageSize = 2)
        {
            return Ok(_reportService.GetAll(pageIndex, pageSize));
        }

        [Route("/GetReportsByDateRange")]
        [HttpGet]
        public IActionResult GetReportsByDateRange(DateTime startDate, DateTime endDate)
        {
            return Ok(_reportService.GetByDateRange(startDate, endDate));
        }

        [Route("GetReportsByFilter")]
        [HttpPost]
        public IActionResult GetReportsByFilter([FromBody] ReportFilterDTO reportFilterDTO)
        {
            return Ok(_reportService.GetFiltered(reportFilterDTO));
        }

        [Route("/excel")]
        [HttpPost]
        public IActionResult DownloadReports([FromBody] ReportFilterDTO reportFilterDTO)
        {
            var filteredReports = _reportService.GetFiltered(reportFilterDTO);
            var allReports = _reportService.GetAll().ToList();
            byte[] excelFile = default(byte[]);
            if (reportFilterDTO == null)
            {
                excelFile = _reportService.GenerateExcelFile(filteredReports);
            }
            else
            {
                excelFile = _reportService.GenerateExcelFile(allReports);
            }

            // Write Excel file to disk
            var filePath = Path.Combine(Path.GetTempPath(), "Reports.xlsx");
            System.IO.File.WriteAllBytes(filePath, excelFile);

            // Return file as download
            var fileStream = new FileStream(filePath, FileMode.Open);
            var fileStreamResult = new FileStreamResult(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            fileStreamResult.FileDownloadName = "Reports.xlsx";

            return fileStreamResult;
        }
    }
}
