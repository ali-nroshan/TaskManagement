using ErrorOr;
using MediatR;
using TaskManagement.Application.DTOs.Projects;

namespace TaskManagement.Application.Features.Projects.Requests.Commands;

public record UpdateProjectCommand(ProjectDto ProjectDto) : IRequest<ErrorOr<ProjectDto>>;