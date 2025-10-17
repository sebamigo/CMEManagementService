namespace CMEManagementService.Models.Entities
{
    public abstract class Personnel
    {
        public Guid PersonnelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<PersonnelParticipation> Participations { get; set; }
    }
}