namespace CMEManagementService.Models.Entites
{
    public class Doctor : Personnel
    {
        public string Specialty { get; set; }
        public string LicenseNumber { get; set; }
    }
}