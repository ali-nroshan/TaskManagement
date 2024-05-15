using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Persistence.Contexts;

namespace TaskManagement.Infrastructure.Persistence.Repositories;

public class ProjectRepository(TaskManagementDbContext dbContext) : IProjectRepository
{
    public async Task CreateProjectAsync(ProjectModel project)
    {
        await dbContext.Projects.AddAsync(project);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProjectAsync(ProjectModel project)
    {
        dbContext.Projects.Remove(project);
        await dbContext.SaveChangesAsync();
    }

    public Task<List<ProjectModel>> GetAllProjectsAsync()
    {
        return dbContext.Projects.ToListAsync();
    }


    public Task<ProjectModel?> GetProjectAsync(int projectId)
    {
        return dbContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
    }

    private Task<ProjectModel?> GetProjectAsync(int userId, string projectName)
    {
        return dbContext.Projects.FirstOrDefaultAsync(p => p.UserId == userId && p.ProjectName == projectName);
    }


    public async Task<bool> IsProjectExistAsync(int userId, string projectName)
    {
        return await GetProjectAsync(userId, projectName) is not null;
    }

    public async Task<bool> IsProjectExistAsync(int projectId)
    {
        return await dbContext.Projects.AnyAsync(p => p.ProjectId == projectId);
    }

    public async Task UpdateProjectAsync(ProjectModel project)
    {
        dbContext.Projects.Update(project);
        await dbContext.SaveChangesAsync();
    }
}