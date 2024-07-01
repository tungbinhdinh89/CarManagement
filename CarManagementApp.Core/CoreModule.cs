using CarManagementApp.Core.Services;
using CarManagementApp.Core.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagementApp.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreService(this IServiceCollection services)
        {
            return services.AddScoped<ICarService, CarService>();
        }
    }
}
