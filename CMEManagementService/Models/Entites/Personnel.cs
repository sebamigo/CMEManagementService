namespace CMEManagementService.Models.Entites
{
    public abstract class Personnel
    {
        public int PersonnelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}