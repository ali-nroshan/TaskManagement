using ErrorOr;
using MediatR;
using TaskManagement.Application.DTOs.Tasks;

namespace TaskManagement.Application.Features.Tasks.Requests.Commands;

public record UpdateTaskCommand(TaskDto TaskDto) : IRequest<ErrorOr<TaskDto>>;