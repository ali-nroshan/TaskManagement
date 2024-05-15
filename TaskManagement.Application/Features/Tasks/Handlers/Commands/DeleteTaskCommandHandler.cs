using ErrorOr;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Tasks.Requests.Commands;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Features.Tasks.Handlers.Commands;

public class DeleteTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<DeleteTaskCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await taskRepository.GetTaskAsync(request.TaskId);
        if (task is null)
            return Errors.Task.TaskNotFound;

        await taskRepository.DeleteTaskAsync(task);

        return Unit.Value;
    }
}