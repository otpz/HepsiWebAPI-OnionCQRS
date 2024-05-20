using FluentValidation;
using HepsiWebAPI.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Globalization;
using MediatR;
using HepsiWebAPI.Application.Behaviour;

namespace HepsiWebAPI.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));

        }

    }
}
