using AutoMapper;
using CMEManagementService.Configurations;
using CMEManagementService.Exceptions;
using CMEManagementService.Models.DTO;
using CMEManagementService.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace CMEManagementService.Services
{
    public interface ICourseService
    {
        Task AssignParticipantToCourseAsync(Guid courseId, AssignPersonnelToCourseDTO assignPersonnelToCourseDTO);
        Task<EducationCourse> CreateEducationCourseAsync(CreateEducationCourseDTO createEducationCourseDto);
        Task<IEnumerable<EducationCourse>> GetAllEducationCoursesAsync();
        Task<EducationCourse?> GetEducationCourseByIdAsync(Guid id);
    }

    public class CourseService(IMapper mapper, AppDbContext dbContext) : ICourseService
    {
        public async Task AssignParticipantToCourseAsync(Guid courseId, AssignPersonnelToCourseDTO assignPersonnelToCourseDTO)
        {
            var educationCourse = await dbContext.EducationCourses
                .Include(ec => ec.Participations)
                .FirstOrDefaultAsync(ec => ec.EducationCourseId == courseId)
                ?? throw new EntityNotFoundException("EducationCourse", courseId);

            foreach (var personnelId in assignPersonnelToCourseDTO.PersonnelIds)
            {
                if (!educationCourse.Participations.Any(p => p.PersonnelId == personnelId))
                {
                    var participation = new PersonnelParticipation
                    {
                        PersonnelId = personnelId,
                        EducationCourseId = courseId
                    };
                    educationCourse.Participations.Add(participation);
                }
            }

            dbContext.EducationCourses.Update(educationCourse);
            await dbContext.SaveChangesAsync();
        }

        public async Task<EducationCourse> CreateEducationCourseAsync(CreateEducationCourseDTO createEducationCourseDto)
        {
            var educationCourse = mapper.Map<EducationCourse>(createEducationCourseDto);
            dbContext.EducationCourses.Add(educationCourse);

            await dbContext.SaveChangesAsync();

            return educationCourse;
        }

        public async Task<IEnumerable<EducationCourse>> GetAllEducationCoursesAsync()
        {
            return await dbContext.EducationCourses
                .OrderBy(ec => ec.StartDate)
                .ToListAsync();
        }

        public async Task<EducationCourse?> GetEducationCourseByIdAsync(Guid id)
        {
            var educationCourse = await dbContext.EducationCourses
                .FirstOrDefaultAsync(ec => ec.EducationCourseId == id)
                ?? throw new EntityNotFoundException("EducationCourse", id);
            return educationCourse;
        }
    }
}