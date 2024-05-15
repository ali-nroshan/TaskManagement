using ErrorOr;
using Mapster;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Tasks;
using TaskManagement.Application.Features.Tasks.Requests.Queries;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Features.Tasks.Handlers.Queries;

public class GetTasksQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTasksQuery, ErrorOr<List<TaskDto>>>
{
    public async Task<ErrorOr<List<TaskDto>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await taskRepository.GetProjectTasksAsync(request.ProjectId);

        if (tasks.Count == 0)
            return Errors.Task.TaskNotFound;

        return tasks.Adapt<List<TaskDto>>();
    }
}