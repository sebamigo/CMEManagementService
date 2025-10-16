using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace CMEManagementService.Configurations
{
    public static class Dependencies
    {
        public static void AddAppDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}