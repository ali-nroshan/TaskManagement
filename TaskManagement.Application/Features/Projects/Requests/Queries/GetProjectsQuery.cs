using ErrorOr;
using MediatR;
using TaskManagement.Application.DTOs.Projects;

namespace TaskManagement.Application.Features.Projects.Requests.Queries;

public record GetProjectsQuery(int UserId) : IRequest<ErrorOr<List<ProjectDto>>>;