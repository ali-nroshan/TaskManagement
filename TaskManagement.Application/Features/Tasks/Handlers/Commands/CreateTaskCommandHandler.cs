using ErrorOr;
using Mapster;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Tasks;
using TaskManagement.Application.Features.Tasks.Requests.Commands;
using TaskManagement.Domain.Common.Errors;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Tasks.Handlers.Commands;

public class CreateTaskCommandHandler(ITaskRepository taskRepository, IProjectRepository projectRepository) : IRequestHandler<CreateTaskCommand, ErrorOr<TaskDto>>
{
    public async Task<ErrorOr<TaskDto>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        if (!await projectRepository.IsProjectExistAsync(request.CreateTaskDto.ProjectId))
            return Errors.Project.ProjectNotFound;

        if (await taskRepository.IsTaskExistAsync(request.CreateTaskDto.TaskName))
            return Errors.Task.DuplicateTask;

        var newTask = request.CreateTaskDto.Adapt<TaskModel>();
        await taskRepository.CreateTaskAsync(newTask);

        return newTask.Adapt<TaskDto>();
    }
}