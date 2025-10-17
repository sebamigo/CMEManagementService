namespace CMEManagementService.Models.DTO
{
    public class CreateDoctorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public string LicenseNumber { get; set; }

    }
}