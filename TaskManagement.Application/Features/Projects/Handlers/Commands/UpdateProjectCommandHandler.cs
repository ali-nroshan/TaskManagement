using ErrorOr;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Projects;
using TaskManagement.Application.Features.Projects.Requests.Commands;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Features.Projects.Handlers.Commands;

public class UpdateProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<UpdateProjectCommand, ErrorOr<ProjectDto>>
{
    public async Task<ErrorOr<ProjectDto>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetProjectAsync(request.ProjectDto.ProjectId);
        if (project is null)
            return Errors.Project.ProjectNotFound;

        project.ProjectName = request.ProjectDto.ProjectName;
        await projectRepository.UpdateProjectAsync(project);

        return request.ProjectDto;
    }
}