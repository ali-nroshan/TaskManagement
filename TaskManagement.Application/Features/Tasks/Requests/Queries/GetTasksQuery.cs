using ErrorOr;
using MediatR;
using TaskManagement.Application.DTOs.Tasks;

namespace TaskManagement.Application.Features.Tasks.Requests.Queries;

public record GetTasksQuery(int ProjectId) : IRequest<ErrorOr<List<TaskDto>>>;