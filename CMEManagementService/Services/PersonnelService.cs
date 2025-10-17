using AutoMapper;
using CMEManagementService.Configurations;
using CMEManagementService.Extensions;
using CMEManagementService.Models.DTO;
using CMEManagementService.Models.Entities;

namespace CMEManagementService.Services
{
    public interface IPersonnelService
    {
        Task<Doctor> CreateDoctorAsync(CreateDoctorDTO createDoctorDto);

        IEnumerable<Personnel> GetAll(PersonnelRole role);
    }

    public class PersonnelService(IMapper mapper, AppDbContext dbContext) : IPersonnelService
    {

        private static readonly Dictionary<PersonnelRole, Type> RoleTypeMap = new()
        {
            { PersonnelRole.Doctor, typeof(Doctor) },
            { PersonnelRole.Nurse, typeof(Nurse) }
        };

        public async Task<Doctor> CreateDoctorAsync(CreateDoctorDTO createDoctorDto)
        {
            var doctor = mapper.Map<Doctor>(createDoctorDto);
            dbContext.Doctors.Add(doctor);

            await dbContext.SaveChangesAsync();

            return doctor;
        }

        public IEnumerable<Personnel> GetAll(PersonnelRole role)
        {
            if (!RoleTypeMap.TryGetValue(role, out var personType))
                return Enumerable.Empty<Personnel>();

            return dbContext.Personnel.OfType(personType).ToList();
        }
    }
}