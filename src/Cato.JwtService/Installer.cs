using Microsoft.Extensions.DependencyInjection;

namespace Cato.JwtService
{
    public static class Installer
    {
        public static IServiceCollection AddJwtService(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
}
