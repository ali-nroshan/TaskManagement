using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Contracts.Persistence;

public interface IProjectRepository
{
    Task<bool> IsProjectExistAsync(int projectId);
    Task<bool> IsProjectExistAsync(int userId, string projectName);
    Task<ProjectModel?> GetProjectAsync(int projectId);
    Task CreateProjectAsync(ProjectModel project);
    Task DeleteProjectAsync(ProjectModel project);
    Task UpdateProjectAsync(ProjectModel project);
    Task<List<ProjectModel>> GetAllProjectsAsync();
}