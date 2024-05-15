using ErrorOr;
using MediatR;
using TaskManagement.Application.DTOs.Tasks;

namespace TaskManagement.Application.Features.Tasks.Requests.Commands;

public record CreateTaskCommand(CreateTaskDto CreateTaskDto) : IRequest<ErrorOr<TaskDto>>;