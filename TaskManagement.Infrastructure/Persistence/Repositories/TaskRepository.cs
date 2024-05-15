using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Persistence.Contexts;

namespace TaskManagement.Infrastructure.Persistence.Repositories;

public class TaskRepository(TaskManagementDbContext dbContext) : ITaskRepository
{
    public async Task CreateTaskAsync(TaskModel task)
    {
        await dbContext.Tasks.AddAsync(task);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(TaskModel taskModel)
    {
        dbContext.Tasks.Remove(taskModel);
        await dbContext.SaveChangesAsync();
    }

    public Task<List<TaskModel>> GetProjectTasksAsync(int projectId)
    {
        return dbContext.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
    }

    public Task<TaskModel?> GetTaskAsync(int taskId)
    {
        return dbContext.Tasks.FirstOrDefaultAsync(t=> t.TaskId == taskId);
    }

    public async Task<bool> IsTaskExistAsync(string taskName)
    {
        return await dbContext.Tasks.AnyAsync(t => t.TaskName == taskName);
    }

    public async Task UpdateTaskAsync(TaskModel taskModel)
    {
        dbContext.Tasks.Update(taskModel);
        await dbContext.SaveChangesAsync();
    }
}