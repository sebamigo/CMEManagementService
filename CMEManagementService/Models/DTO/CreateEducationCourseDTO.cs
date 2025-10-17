using System.ComponentModel.DataAnnotations;

namespace CMEManagementService.Models.DTO
{
    public class CreateEducationCourseDTO
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Range(1, 100)]
        public int CreditHours { get; set; }
    }
}