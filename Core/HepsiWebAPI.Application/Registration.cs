using HepsiWebAPI.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HepsiWebAPI.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
        }
    }
}
