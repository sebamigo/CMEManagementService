
using AutoMapper;
using CMEManagementService.Configurations;
using CMEManagementService.Models.DTO;
using CMEManagementService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMEManagementService.Services
{
    public interface IReportService
    {
        Task<EducationReportDTO> GenerateEducationReportBySpecialtyAsync(string specialty, DateTime? fromDate = null, DateTime? toDate = null);
    }

    public class ReportService(AppDbContext dbContext) : IReportService
    {
        public async Task<EducationReportDTO> GenerateEducationReportBySpecialtyAsync(string specialty, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var reportQuery = dbContext.Doctors
                .AsNoTracking()
                .Where(d => d.Specialty == specialty)
                .SelectMany(d => d.Participations)
                .Where(pp => pp.HasCompleted);

            if (fromDate.HasValue)
                reportQuery = reportQuery.Where(pp => pp.EducationCourse.EndDate >= fromDate.Value);

            if (toDate.HasValue)
                reportQuery = reportQuery.Where(pp => pp.EducationCourse.EndDate <= toDate.Value);

            var finalReport = await reportQuery
                .GroupBy(pp => ((Doctor)pp.Personnel).Specialty)
                .Select(g => new EducationReportDTO
                {
                    Specialty = g.Key,
                    TotalContinuingEducationPoints = g.Sum(pp => pp.EducationCourse.CreditHours),
                    NumberOfAttendedCourses = g.Count(),
                    NumberOfDoctors = g.Select(pp => pp.PersonnelId).Distinct().Count()
                })
                .FirstOrDefaultAsync();

            if (finalReport != null && finalReport.NumberOfDoctors > 0)
                finalReport.AveragePointsPerDoctor = (double)finalReport.TotalContinuingEducationPoints / finalReport.NumberOfDoctors;

            return finalReport ?? new EducationReportDTO { Specialty = specialty };
        }
    }
}