using Microsoft.EntityFrameworkCore;
using CMEManagementService.Services;

namespace CMEManagementService.Configurations
{
    public static class Dependencies
    {
        public static void AddAppDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IPersonnelService, PersonnelService>();
            
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}