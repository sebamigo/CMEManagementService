namespace CMEManagementService.Models.Entities
{
    public class PersonnelParticipation
    {
        public Guid PersonnelId { get; set; }
        public Personnel Personnel { get; set; }
        public Guid EducationCourseId { get; set; }
        public EducationCourse EducationCourse { get; set; }
        public bool HasCompleted { get; set; } = false;
    }
}