using System.ComponentModel.DataAnnotations;

namespace CMEManagementService.Models.DTO
{
    public class AssignPersonnelToCourseDTO
    {
        [Required]
        public List<Guid> PersonnelIds { get; set; }
    }
}