using RequestManagementSystem.Application.DTOs.Report.Request;
using RequestManagementSystem.Application.DTOs.Report.Response;
using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.Application.Interfaces;

public interface IReportService
{
    void Create(int requestId);
    List<ReportResponseDTO> GetAll(int pageIndex, int pageSize);
    List<ReportResponseDTO> GetAll();
    List<ReportResponseDTO> GetFiltered(ReportFilterDTO listReport);
    List<ReportResponseDTO> GetByDateRange(DateTime startDate, DateTime endDate);
    byte[] GenerateExcelFile(List<ReportResponseDTO> reports);
}
