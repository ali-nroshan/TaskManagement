using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Infrastructure.Persistence.Contexts;
using TaskManagement.Infrastructure.Persistence.Repositories;

namespace TaskManagement.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection RegisterInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddDbContext<TaskManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("TaskManagementDbContext"));
        });

        _ = services
            .AddScoped<IProjectRepository, ProjectRepository>()
            .AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}