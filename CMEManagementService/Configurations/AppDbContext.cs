using CMEManagementService.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace CMEManagementService.Configurations
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<EducationCourse> EducationCourses { get; set; }
        public DbSet<PersonnelParticipation> PersonnelParticipations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite keys for PersonnelParticipation
            modelBuilder.Entity<PersonnelParticipation>()
                .HasKey(t => new { t.PersonnelId, t.EducationCourseId });

            modelBuilder.Entity<PersonnelParticipation>()
                .HasOne(pp => pp.Personnel)
                .WithMany(p => p.Participations)
                .HasForeignKey(pp => pp.PersonnelId);

            modelBuilder.Entity<PersonnelParticipation>()
                .HasOne(pp => pp.EducationCourse)
                .WithMany(ec => ec.Participations)
                .HasForeignKey(pp => pp.EducationCourseId);
        }
    }
}