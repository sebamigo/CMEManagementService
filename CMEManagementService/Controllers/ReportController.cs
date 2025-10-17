using Microsoft.AspNetCore.Mvc;
using CMEManagementService.Services;
using CMEManagementService.Models.DTO;

namespace CMEManagementService.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class ReportController(ILogger<ReportController> logger, IReportService reportService) : ControllerBase
{
    [HttpGet("EducationReports/{specialty:alpha}")]
    public async Task<IActionResult> GetEducationReport(string specialty, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
    {
        var report = await reportService.GenerateEducationReportBySpecialtyAsync(specialty, fromDate, toDate);
        return Ok(report);
    }
}