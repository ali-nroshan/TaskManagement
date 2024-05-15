using ErrorOr;
using Mapster;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Projects;
using TaskManagement.Application.Features.Projects.Requests.Queries;

namespace TaskManagement.Application.Features.Projects.Handlers.Queries;

public class GetProjectsQueryHandler(IProjectRepository projectRepository) : IRequestHandler<GetProjectsQuery, ErrorOr<List<ProjectDto>>>
{
    public async Task<ErrorOr<List<ProjectDto>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await projectRepository.GetAllProjectsAsync();
        return projects.Adapt<List<ProjectDto>>();
    }
}