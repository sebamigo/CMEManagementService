namespace CMEManagementService.Models.Entities
{
    public class Doctor : Personnel
    {
        public string Specialty { get; set; }
        public string LicenseNumber { get; set; }
    }
}