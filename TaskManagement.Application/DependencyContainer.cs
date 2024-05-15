using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TaskManagement.Application;

public static class DependencyContainer
{
    public static IServiceCollection RegisterApplicationDependency(this IServiceCollection services)
    {
        _ = services.AddMediatR(mediatR =>
        {
            _ = mediatR.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}