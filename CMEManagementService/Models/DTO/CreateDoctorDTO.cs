using System.ComponentModel.DataAnnotations;

namespace CMEManagementService.Models.DTO
{
    public class CreateDoctorDTO
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialty { get; set; }

        [Required]
        [StringLength(100)]
        public string LicenseNumber { get; set; }

    }
}