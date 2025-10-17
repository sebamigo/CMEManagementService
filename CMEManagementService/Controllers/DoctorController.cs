using Microsoft.AspNetCore.Mvc;
using CMEManagementService.Services;
using CMEManagementService.Models.DTO;

namespace CMEManagementService.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class DoctorController(ILogger<DoctorController> logger, IPersonnelService personnelService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDTO createDoctor)
    {
        var doctor = await personnelService.CreateDoctorAsync(createDoctor);

        return Ok(new { Message = "Doctor created successfully", Doctor = doctor });
    }

    [HttpGet]
    public IActionResult GetDoctors([FromQuery] PersonnelRole role)
    {
        var personnel = personnelService.GetAll(role);
        return Ok(personnel);
    }
}