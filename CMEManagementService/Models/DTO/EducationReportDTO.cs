namespace CMEManagementService.Models.DTO
{
    public class EducationReportDTO
    {
        public string Specialty { get; set; }
        public int NumberOfDoctors { get; set; }
        public int TotalContinuingEducationPoints { get; set; }
        public double AveragePointsPerDoctor { get; set; }
        public int NumberOfAttendedCourses { get; set; }
    }
}