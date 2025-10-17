using CMEManagementService.Models.Entites;
using Microsoft.EntityFrameworkCore;


namespace CMEManagementService.Configurations
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        
        public DbSet<EducationCourse> EducationCourses { get; set; }

        //public DbSet<DoctorParticipation> DoctorParticipations { get; set; }

        
    }
}