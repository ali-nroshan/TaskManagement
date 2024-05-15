using ErrorOr;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Projects.Requests.Commands;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Features.Projects.Handlers.Commands;

public class DeleteProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<DeleteProjectCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetProjectAsync(request.ProjectId);
        if (project is null)
            return Errors.Project.ProjectNotFound;

        await projectRepository.DeleteProjectAsync(project);

        return Unit.Value;
    }
}