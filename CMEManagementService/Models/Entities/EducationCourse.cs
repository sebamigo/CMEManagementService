namespace CMEManagementService.Models.Entities
{
    public class EducationCourse
    {
        public Guid EducationCourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CreditHours { get; set; }

        public ICollection<PersonnelParticipation> Participations { get; set; } = new List<PersonnelParticipation>();
    }
}