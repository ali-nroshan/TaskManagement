using ErrorOr;
using MediatR;

namespace TaskManagement.Application.Features.Tasks.Requests.Commands;

public record DeleteTaskCommand(int TaskId) : IRequest<ErrorOr<Unit>>;