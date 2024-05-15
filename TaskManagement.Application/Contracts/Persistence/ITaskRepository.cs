using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Contracts.Persistence;

public interface ITaskRepository
{
    Task<List<TaskModel>> GetProjectTasksAsync(int projectId);
    Task<bool> IsTaskExistAsync(string taskName);
    Task CreateTaskAsync(TaskModel task);
    Task<TaskModel?> GetTaskAsync(int taskId);
    Task DeleteTaskAsync(TaskModel taskModel);
    Task UpdateTaskAsync(TaskModel taskModel);
}