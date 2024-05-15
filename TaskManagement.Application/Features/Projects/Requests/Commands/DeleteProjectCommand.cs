using ErrorOr;
using MediatR;

namespace TaskManagement.Application.Features.Projects.Requests.Commands;

public record DeleteProjectCommand(int ProjectId) : IRequest<ErrorOr<Unit>>;