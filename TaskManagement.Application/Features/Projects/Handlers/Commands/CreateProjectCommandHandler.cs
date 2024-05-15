using ErrorOr;
using Mapster;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Projects;
using TaskManagement.Application.Features.Projects.Requests.Commands;
using TaskManagement.Domain.Common.Errors;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Projects.Handlers.Commands;

public class CreateProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<CreateProjectCommand, ErrorOr<ProjectDto>>
{
    public async Task<ErrorOr<ProjectDto>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        if (await projectRepository.IsProjectExistAsync(request.CreateProjectDto.UserId, request.CreateProjectDto.ProjectName))
            return Errors.Project.DuplicateProject;

        var newProject = request.CreateProjectDto.Adapt<ProjectModel>();
        await projectRepository.CreateProjectAsync(newProject);

        return newProject.Adapt<ProjectDto>();
    }
}