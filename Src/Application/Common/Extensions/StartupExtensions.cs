using System.Reflection;
using Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assemblies = new[] {Assembly.GetExecutingAssembly()};
            
            services.AddAutoMapper(assemblies);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(assemblies);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            
            return services;
        }
    }
}