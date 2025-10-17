using CMEManagementService.Configurations;
using CMEManagementService.Models.Entities;
using CMEManagementService.Services;
using Microsoft.EntityFrameworkCore;

namespace CMEManagementServiceTests.Services
{

    public class ReportServiceTests
    {
        private readonly AppDbContext _dbContext;
        private readonly ReportService _reportService;

        public ReportServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Wichtig: Eindeutiger Name für jede Test-Instanz
                .Options;
            _dbContext = new AppDbContext(options);

            _reportService = new ReportService(_dbContext);
        }

        private async Task SeedDatabase()
        {
            var doctor1 = new Doctor { PersonnelId = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", LicenseNumber = "6543", Specialty = "Kardiologie" };
            var doctor2 = new Doctor { PersonnelId = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", LicenseNumber = "12345", Specialty = "Neurochirurgie" };
            _dbContext.Doctors.Add(doctor1);
            _dbContext.Doctors.Add(doctor2);

            var course1 = new EducationCourse { EducationCourseId = Guid.NewGuid(), Title = "Grundlagen der Kardiologie", CreditHours = 20 };
            var course2 = new EducationCourse { EducationCourseId = Guid.NewGuid(), Title = "Fortgeschrittene Neurochirurgie", CreditHours = 30 };
            _dbContext.EducationCourses.Add(course1);
            _dbContext.EducationCourses.Add(course2);

            _dbContext.PersonnelParticipations.Add(new PersonnelParticipation { PersonnelId = doctor1.PersonnelId, Personnel = doctor1, EducationCourse = course1, HasCompleted = true });
            _dbContext.PersonnelParticipations.Add(new PersonnelParticipation { PersonnelId = doctor2.PersonnelId, Personnel = doctor2, EducationCourse = course2, HasCompleted = true });

            await _dbContext.SaveChangesAsync();
        }


        [Fact]
        public async Task GenerateReportAsync_ShouldReturnCorrectReportData()
        {
            // Arrange
            await SeedDatabase();

            // Act
            var report1 = await _reportService.GenerateEducationReportBySpecialtyAsync("Kardiologie");
            var report2 = await _reportService.GenerateEducationReportBySpecialtyAsync("Neurochirurgie");

            // Assert
            Assert.NotNull(report1);
            Assert.Equal("Kardiologie", report1.Specialty);
            Assert.Equal(20, report1.TotalContinuingEducationPoints);
            Assert.Equal(1, report1.NumberOfAttendedCourses);
            Assert.Equal(1, report1.NumberOfDoctors);
            Assert.Equal(20.0, report1.AveragePointsPerDoctor);

            Assert.NotNull(report2);
            Assert.Equal("Neurochirurgie", report2.Specialty);
            Assert.Equal(30, report2.TotalContinuingEducationPoints);
            Assert.Equal(1, report2.NumberOfAttendedCourses);
            Assert.Equal(1, report2.NumberOfDoctors);
            Assert.Equal(30.0, report2.AveragePointsPerDoctor);
        }
    }
}