using AutoMapper;
using OfficeOpenXml;
using RequestManagementSystem.Application.DTOs.Report.Request;
using RequestManagementSystem.Application.DTOs.Report.Response;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;
using System.Drawing.Printing;
using System.Linq;

namespace RequestManagementSystem.Application.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly IActionRepository _actionRepository;
    private readonly IRequestRepository _requestRepository;
    private readonly IMapper _mapper;

    public ReportService(
        IReportRepository reportRepository,
        IActionRepository actionRepository,
        IRequestRepository requestRepository,
        IMapper mapper)
    {
        _reportRepository = reportRepository;
        _actionRepository = actionRepository;
        _requestRepository = requestRepository;
        _mapper = mapper;
    }
    public void Create(int requestId)
    {
        var request = _requestRepository.GetById(requestId);
        var fistExecution = _actionRepository.Find(r => r.RequestId == request.Id && r.RequestStatusId == 2).FirstOrDefault();
        var closed = _actionRepository.Find(r => r.RequestId == request.Id && r.RequestStatusId == 6).FirstOrDefault();
        var actions = _actionRepository.Find(r => r.RequestId == request.Id).OrderBy(r => r.Id).ToList();
        TimeSpan waitings = default(TimeSpan);
        Dictionary<int, DateTime> dateValuePairs = new Dictionary<int, DateTime>();

        for (int i = 0; i < actions.Count(); i++)
        {
            if (actions[i].RequestStatusId == 2 && actions[i - 1].RequestStatusId == 4)
            {
                var k = actions[i].CreatedAt.Subtract(actions[i - 1].CreatedAt);
                waitings += k;
            }
        }

        var execution = closed.CreatedAt.Subtract(fistExecution.CreatedAt).Subtract(waitings);
        var report = new Report()
        {
            RequestId = request.Id,
            CreateUserId = request.CreateUserId,
            CategoryId = request.CategoryId,
            CreatedAt = request.CreatedAt,
            InitialExecutionDate = fistExecution.CreatedAt,
            ExecutionTime = execution,
            ExecutorUserId = request.ExecutorUserId,
            ClosedAt = closed.CreatedAt,
            RequestStatusId = request.RequestStatusId
        };

        _reportRepository.Add(report);
    }

    public byte[] GenerateExcelFile(List<ReportResponseDTO> reports)
    {
        var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Reports");
        worksheet.Cells.LoadFromCollection(reports, true);

        var memoryStream = new MemoryStream();
        package.SaveAs(memoryStream);

        return memoryStream.ToArray();
    }

    public List<ReportResponseDTO> GetAll(int pageIndex, int pageSize)
    {
        var reports = _reportRepository.GetAll().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return _mapper.Map<List<ReportResponseDTO>>(reports);
    }

    public List<ReportResponseDTO> GetAll()
    {
        var reports = _reportRepository.GetAll();
        return _mapper.Map<List<ReportResponseDTO>>(reports);
    }

    public List<ReportResponseDTO> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var reports = _reportRepository.Find(r => r.CreatedAt >= startDate && r.CreatedAt <= endDate);
        return _mapper.Map<List<ReportResponseDTO>>(reports);
    }

    public List<ReportResponseDTO> GetFiltered(ReportFilterDTO listReport)
    {
        var reports = _reportRepository.GetAll().AsQueryable();

        var filters = new Dictionary<string, Func<IQueryable<Report>, string, IQueryable<Report>>>
                {
                    { "RequestId", (query, value) => query.Where(e => e.Request.Id.ToString().Contains(value)) },
                    { "CreateUser", (query, value) => query.Where(e => e.Request.CreateUser.Name.Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "Category", (query, value) => query.Where(e => e.Request.Category.Name.Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "CreatedAt", (query, value) => query.Where(e => e.CreatedAt.ToString().Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "InitialExecutionDate", (query, value) => query.Where(e => e.InitialExecutionDate.ToString().Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "ExecutionTime", (query, value) => query.Where(e => e.ExecutionTime.ToString().Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "ExecutorUser", (query, value) => query.Where(e => e.Request.ExecutorUser.Name.Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "ClosedAt", (query, value) => query.Where(e => e.ClosedAt.ToString().Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "Status", (query, value) => query.Where(e => e.Request.RequestStatus.Name.Trim().ToLower().Contains(value.Trim().ToLower())) },

                };

        foreach (var kvp in filters)
        {
            var key = kvp.Key;
            var value = typeof(ReportFilterDTO).GetProperty(key)?.GetValue(listReport)?.ToString();

            if (!string.IsNullOrEmpty(value))
            {
                reports = kvp.Value(reports, value);
            }
        }

        var pagination = reports.Skip((listReport.pageIndex - 1) * listReport.pageSize)
                        .Take(listReport.pageSize)
                        .ToList();
        return _mapper.Map<List<ReportResponseDTO>>(reports);
    }
}
