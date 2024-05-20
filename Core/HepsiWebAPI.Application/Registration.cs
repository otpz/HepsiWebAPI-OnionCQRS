using FluentValidation;
using HepsiWebAPI.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Globalization;
using MediatR;
using HepsiWebAPI.Application.Behaviour;
using HepsiWebAPI.Application.Features.Products.Rules;
using HepsiWebAPI.Application.Bases;

namespace HepsiWebAPI.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));

        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }

            return services;
        }

    }
}
