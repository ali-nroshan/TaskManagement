using ErrorOr;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Tasks;
using TaskManagement.Application.Features.Tasks.Requests.Commands;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Features.Tasks.Handlers.Commands;

public class UpdateTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<UpdateTaskCommand, ErrorOr<TaskDto>>
{
    public async Task<ErrorOr<TaskDto>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await taskRepository.GetTaskAsync(request.TaskDto.TaskId);
        if (task is null)
            return Errors.Task.TaskNotFound;

        task.TaskName = request.TaskDto.TaskName;
        await taskRepository.UpdateTaskAsync(task);

        return request.TaskDto;
    }
}
