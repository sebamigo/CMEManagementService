using Microsoft.AspNetCore.Mvc;
using CMEManagementService.Services;
using CMEManagementService.Models.DTO;

namespace CMEManagementService.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class CourseController(ILogger<CourseController> logger, ICourseService courseService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateEducationCourseDTO createEducationCourse)
    {
        var educationCourse = await courseService.CreateEducationCourseAsync(createEducationCourse);
        return Ok(new { Message = "Education course created successfully", EducationCourse = educationCourse });
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var educationCourses = await courseService.GetAllEducationCoursesAsync();
        return Ok(educationCourses);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCourse(Guid id)
    {
        var educationCourse = await courseService.GetEducationCourseByIdAsync(id);
        return Ok(educationCourse);
    }

    [HttpPost("{courseId:guid}/participants")]
    public async Task<IActionResult> AssignParticipantToCourse(Guid courseId,[FromBody] AssignPersonnelToCourseDTO assignPersonnelToCourseDTO)
    {
        await courseService.AssignParticipantToCourseAsync(courseId, assignPersonnelToCourseDTO);
        return Ok(new { Message = "Participants assigned to course successfully." });
    }
}